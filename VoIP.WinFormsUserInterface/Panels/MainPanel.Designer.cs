using System.Collections.Generic;

namespace VoIP.WinFormsUserInterface.Panels
{
    partial class MainPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbConnection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCall = new System.Windows.Forms.Button();
            this.ClearHistoryButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.BlackListButton = new System.Windows.Forms.Button();
            this.FriendsButton = new System.Windows.Forms.Button();
            this.friendsListBox = new System.Windows.Forms.ListBox();
            this.ListBoxLabel = new System.Windows.Forms.Label();
            this.blacklistListBox = new System.Windows.Forms.ListBox();
            this.callHistoryListView = new System.Windows.Forms.ListView();
            this.indexColHistoryLivtView = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateColHistoryListView = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailColHistoryListView = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.durationColHistoryListView = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BlockButton = new System.Windows.Forms.Button();
            this.AddFriendButton = new System.Windows.Forms.Button();
            this.RemoveFriendButton = new System.Windows.Forms.Button();
            this.DeleteFromBlacklistButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbConnection
            // 
            this.tbConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConnection.Location = new System.Drawing.Point(6, 54);
            this.tbConnection.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.tbConnection.Name = "tbConnection";
            this.tbConnection.Size = new System.Drawing.Size(195, 20);
            this.tbConnection.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Podaj Email:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnCall
            // 
            this.btnCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCall.Location = new System.Drawing.Point(6, 80);
            this.btnCall.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(195, 35);
            this.btnCall.TabIndex = 19;
            this.btnCall.Text = "Połącz";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click_2);
            // 
            // ClearHistoryButton
            // 
            this.ClearHistoryButton.Location = new System.Drawing.Point(469, 450);
            this.ClearHistoryButton.Name = "ClearHistoryButton";
            this.ClearHistoryButton.Size = new System.Drawing.Size(154, 23);
            this.ClearHistoryButton.TabIndex = 25;
            this.ClearHistoryButton.Text = "Wyczyść hostorie połączeń";
            this.ClearHistoryButton.UseVisualStyleBackColor = true;
            this.ClearHistoryButton.Click += new System.EventHandler(this.CallHistoryButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(804, 450);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 23;
            this.QuitButton.Text = "Zakończ";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // BlackListButton
            // 
            this.BlackListButton.Location = new System.Drawing.Point(379, 450);
            this.BlackListButton.Name = "BlackListButton";
            this.BlackListButton.Size = new System.Drawing.Size(75, 23);
            this.BlackListButton.TabIndex = 22;
            this.BlackListButton.Text = "Czarna lista";
            this.BlackListButton.UseVisualStyleBackColor = true;
            this.BlackListButton.Click += new System.EventHandler(this.BlackListButton_Click);
            // 
            // FriendsButton
            // 
            this.FriendsButton.BackColor = System.Drawing.Color.Transparent;
            this.FriendsButton.Location = new System.Drawing.Point(214, 450);
            this.FriendsButton.Name = "FriendsButton";
            this.FriendsButton.Size = new System.Drawing.Size(75, 23);
            this.FriendsButton.TabIndex = 21;
            this.FriendsButton.Text = "Znajomi";
            this.FriendsButton.UseVisualStyleBackColor = false;
            this.FriendsButton.Click += new System.EventHandler(this.FriendsButton_Click);
            // 
            // friendsListBox
            // 
            this.friendsListBox.FormattingEnabled = true;
            this.friendsListBox.Location = new System.Drawing.Point(214, 54);
            this.friendsListBox.Name = "friendsListBox";
            this.friendsListBox.Size = new System.Drawing.Size(249, 381);
            this.friendsListBox.TabIndex = 26;
            this.friendsListBox.SelectedIndexChanged += new System.EventHandler(this.friendsListBox_SelectedIndexChanged);
            // 
            // ListBoxLabel
            // 
            this.ListBoxLabel.AutoSize = true;
            this.ListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ListBoxLabel.Location = new System.Drawing.Point(211, 33);
            this.ListBoxLabel.Name = "ListBoxLabel";
            this.ListBoxLabel.Size = new System.Drawing.Size(63, 16);
            this.ListBoxLabel.TabIndex = 27;
            this.ListBoxLabel.Text = "Znajomi";
            // 
            // blacklistListBox
            // 
            this.blacklistListBox.FormattingEnabled = true;
            this.blacklistListBox.Location = new System.Drawing.Point(214, 54);
            this.blacklistListBox.Name = "blacklistListBox";
            this.blacklistListBox.Size = new System.Drawing.Size(249, 381);
            this.blacklistListBox.TabIndex = 28;
            this.blacklistListBox.Visible = false;
            this.blacklistListBox.SelectedIndexChanged += new System.EventHandler(this.blacklistListBox_SelectedIndexChanged);
            // 
            // callHistoryListView
            // 
            this.callHistoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.indexColHistoryLivtView,
            this.dateColHistoryListView,
            this.emailColHistoryListView,
            this.durationColHistoryListView});
            this.callHistoryListView.FullRowSelect = true;
            this.callHistoryListView.GridLines = true;
            this.callHistoryListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.callHistoryListView.HideSelection = false;
            this.callHistoryListView.Location = new System.Drawing.Point(469, 54);
            this.callHistoryListView.MultiSelect = false;
            this.callHistoryListView.Name = "callHistoryListView";
            this.callHistoryListView.Size = new System.Drawing.Size(410, 381);
            this.callHistoryListView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.callHistoryListView.TabIndex = 30;
            this.callHistoryListView.UseCompatibleStateImageBehavior = false;
            this.callHistoryListView.View = System.Windows.Forms.View.Details;
            // 
            // indexColHistoryLivtView
            // 
            this.indexColHistoryLivtView.Text = "Id";
            this.indexColHistoryLivtView.Width = 38;
            // 
            // dateColHistoryListView
            // 
            this.dateColHistoryListView.Text = "Data";
            this.dateColHistoryListView.Width = 97;
            // 
            // emailColHistoryListView
            // 
            this.emailColHistoryListView.Text = "Użytkownik";
            this.emailColHistoryListView.Width = 170;
            // 
            // durationColHistoryListView
            // 
            this.durationColHistoryListView.Text = "czas połączenia";
            this.durationColHistoryListView.Width = 100;
            // 
            // BlockButton
            // 
            this.BlockButton.Location = new System.Drawing.Point(6, 203);
            this.BlockButton.Name = "BlockButton";
            this.BlockButton.Size = new System.Drawing.Size(195, 35);
            this.BlockButton.TabIndex = 31;
            this.BlockButton.Text = "Dodaj do czarnej listy";
            this.BlockButton.UseVisualStyleBackColor = true;
            this.BlockButton.Click += new System.EventHandler(this.BlockButton_Click);
            // 
            // AddFriendButton
            // 
            this.AddFriendButton.Location = new System.Drawing.Point(6, 121);
            this.AddFriendButton.Name = "AddFriendButton";
            this.AddFriendButton.Size = new System.Drawing.Size(195, 35);
            this.AddFriendButton.TabIndex = 32;
            this.AddFriendButton.Text = "Dodaj do listy znajomych";
            this.AddFriendButton.UseVisualStyleBackColor = true;
            this.AddFriendButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // RemoveFriendButton
            // 
            this.RemoveFriendButton.Location = new System.Drawing.Point(6, 162);
            this.RemoveFriendButton.Name = "RemoveFriendButton";
            this.RemoveFriendButton.Size = new System.Drawing.Size(195, 35);
            this.RemoveFriendButton.TabIndex = 33;
            this.RemoveFriendButton.Text = "Usuń z listy znajomych";
            this.RemoveFriendButton.UseVisualStyleBackColor = true;
            this.RemoveFriendButton.Click += new System.EventHandler(this.RemoveFriendButton_Click);
            // 
            // DeleteFromBlacklistButton
            // 
            this.DeleteFromBlacklistButton.Location = new System.Drawing.Point(6, 244);
            this.DeleteFromBlacklistButton.Name = "DeleteFromBlacklistButton";
            this.DeleteFromBlacklistButton.Size = new System.Drawing.Size(195, 35);
            this.DeleteFromBlacklistButton.TabIndex = 34;
            this.DeleteFromBlacklistButton.Text = "Usuń z czarnej listy";
            this.DeleteFromBlacklistButton.UseVisualStyleBackColor = true;
            this.DeleteFromBlacklistButton.Click += new System.EventHandler(this.DeleteFromBlacklistButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VoIP.WinFormsUserInterface.Properties.Resources.yeti2;
            this.pictureBox1.Location = new System.Drawing.Point(19, 302);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(124)))), ((int)(((byte)(153)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DeleteFromBlacklistButton);
            this.Controls.Add(this.RemoveFriendButton);
            this.Controls.Add(this.AddFriendButton);
            this.Controls.Add(this.BlockButton);
            this.Controls.Add(this.callHistoryListView);
            this.Controls.Add(this.blacklistListBox);
            this.Controls.Add(this.ListBoxLabel);
            this.Controls.Add(this.friendsListBox);
            this.Controls.Add(this.ClearHistoryButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.BlackListButton);
            this.Controls.Add(this.FriendsButton);
            this.Controls.Add(this.tbConnection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCall);
            this.Name = "MainPanel";
            this.Size = new System.Drawing.Size(900, 485);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Button ClearHistoryButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button BlackListButton;
        private System.Windows.Forms.Button FriendsButton;
        private System.Windows.Forms.ListBox friendsListBox;
        private System.Windows.Forms.Label ListBoxLabel;
        private System.Windows.Forms.ListBox blacklistListBox;
        private System.Windows.Forms.ListView callHistoryListView;
        private System.Windows.Forms.ColumnHeader emailColHistoryListView;
        private System.Windows.Forms.ColumnHeader durationColHistoryListView;
        private System.Windows.Forms.ColumnHeader dateColHistoryListView;
        private System.Windows.Forms.ColumnHeader indexColHistoryLivtView;
        private System.Windows.Forms.Button BlockButton;
        private System.Windows.Forms.Button AddFriendButton;
        private System.Windows.Forms.Button RemoveFriendButton;
        private System.Windows.Forms.Button DeleteFromBlacklistButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
