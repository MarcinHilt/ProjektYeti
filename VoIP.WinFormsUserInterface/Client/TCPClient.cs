using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TIPPacket;
using System.Collections.Generic;

namespace TIPClient
{
    public sealed class TCPClient
    {
        private readonly TcpClient client;
        public int user_token = 0, identifier = 0;
        public bool connected = false;

        public List<TIPPacket.Packet> received_messages = new List<TIPPacket.Packet>();
        public TCPClient(int portNumber, string server_ip)
        {
            client = new TcpClient(server_ip, portNumber);
        }

        public bool isConnected() {

            return connected = client.Connected;

        }

        public NetworkStream getStream()
        {

            try
            {
                if(client.Connected)
                return client.GetStream();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
              return null;
        }

        public void startReceivingMessages()
        {
                       
                Thread clientThread = new Thread(() => {
                    CommunicateWithClient(client);
                });

                clientThread.Start();
            
        }

        private void CommunicateWithClient(TcpClient tcpClient)
        {
            bool endConnection = false;
            Packet message;

            Console.WriteLine("Client started a connection.");

            NetworkStream networkStream = tcpClient.GetStream();
            string clientIP = tcpClient.Client.RemoteEndPoint.ToString();
            try
            {
                for (; ; )
                {
                    if (endConnection)
                    {
                        break;
                    }
                    // test1
                    message = new Packet(networkStream);
                    received_messages.Add(message);
                    AnalyzeMessage(ref endConnection, message, networkStream);
                }

                Console.WriteLine("Client ended a connection.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void AnalyzeMessage(ref bool endConnection, Packet message, NetworkStream networkStream)
        {
            identifier = message.Identifier;
            switch (message.Command)
            {
                case Command.EndConnectionAck:
                    endConnection = true;
                    SendMessage(Command.EndConnection, message.Identifier, new byte[] { }, networkStream);
                    break;
                
            }
        }

        public TIPPacket.Packet GetReceivedMessage(int identifier)
        {
            for(int i=0; i<received_messages.Count; i++)
            {
                if(received_messages[i].Identifier == identifier)
                {
                    TIPPacket.Packet found_packet = received_messages[i];
                    received_messages.RemoveAt(i);
                    return found_packet;                    
                }                
            }
            TIPPacket.Packet packet = new TIPPacket.Packet(Command.NotFound, 0, Encoding.ASCII.GetBytes(""));
            return packet;
        }

        public int Send(Command command, string data, NetworkStream networkStream)
        {
            identifier++;
            Packet message = new Packet(command, identifier, Encoding.ASCII.GetBytes(data));

            byte[] serializedMessage = message.Serialize();
            if (networkStream.CanWrite)
            {
                networkStream.Write(serializedMessage, 0, serializedMessage.Length);
            }
            else
            {
                Console.WriteLine("Sorry.  You cannot write to this NetworkStream.");
            }
            return identifier;
        }

        public void SendMessage(Command command, int identifier, byte[] data, NetworkStream networkStream)
        {
            identifier++;
            Packet message = new Packet(command, identifier, data);

            byte[] serializedMessage = message.Serialize();
            if (networkStream.CanWrite)
            {
                networkStream.Write(serializedMessage, 0, serializedMessage.Length);
            }
            else
            {
                Console.WriteLine("Sorry.  You cannot write to this NetworkStream.");
            }
        }
    }
}
