using ShippingData;
using static ShippingData.Message;

namespace Chat_Virtual___Cliente.Frontend {
    partial class HomeView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeView));
            this.topPane = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.resizeButtonPanel = new System.Windows.Forms.Panel();
            this.resizeButton = new System.Windows.Forms.PictureBox();
            this.closeButtonPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.PictureBox();
            this.minButtonPanel = new System.Windows.Forms.Panel();
            this.minButton = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.ChatBoxPanel = new System.Windows.Forms.Panel();
            this.chat = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.PictureBox();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.ViewPanel = new System.Windows.Forms.Panel();
            this.descriptionPanel = new System.Windows.Forms.Panel();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.TreeButton = new System.Windows.Forms.PictureBox();
            this.Profile = new System.Windows.Forms.PictureBox();
            this.Settings = new System.Windows.Forms.PictureBox();
            this.Chats = new System.Windows.Forms.PictureBox();
            this.Groups = new System.Windows.Forms.PictureBox();
            this.Home = new System.Windows.Forms.PictureBox();
            this.receptor = new System.ComponentModel.BackgroundWorker();
            this.MainDrag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.ActionPanelScroll = new System.Windows.Forms.VScrollBar();
            this.ViewPanelScroll = new System.Windows.Forms.VScrollBar();
            this.topPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.resizeButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resizeButton)).BeginInit();
            this.closeButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            this.minButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.ChatBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sendButton)).BeginInit();
            this.ViewPanel.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Profile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Groups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Home)).BeginInit();
            this.SuspendLayout();
            // 
            // topPane
            // 
            this.topPane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))));
            this.topPane.Controls.Add(this.pictureBox1);
            this.topPane.Controls.Add(this.resizeButtonPanel);
            this.topPane.Controls.Add(this.closeButtonPanel);
            this.topPane.Controls.Add(this.minButtonPanel);
            this.topPane.Location = new System.Drawing.Point(0, 0);
            this.topPane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.topPane.MinimumSize = new System.Drawing.Size(750, 52);
            this.topPane.Name = "topPane";
            this.topPane.Size = new System.Drawing.Size(1500, 52);
            this.topPane.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Chat_Virtual___Cliente.Properties.Resources.SadiriLogo2;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // resizeButtonPanel
            // 
            this.resizeButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resizeButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.resizeButtonPanel.Controls.Add(this.resizeButton);
            this.resizeButtonPanel.Location = new System.Drawing.Point(1402, 0);
            this.resizeButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.resizeButtonPanel.Name = "resizeButtonPanel";
            this.resizeButtonPanel.Size = new System.Drawing.Size(48, 52);
            this.resizeButtonPanel.TabIndex = 14;
            // 
            // resizeButton
            // 
            this.resizeButton.BackColor = System.Drawing.Color.Transparent;
            this.resizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resizeButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Maximize_Window_2_48px;
            this.resizeButton.Location = new System.Drawing.Point(4, 5);
            this.resizeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(38, 38);
            this.resizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resizeButton.TabIndex = 7;
            this.resizeButton.TabStop = false;
            this.resizeButton.Click += new System.EventHandler(this.ResizeButton_Click);
            this.resizeButton.MouseEnter += new System.EventHandler(this.ResizeButton_MouseEnter);
            this.resizeButton.MouseLeave += new System.EventHandler(this.ResizeButton_MouseLeave);
            // 
            // closeButtonPanel
            // 
            this.closeButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.closeButtonPanel.Controls.Add(this.exitButton);
            this.closeButtonPanel.Location = new System.Drawing.Point(1449, 0);
            this.closeButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.closeButtonPanel.Name = "closeButtonPanel";
            this.closeButtonPanel.Size = new System.Drawing.Size(48, 52);
            this.closeButtonPanel.TabIndex = 14;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Close_Window__2_48px;
            this.exitButton.Location = new System.Drawing.Point(6, 5);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(38, 38);
            this.exitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitButton.TabIndex = 5;
            this.exitButton.TabStop = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.exitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // minButtonPanel
            // 
            this.minButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.minButtonPanel.Controls.Add(this.minButton);
            this.minButtonPanel.Location = new System.Drawing.Point(1354, 0);
            this.minButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.minButtonPanel.Name = "minButtonPanel";
            this.minButtonPanel.Size = new System.Drawing.Size(48, 52);
            this.minButtonPanel.TabIndex = 13;
            // 
            // minButton
            // 
            this.minButton.BackColor = System.Drawing.Color.Transparent;
            this.minButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Minimize_Window_2_48px;
            this.minButton.Location = new System.Drawing.Point(4, 5);
            this.minButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.minButton.Name = "minButton";
            this.minButton.Size = new System.Drawing.Size(38, 38);
            this.minButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minButton.TabIndex = 7;
            this.minButton.TabStop = false;
            this.minButton.Click += new System.EventHandler(this.MinButton_Click);
            this.minButton.MouseEnter += new System.EventHandler(this.MinButton_MouseEnter);
            this.minButton.MouseLeave += new System.EventHandler(this.MinButton_MouseLeave);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.ChatBoxPanel);
            this.mainPanel.Controls.Add(this.InfoPanel);
            this.mainPanel.Controls.Add(this.ViewPanel);
            this.mainPanel.Controls.Add(this.descriptionPanel);
            this.mainPanel.Controls.Add(this.actionPanel);
            this.mainPanel.Controls.Add(this.optionsPanel);
            this.mainPanel.Location = new System.Drawing.Point(0, 52);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1728, 1142);
            this.mainPanel.TabIndex = 0;
            // 
            // ChatBoxPanel
            // 
            this.ChatBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatBoxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChatBoxPanel.Controls.Add(this.chat);
            this.ChatBoxPanel.Controls.Add(this.sendButton);
            this.ChatBoxPanel.Location = new System.Drawing.Point(484, 809);
            this.ChatBoxPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ChatBoxPanel.Name = "ChatBoxPanel";
            this.ChatBoxPanel.Size = new System.Drawing.Size(1016, 62);
            this.ChatBoxPanel.TabIndex = 5;
            this.ChatBoxPanel.Visible = false;
            // 
            // chat
            // 
            this.chat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chat.ForeColor = System.Drawing.SystemColors.Window;
            this.chat.Location = new System.Drawing.Point(16, 11);
            this.chat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chat.Multiline = true;
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(928, 34);
            this.chat.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.Image = ((System.Drawing.Image)(resources.GetObject("sendButton.Image")));
            this.sendButton.Location = new System.Drawing.Point(957, 11);
            this.sendButton.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(33, 34);
            this.sendButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sendButton.TabIndex = 0;
            this.sendButton.TabStop = false;
            this.sendButton.Click += new System.EventHandler(this.Send_Click);
            // 
            // InfoPanel
            // 
            this.InfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
            this.InfoPanel.Location = new System.Drawing.Point(120, 0);
            this.InfoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(1380, 92);
            this.InfoPanel.TabIndex = 4;
            // 
            // ViewPanel
            // 
            this.ViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewPanel.AutoScroll = true;
            this.ViewPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ViewPanel.Controls.Add(this.ViewPanelScroll);
            this.ViewPanel.Location = new System.Drawing.Point(484, 92);
            this.ViewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ViewPanel.MinimumSize = new System.Drawing.Size(0, 405);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(1016, 778);
            this.ViewPanel.TabIndex = 2;
            this.ViewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPanel_Paint);
            // 
            // descriptionPanel
            // 
            this.descriptionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionPanel.AutoScroll = true;
            this.descriptionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
            this.descriptionPanel.Location = new System.Drawing.Point(1503, 92);
            this.descriptionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.descriptionPanel.MinimumSize = new System.Drawing.Size(150, 405);
            this.descriptionPanel.Name = "descriptionPanel";
            this.descriptionPanel.Size = new System.Drawing.Size(225, 1049);
            this.descriptionPanel.TabIndex = 3;
            this.descriptionPanel.Visible = false;
            // 
            // actionPanel
            // 
            this.actionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.actionPanel.AutoScroll = true;
            this.actionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
            this.actionPanel.Controls.Add(this.ActionPanelScroll);
            this.actionPanel.Location = new System.Drawing.Point(120, 92);
            this.actionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.actionPanel.MinimumSize = new System.Drawing.Size(180, 405);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(364, 778);
            this.actionPanel.TabIndex = 1;
            // 
            // optionsPanel
            // 
            this.optionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.optionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))));
            this.optionsPanel.Controls.Add(this.TreeButton);
            this.optionsPanel.Controls.Add(this.Profile);
            this.optionsPanel.Controls.Add(this.Settings);
            this.optionsPanel.Controls.Add(this.Chats);
            this.optionsPanel.Controls.Add(this.Groups);
            this.optionsPanel.Controls.Add(this.Home);
            this.optionsPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.optionsPanel.MinimumSize = new System.Drawing.Size(120, 405);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(120, 871);
            this.optionsPanel.TabIndex = 0;
            // 
            // TreeButton
            // 
            this.TreeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TreeButton.ErrorImage = null;
            this.TreeButton.Image = ((System.Drawing.Image)(resources.GetObject("TreeButton.Image")));
            this.TreeButton.InitialImage = null;
            this.TreeButton.Location = new System.Drawing.Point(8, 382);
            this.TreeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TreeButton.Name = "TreeButton";
            this.TreeButton.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.TreeButton.Size = new System.Drawing.Size(105, 108);
            this.TreeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TreeButton.TabIndex = 5;
            this.TreeButton.TabStop = false;
            this.TreeButton.Click += new System.EventHandler(this.TreeButton_Click);
            // 
            // Profile
            // 
            this.Profile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Profile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Profile.Image = ((System.Drawing.Image)(resources.GetObject("Profile.Image")));
            this.Profile.Location = new System.Drawing.Point(8, 635);
            this.Profile.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Profile.Name = "Profile";
            this.Profile.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Profile.Size = new System.Drawing.Size(105, 108);
            this.Profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Profile.TabIndex = 1;
            this.Profile.TabStop = false;
            this.Profile.Click += new System.EventHandler(this.Options_Click);
            // 
            // Settings
            // 
            this.Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Settings.Image = ((System.Drawing.Image)(resources.GetObject("Settings.Image")));
            this.Settings.Location = new System.Drawing.Point(8, 754);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Settings.Size = new System.Drawing.Size(105, 108);
            this.Settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Settings.TabIndex = 4;
            this.Settings.TabStop = false;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Chats
            // 
            this.Chats.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Chats.Image = global::Chat_Virtual___Cliente.Properties.Resources.Menu_48px;
            this.Chats.Location = new System.Drawing.Point(8, 131);
            this.Chats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Chats.Name = "Chats";
            this.Chats.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Chats.Size = new System.Drawing.Size(105, 108);
            this.Chats.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Chats.TabIndex = 2;
            this.Chats.TabStop = false;
            this.Chats.Click += new System.EventHandler(this.Chats_Click);
            // 
            // Groups
            // 
            this.Groups.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Groups.ErrorImage = null;
            this.Groups.Image = ((System.Drawing.Image)(resources.GetObject("Groups.Image")));
            this.Groups.InitialImage = null;
            this.Groups.Location = new System.Drawing.Point(8, 254);
            this.Groups.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Groups.Name = "Groups";
            this.Groups.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Groups.Size = new System.Drawing.Size(105, 108);
            this.Groups.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Groups.TabIndex = 3;
            this.Groups.TabStop = false;
            this.Groups.Click += new System.EventHandler(this.Groups_Click);
            // 
            // Home
            // 
            this.Home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Home.Image = ((System.Drawing.Image)(resources.GetObject("Home.Image")));
            this.Home.Location = new System.Drawing.Point(8, 8);
            this.Home.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Home.Size = new System.Drawing.Size(105, 108);
            this.Home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Home.TabIndex = 0;
            this.Home.TabStop = false;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // receptor
            // 
            this.receptor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Receptor_DoWork);
            // 
            // MainDrag
            // 
            this.MainDrag.Fixed = true;
            this.MainDrag.Horizontal = true;
            this.MainDrag.TargetControl = this.topPane;
            this.MainDrag.Vertical = true;
            // 
            // ActionPanelScroll
            // 
            this.ActionPanelScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.ActionPanelScroll.Enabled = false;
            this.ActionPanelScroll.Location = new System.Drawing.Point(338, 0);
            this.ActionPanelScroll.Name = "ActionPanelScroll";
            this.ActionPanelScroll.Size = new System.Drawing.Size(26, 778);
            this.ActionPanelScroll.TabIndex = 0;
            // 
            // ViewPanelScroll
            // 
            this.ViewPanelScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.ViewPanelScroll.Enabled = false;
            this.ViewPanelScroll.Location = new System.Drawing.Point(990, 0);
            this.ViewPanelScroll.Name = "ViewPanelScroll";
            this.ViewPanelScroll.Size = new System.Drawing.Size(26, 778);
            this.ViewPanelScroll.TabIndex = 0;
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1500, 923);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(750, 462);
            this.Name = "HomeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeView";
            this.topPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.resizeButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resizeButton)).EndInit();
            this.closeButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            this.minButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ChatBoxPanel.ResumeLayout(false);
            this.ChatBoxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sendButton)).EndInit();
            this.ViewPanel.ResumeLayout(false);
            this.actionPanel.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Profile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Groups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Home)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPane;
        private System.Windows.Forms.Panel closeButtonPanel;
        private System.Windows.Forms.PictureBox exitButton;
        private System.Windows.Forms.Panel minButtonPanel;
        private System.Windows.Forms.PictureBox minButton;
        private System.Windows.Forms.Panel resizeButtonPanel;
        private System.Windows.Forms.PictureBox resizeButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel ViewPanel;
        private System.Windows.Forms.Panel descriptionPanel;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.PictureBox Chats;
        private System.Windows.Forms.PictureBox Profile;
        private System.Windows.Forms.PictureBox Home;
        private System.Windows.Forms.PictureBox Groups;
        private System.ComponentModel.BackgroundWorker receptor;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Settings;
        private Bunifu.Framework.UI.BunifuDragControl MainDrag;
        private System.Windows.Forms.PictureBox TreeButton;
        
        private void Tester() {
            model.singleton.userName = "Fededin";
            string[] chats = {"Juan", "Pedro", "Pablo", "Sebastiasn", "Carlos" };
            for(int i = 0; i<5; i++) {
                ShippingData.Profile p = new ShippingData.Profile();
                p.Name = chats[i];
                model.ToReadEnqueue(new Chat("Tu", p, false));
            }
            for(int i = 0; i<5; i++) {
                ChatMessage ms = new ChatMessage();
                ms.Sender = chats[i];
                ms.Receiver = model.singleton.userName;
                ms.Content = "Hey, i'm using SADIRI";
                ms.date = new Date(System.DateTime.Now);
                model.ToReadEnqueue(ms);
            }
        }

        private System.Windows.Forms.Panel ChatBoxPanel;
        private System.Windows.Forms.TextBox chat;
        private System.Windows.Forms.PictureBox sendButton;
        private System.Windows.Forms.VScrollBar ViewPanelScroll;
        private System.Windows.Forms.VScrollBar ActionPanelScroll;
    }
}