using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using TIPClient;

namespace VoIP.WinFormsUserInterface
{
    public partial class LogIn : Form
    {
        TIPClient.TCPClient tcpclient;
        TIPPacket.Packet message;
        string myEmail;
        ErrorProvider errorProvider = new ErrorProvider();
        public LogIn(TCPClient client)
        {
            tcpclient = client;
            InitializeComponent();
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
        private void LogInButton_Click(object sender, EventArgs e)
        {
           
             if (!Helpers.EmailValidation.IsValidEmail(emailTextBox.Text))
             {
                 MessageBox.Show("Wprowadzono błędny email");
             }else
             {
                    string sHashedPasword =  Helpers.AuthenticationMethods.HashPassword(PasswordTextBox.Text);

                    if (waitForAnswer(tcpclient.Send(TIPPacket.Command.LogInRequest, emailTextBox.Text + "&" + sHashedPasword + "&" + GetIP() , tcpclient.getStream())))
                    {
                        if (message.Command == TIPPacket.Command.LogInAccepted)
                        {
                            myEmail = emailTextBox.Text;
                            MainForm mainForm = new MainForm(tcpclient, myEmail);
                            mainForm.Show();
                            Visible = false;
                        }
                        else if(message.Command == TIPPacket.Command.LogInInvalidCredentials)
                        {
                           
                            MessageBox.Show("Błędny email lub hasło");
                        }

                    }
                    
             }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            if( tcpclient.getStream() != null){
                    NetworkStream connectedSteam = tcpclient.getStream();
                    
                    if (waitForAnswer(tcpclient.Send(TIPPacket.Command.EndConnection, "", connectedSteam)))
                    {
                        if (message.Command == TIPPacket.Command.EndConnectionAck)
                        {
                            Application.Exit();
                        }
                    }
                }else
               Application.Exit();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register register = new Register(tcpclient);
            register.Show();
            Visible = false;
        }

       

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)// the reason that you need
                base.OnFormClosing(e);
            else
            {
                 if( tcpclient.getStream() != null){
                    NetworkStream connectedSteam = tcpclient.getStream();
                    e.Cancel = true; // cancel if the close reason is not the expected one
                    if (waitForAnswer(tcpclient.Send(TIPPacket.Command.EndConnection, "", connectedSteam)))
                    {
                        if (message.Command == TIPPacket.Command.EndConnectionAck)
                        {
                            Application.Exit();
                        }
                    }
                }else
               Application.Exit();
            }
        }

    }
}
