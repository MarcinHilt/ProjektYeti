using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIPClient;
using TIPPacket;
using System.Net;

namespace VoIP.WinFormsUserInterface
{
    public partial class Register : Form
    {
        TCPClient tcpclient;
        Packet message;
        ErrorProvider errorProvider = new ErrorProvider();
        public Register(TCPClient tcpClient)
        {
            tcpclient = tcpClient;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            LogIn Login = new LogIn(tcpclient);
            Login.Show();
            Visible = false;
        }
        bool waitForAnswer(int identifier)
        {
            int counter = 0;
            while (counter < 1000)
            {
                message = tcpclient.GetReceivedMessage(identifier);
                System.Threading.Thread.Sleep(10);
                if (message.Command != TIPPacket.Command.NotFound)
                {
                    return true;
                }
                else
                {
                    counter++;
                }
            }
            return false;
        }
        private string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();

        }
        private void Register2Button_Click(object sender, EventArgs e)
        {
             if (!Helpers.EmailValidation.IsValidEmail(emailTextBox.Text))
            {
                MessageBox.Show("Wprowadzono błędny email");
            }else 
            if(passwordTextBox.Text == repeatPasswordTextBox.Text)
            {
                string sHashedPasword = Helpers.AuthenticationMethods.HashPassword(passwordTextBox.Text);

                if (waitForAnswer(tcpclient.Send(TIPPacket.Command.RegisterRequest, emailTextBox.Text + "&" + sHashedPasword + "&" + GetIP(), tcpclient.getStream())))
                {
                    if (message.Command == TIPPacket.Command.RegisterRequestAccepted)
                    {
                        LogIn Login = new LogIn(tcpclient);
                        Login.Show();
                        Visible = false;
                    }
                    else if (message.Command == TIPPacket.Command.RegisterRequestDenied) {
                        MessageBox.Show("Rejestracja nie powiodła się. " + message.ToString() );
                    }
                }
                
            }            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)// the reason that you need
                base.OnFormClosing(e);
            else
            {

                if (tcpclient.getStream() != null)
                {
                    System.Net.Sockets.NetworkStream connectedSteam = tcpclient.getStream();
                    e.Cancel = true; // cancel if the close reason is not the expected one
                    if (waitForAnswer(tcpclient.Send(TIPPacket.Command.EndConnection, "", connectedSteam)))
                    {
                        if (message.Command == TIPPacket.Command.EndConnectionAck)
                        {
                            Application.Exit();
                        }
                    }
                }
                else
                    Application.Exit();
            }
        }


    }
}
