using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VoIP.TcpSignalizationLibrary;
using VoIP.WinFormsUserInterface.Helpers;

namespace VoIP.WinFormsUserInterface.Panels
{
    public partial class ConversationPanel : VoIP.WinFormsUserInterface.Panels.PanelBase
    {
        DateTime beginConversationTime;
        TcpSignalizationClient servicedClient;

        bool disposed = false;

        public ConversationPanel(TcpSignalizationClient client)
        {
            InitializeComponent();

            this.beginConversationTime = DateTime.Now;
            this.servicedClient = client;
            this.servicedClient.OnDispose += ServicedClient_OnDispose;
            this.servicedClient.OnNewPacketIncome += ServicedClient_OnNewPacketIncome;

            this.labTo.Text = client.RemoteUri;
        }

        private void ServicedClient_OnNewPacketIncome(TcpSignalizationClient client, SignalizationPacket packet)
        {
            if (this.AfterPacketIncomeInvoke(ServicedClient_OnNewPacketIncome, client, packet))
                return;
            
            if(packet.Command == SignalizationCommand.End)
            {
                String date = DateTime.Now.ToString("dd.MM.yyy");
                MainPanel.highestID = (int.Parse(MainPanel.highestID) + 1).ToString();
                waitForAnswer(MainPanel.tcpclient.Send(TIPPacket.Command.AddCallToHistoryRequest
                    , MainPanel.myEmail +
                    "&" + MainPanel.highestID +
                    "&" + date + "&" + this.labTo.Text +
                    "&" + labTimer.Text, MainPanel.tcpclient.getStream())
                    );
                client.Dispose();
            }
        }
        bool waitForAnswer(int identifier)
        {
            int counter = 0;
            while (counter < 1000)
            {
                MainPanel.message = MainPanel.tcpclient.GetReceivedMessage(identifier);
                System.Threading.Thread.Sleep(10);
                if (MainPanel.message.Command != TIPPacket.Command.NotFound)
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

        private void ServicedClient_OnDispose(TcpSignalizationClient obj)
        {
            try
            {
                this.BeginInvoke(new Action(() =>
                {
                labMessage.Text = "Rozmowa zakończona.";
                    this.ConversationTimer.Stop();
                    this.disposed = true;                    
                }));
            }
            catch { }
        }

        public event Action<TcpSignalizationClient> OnConversationFinish;

        private void ConversationTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan time = DateTime.Now - beginConversationTime;

            labTimer.Text = string.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            String test = DateTime.Now.ToString("dd.MM.yyy");
            MainPanel.highestID = (int.Parse(MainPanel.highestID) + 1).ToString();
            waitForAnswer(MainPanel.tcpclient.Send(TIPPacket.Command.AddCallToHistoryRequest
                , MainPanel.myEmail +
                "&" + MainPanel.highestID +
                "&" + test + "&" + this.labTo.Text +
                "&" + labTimer.Text, MainPanel.tcpclient.getStream())
                );
           
                   
                
          
            if (disposed == false)
                this.servicedClient.Send(SignalizationCommand.End);

            ServicedClient_OnDispose(this.servicedClient);
            //this.servicedClient.OnDispose -= ServicedClient_OnDispose;            
            OnConversationFinish?.Invoke(servicedClient);
            
        }
    }
}
