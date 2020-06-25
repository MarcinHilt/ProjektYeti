using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoIP.WinFormsUserInterface.Properties;

namespace VoIP.WinFormsUserInterface.Panels
{
    public partial class MainPanel : PanelBase
    {
        public static TIPClient.TCPClient tcpclient;
        public static TIPPacket.Packet message;
        public static string myEmail;
        public static string highestID = "0";
        public static string emailCalled;
        List<string> friends = new List<string>();
        List<string> blacklist = new List<string>();
        ErrorProvider errorProvider = new ErrorProvider();
        public static string time { get; set; }
        public MainPanel(TIPClient.TCPClient client, string Email)
        {
            tcpclient = client;
            myEmail = Email;
            InitializeComponent();
            if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetFriendsListRequest, myEmail, tcpclient.getStream())))
            {
                if (message.Command == TIPPacket.Command.FriendsListCountSent)
                {
                    string numberOfFriends = "";
                    foreach (char character in message.Data)
                    {
                        if (character != '&')
                        {
                            numberOfFriends += character;
                        }
                    }
                    int friendsNumber = int.Parse(numberOfFriends);
                    if(friendsNumber > 0 && friendsNumber <= 10)
                    {
                        if(waitForAnswer(tcpclient.Send(TIPPacket.Command.GetFriendsListLastPart, myEmail + "&" + "0" + "&" + numberOfFriends, tcpclient.getStream())))
                        {
                            if (message.Command == TIPPacket.Command.FriendsListLastPartSent)
                            {
                                string friendEmail = "";                                
                                foreach (char character in message.Data)
                                {
                                    if (character != '&')
                                    {
                                        friendEmail += character;
                                    }
                                    else
                                    {
                                        friends.Add(friendEmail);
                                        friendEmail = "";
                                    }
                                }
                            }
                        }
                    }
                    if(friendsNumber > 10 && friendsNumber <= 20)
                    {
                        if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetFriendsListFirstPart, myEmail, tcpclient.getStream())))
                        {
                            if (message.Command == TIPPacket.Command.FriendsListFirstPartSent)
                            {
                                string friendEmail = "";
                                foreach (char character in message.Data)
                                {
                                    if (character != '&')
                                    {
                                        friendEmail += character;
                                    }
                                    else
                                    {
                                        friends.Add(friendEmail);
                                        friendEmail = "";
                                    }
                                }
                                if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetFriendsListLastPart, myEmail + "&" + "10" + "&" + numberOfFriends, tcpclient.getStream())))
                                {
                                    if (message.Command == TIPPacket.Command.FriendsListLastPartSent)
                                    {
                                        friendEmail = "";
                                        foreach (char character in message.Data)
                                        {
                                            if (character != '&')
                                            {
                                                friendEmail += character;
                                            }
                                            else
                                            {
                                                friends.Add(friendEmail);
                                                friendEmail = "";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (friendsNumber > 20 && friendsNumber <= 30)
                    {
                        if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetFriendsListFirstPart, myEmail, tcpclient.getStream())))
                        {
                            if (message.Command == TIPPacket.Command.FriendsListFirstPartSent)
                            {
                                string friendEmail = "";
                                foreach (char character in message.Data)
                                {
                                    if (character != '&')
                                    {
                                        friendEmail += character;
                                    }
                                    else
                                    {
                                        friends.Add(friendEmail);
                                        friendEmail = "";
                                    }
                                }
                                if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetFriendsListSecondPart, myEmail, tcpclient.getStream())))
                                {
                                    if (message.Command == TIPPacket.Command.FriendsListSecondPartSent)
                                    {
                                        friendEmail = "";
                                        foreach (char character in message.Data)
                                        {
                                            if (character != '&')
                                            {
                                                friendEmail += character;
                                            }
                                            else
                                            {
                                                friends.Add(friendEmail);
                                                friendEmail = "";
                                            }
                                        }
                                        if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetFriendsListLastPart, myEmail + "&" + "20" + "&" + numberOfFriends, tcpclient.getStream())))
                                        {
                                            if (message.Command == TIPPacket.Command.FriendsListLastPartSent)
                                            {
                                                friendEmail = "";
                                                foreach (char character in message.Data)
                                                {
                                                    if (character != '&')
                                                    {
                                                        friendEmail += character;
                                                    }
                                                    else
                                                    {
                                                        friends.Add(friendEmail);
                                                        friendEmail = "";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }            
            foreach (string friend in friends)
            {
                this.friendsListBox.Items.Add(friend);
            }
            if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetBlacklistListRequest, myEmail, tcpclient.getStream())))
            {
                if (message.Command == TIPPacket.Command.BlacklistListCountSent)
                {
                    string numberOfFriends = "";
                    foreach (char character in message.Data)
                    {
                        if (character != '&')
                        {
                            numberOfFriends += character;
                        }
                    }
                    int friendsNumber = int.Parse(numberOfFriends);
                    if (friendsNumber > 0 && friendsNumber <= 10)
                    {
                        if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetBlacklistListLastPart, myEmail + "&" + "0" + "&" + numberOfFriends, tcpclient.getStream())))
                        {
                            if (message.Command == TIPPacket.Command.BlacklistListLastPartSent)
                            {
                                string friendEmail = "";
                                foreach (char character in message.Data)
                                {
                                    if (character != '&')
                                    {
                                        friendEmail += character;
                                    }
                                    else
                                    {
                                        blacklist.Add(friendEmail);
                                        friendEmail = "";
                                    }
                                }
                            }
                        }
                    }
                    if (friendsNumber > 10 && friendsNumber <= 20)
                    {
                        if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetBlacklistListFirstPart, myEmail, tcpclient.getStream())))
                        {
                            if (message.Command == TIPPacket.Command.BlacklistListFirstPartSent)
                            {
                                string friendEmail = "";
                                foreach (char character in message.Data)
                                {
                                    if (character != '&')
                                    {
                                        friendEmail += character;
                                    }
                                    else
                                    {
                                        blacklist.Add(friendEmail);
                                        friendEmail = "";
                                    }
                                }
                                if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetBlacklistListLastPart, myEmail + "&" + "10" + "&" + numberOfFriends, tcpclient.getStream())))
                                {
                                    if (message.Command == TIPPacket.Command.BlacklistListLastPartSent)
                                    {
                                        friendEmail = "";
                                        foreach (char character in message.Data)
                                        {
                                            if (character != '&')
                                            {
                                                friendEmail += character;
                                            }
                                            else
                                            {
                                                blacklist.Add(friendEmail);
                                                friendEmail = "";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (friendsNumber > 20 && friendsNumber <= 30)
                    {
                        if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetBlacklistListFirstPart, myEmail, tcpclient.getStream())))
                        {
                            if (message.Command == TIPPacket.Command.BlacklistListFirstPartSent)
                            {
                                string friendEmail = "";
                                foreach (char character in message.Data)
                                {
                                    if (character != '&')
                                    {
                                        friendEmail += character;
                                    }
                                    else
                                    {
                                        blacklist.Add(friendEmail);
                                        friendEmail = "";
                                    }
                                }
                                if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetBlacklistListSecondPart, myEmail, tcpclient.getStream())))
                                {
                                    if (message.Command == TIPPacket.Command.BlacklistListSecondPartSent)
                                    {
                                        friendEmail = "";
                                        foreach (char character in message.Data)
                                        {
                                            if (character != '&')
                                            {
                                                friendEmail += character;
                                            }
                                            else
                                            {
                                                blacklist.Add(friendEmail);
                                                friendEmail = "";
                                            }
                                        }
                                        if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetBlacklistListLastPart, myEmail + "&" + "20" + "&" + numberOfFriends, tcpclient.getStream())))
                                        {
                                            if (message.Command == TIPPacket.Command.BlacklistListLastPartSent)
                                            {
                                                friendEmail = "";
                                                foreach (char character in message.Data)
                                                {
                                                    if (character != '&')
                                                    {
                                                        friendEmail += character;
                                                    }
                                                    else
                                                    {
                                                        blacklist.Add(friendEmail);
                                                        friendEmail = "";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (string black in blacklist)
            {
                this.blacklistListBox.Items.Add(black);
            }
            if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetNumberOfCallsRequest, myEmail, tcpclient.getStream())))
            {
                if (message.Command == TIPPacket.Command.GetNumberOfCallsAccepted)
                {
                    string number = "";
                    foreach (char character in message.Data)
                    {
                        if (character != '&')
                        {
                            number += character;
                        }
                    }
                    if(int.Parse(number) != 0)
                    {
                        List<ListViewItem> items = new List<ListViewItem>();
                        for(int i=1; i <= int.Parse(number); i++)
                        {
                            if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetCallInfoRequest, myEmail + "&" + i.ToString(), tcpclient.getStream())))
                            {
                                if (message.Command == TIPPacket.Command.GetCallInfoSent)
                                {
                                    string ID = "";
                                    string DATA = "";
                                    string EMAIL = "";
                                    string TIME = "";
                                    int HELP = 0;
                                    try
                                    {
                                        foreach (char character in message.Data)
                                        {
                                            if (HELP == 0 && character != '&')
                                            {
                                                ID += character;
                                            }
                                            else if (character == '&')
                                            {
                                                HELP++;
                                            }
                                            else if (HELP == 1 && character != '&')
                                            {
                                                DATA += character;
                                            }
                                            else if (HELP == 2 && character != '&')
                                            {
                                                EMAIL += character;
                                            }
                                            else if (HELP == 3 && character != '&')
                                            {
                                                TIME += character;
                                            }
                                        }
                                        System.Windows.Forms.ListViewItem listViewItem = new System.Windows.Forms.ListViewItem(new string[] {
                                            ID,
                                            DATA,
                                            EMAIL,
                                            TIME}, 0);
                                        items.Add(listViewItem);
                                        if (int.Parse(highestID) < int.Parse(ID))
                                        {
                                            highestID = (int.Parse(ID) + 1).ToString();
                                        }
                                    }
                                    catch
                                    {

                                    }                                    
                                }
                            }
                        }
                        for(int i = items.Count - 1; i>=0; i--)
                        {
                            callHistoryListView.Items.Add(items[i]);
                        }
                    }
                }
            }
            this.Dock = DockStyle.Fill;
        }

        public event Action<string, int> BeginCall;

        public event Action<string, int> LogOut;
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
        private void btnCall_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (!Helpers.EmailValidation.IsValidEmail(tbConnection.Text))
                {
                    MessageBox.Show("Wprowadzono błędny email");
                }
                else
               if (waitForAnswer(tcpclient.Send(TIPPacket.Command.GetIPRequest, myEmail + "&" + tbConnection.Text, tcpclient.getStream())))
                {
                    if (message.Command == TIPPacket.Command.IPSent)
                    {
                        Uri u = new Uri(string.Format("voip://{0}", Encoding.ASCII.GetString(message.Data)));
                        emailCalled = tbConnection.Text;
                        if (BeginCall != null)
                            BeginCall(u.Host, u.IsDefaultPort ? Settings.Default.SignalizationPort : u.Port);
                    }
                    else if (message.Command == TIPPacket.Command.GetIPRequestDenied)
                    {
                        MessageBox.Show("Brak użytkownika o podanym adresie!");
                    }
                    else if (message.Command == TIPPacket.Command.Blacklisted)
                    {
                        MessageBox.Show("Jesteś na czarnej liście podanego użytkownika");
                    }
                }
                else {
                    MessageBox.Show("Serwer nie odpowiada");
                }
            }
            catch
            {
                MessageBox.Show("Wprowadzono nieprawidłowe dane połaczenia", "Błąd wprowadzonych danych", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FriendsButton_Click(object sender, EventArgs e)
        {
                      
            blacklistListBox.Visible = false;           
            ListBoxLabel.Text = "Znajomi";
            friendsListBox.Visible = true;
            
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            
            LogOut("logOut", 1);           
           
        }

        private void friendsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string curItem = friendsListBox.SelectedItem.ToString();
                int index = friendsListBox.FindString(curItem);
                if (index == -1)
                    MessageBox.Show("Chosen element is not availiable");
                else
                {
                    tbConnection.Text = curItem; 
                }
            }
            catch
            {

            }                    
        }

        private void blacklistListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string curItem = blacklistListBox.SelectedItem.ToString();
                int index = blacklistListBox.FindString(curItem);
                if (index == -1)
                    MessageBox.Show("Chosen element is not availiable");
                else
                {
                    tbConnection.Text = curItem;                  
                }
            }
            catch
            {

            }
        }

        private void BlackListButton_Click(object sender, EventArgs e)
        {
           
            friendsListBox.Visible = false;
            ListBoxLabel.Text = "Czarna lista";
            blacklistListBox.Visible = true;                   
           
        }

            

        private void CallHistoryButton_Click(object sender, EventArgs e)
        {
            if (waitForAnswer(tcpclient.Send(TIPPacket.Command.ClearCallHistory, myEmail, tcpclient.getStream())))
            {
                if (message.Command == TIPPacket.Command.ClearCallHistoryAccepted)
                {
                    callHistoryListView.Items.Clear();
                }
                else
                {
                    MessageBox.Show("Błąd!");
                }
            }
                    

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
               if( tcpclient.getStream() != null){
                    System.Net.Sockets.NetworkStream connectedSteam = tcpclient.getStream();
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
                

        private void Button2_Click(object sender, EventArgs e)
        {
            if(friendsListBox.Items.Count < 30)
            {
                foreach(string email in blacklistListBox.Items)
                {
                    if(email == tbConnection.Text)
                    {
                        if (waitForAnswer(tcpclient.Send(TIPPacket.Command.RemoveBlacklistRequest, myEmail + "&" + tbConnection.Text, tcpclient.getStream())))
                        {
                            if (message.Command == TIPPacket.Command.RemoveBlacklistAccepted && tbConnection.Text != "")
                            {
                                blacklistListBox.Items.Remove(tbConnection.Text);
                            }
                            else
                            {
                                MessageBox.Show("Błąd!");
                            }
                        }
                        break;
                    }
                }
                    if (waitForAnswer(tcpclient.Send(TIPPacket.Command.AddFriendRequest, myEmail + "&" + tbConnection.Text, tcpclient.getStream())))
                    {
                        if (message.Command == TIPPacket.Command.AddFriendAccepted && tbConnection.Text != "")
                        {
                            friendsListBox.Items.Add(tbConnection.Text);
                        }
                        else
                        {
                            MessageBox.Show("Błąd!");
                        }
                    }                
            }
            else
            {
                MessageBox.Show("Przekroczono liczbę znajomych");
            }
        }

        private void BlockButton_Click(object sender, EventArgs e)
        {
            if (blacklistListBox.Items.Count < 30)
            {
                foreach (string email in friendsListBox.Items)
                {
                    if (email == tbConnection.Text)
                    {
                        if (waitForAnswer(tcpclient.Send(TIPPacket.Command.RemoveFriendRequest, myEmail + "&" + tbConnection.Text, tcpclient.getStream())))
                        {
                            if (message.Command == TIPPacket.Command.RemoveFriendAccepted && tbConnection.Text != "")
                            {
                                friendsListBox.Items.Remove(tbConnection.Text);
                            }
                            else
                            {
                                MessageBox.Show("Błąd!");
                            }
                        }
                        break;
                    }
                }
                if (waitForAnswer(tcpclient.Send(TIPPacket.Command.AddBlacklistRequest, myEmail + "&" + tbConnection.Text, tcpclient.getStream())))
                {
                    if (message.Command == TIPPacket.Command.AddBlacklistAccepted && tbConnection.Text != "")
                    {
                        blacklistListBox.Items.Add(tbConnection.Text);
                    }
                    else
                    {
                        MessageBox.Show("Błąd!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Przekroczono liczbę zablokowanych użytkowników");
            }
        }

        private void RemoveFriendButton_Click(object sender, EventArgs e)
        {
            if (waitForAnswer(tcpclient.Send(TIPPacket.Command.RemoveFriendRequest, myEmail + "&" + tbConnection.Text, tcpclient.getStream())))
            {
                if (message.Command == TIPPacket.Command.RemoveFriendAccepted)
                {
                    friendsListBox.SelectedItem = null;
                    friendsListBox.Items.Remove(tbConnection.Text);                    
                }
                else
                {
                    MessageBox.Show("Błąd!");
                }
            }
        }

        private void DeleteFromBlacklistButton_Click(object sender, EventArgs e)
        {
            if (waitForAnswer(tcpclient.Send(TIPPacket.Command.RemoveBlacklistRequest, myEmail + "&" + tbConnection.Text, tcpclient.getStream())))
            {
                if (message.Command == TIPPacket.Command.RemoveBlacklistAccepted)
                {
                    blacklistListBox.SelectedItem = null;
                    blacklistListBox.Items.Remove(tbConnection.Text);
                }
                else
                {
                    MessageBox.Show("Błąd!");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resources.yeti_growl_panda3);
            player.Play();

        }
    }
}
