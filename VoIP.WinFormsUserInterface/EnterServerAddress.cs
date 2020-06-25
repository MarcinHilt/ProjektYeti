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


namespace VoIP.WinFormsUserInterface
{
    public partial class EnterServerAddress : Form
    {
        public EnterServerAddress()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, EventArgs eventArgs)
        {
            try
            {
            TCPClient client = new TCPClient(37000, serverIPTextBox.Text);
            client.startReceivingMessages();
            LogIn logIn = new LogIn(client);
            logIn.Show();
            Visible = false;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                MessageBox.Show( e.Message);
            }
        }
    }
}
