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
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.ViewPanel = new System.Windows.Forms.Panel();
            this.descriptionPanel = new System.Windows.Forms.Panel();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.Profile = new System.Windows.Forms.PictureBox();
            this.Settings = new System.Windows.Forms.PictureBox();
            this.Chats = new System.Windows.Forms.PictureBox();
            this.Groups = new System.Windows.Forms.PictureBox();
            this.Home = new System.Windows.Forms.PictureBox();
            this.receptor = new System.ComponentModel.BackgroundWorker();
            this.MainDrag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.topPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.resizeButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resizeButton)).BeginInit();
            this.closeButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            this.minButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
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
            this.mainPanel.Controls.Add(this.InfoPanel);
            this.mainPanel.Controls.Add(this.ViewPanel);
            this.mainPanel.Controls.Add(this.descriptionPanel);
            this.mainPanel.Controls.Add(this.actionPanel);
            this.mainPanel.Controls.Add(this.optionsPanel);
            this.mainPanel.Location = new System.Drawing.Point(0, 52);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1614, 1006);
            this.mainPanel.TabIndex = 0;
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
            this.ViewPanel.Location = new System.Drawing.Point(484, 92);
            this.ViewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ViewPanel.MinimumSize = new System.Drawing.Size(0, 405);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(1016, 778);
            this.ViewPanel.TabIndex = 2;
            // 
            // descriptionPanel
            // 
            this.descriptionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionPanel.AutoScroll = true;
            this.descriptionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
            this.descriptionPanel.Location = new System.Drawing.Point(1389, 92);
            this.descriptionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.descriptionPanel.MinimumSize = new System.Drawing.Size(150, 405);
            this.descriptionPanel.Name = "descriptionPanel";
            this.descriptionPanel.Size = new System.Drawing.Size(225, 914);
            this.descriptionPanel.TabIndex = 3;
            this.descriptionPanel.Visible = false;
            // 
            // actionPanel
            // 
            this.actionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.actionPanel.AutoScroll = true;
            this.actionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
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
            this.Profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Profile.TabIndex = 1;
            this.Profile.TabStop = false;
            this.Profile.Click += new System.EventHandler(this.Options_Click);
            // 
            // Settings
            // 
            this.Settings.Image = global::Chat_Virtual___Cliente.Properties.Resources.Settingss;
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
            this.Home.Image = global::Chat_Virtual___Cliente.Properties.Resources.Home;
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
            this.optionsPanel.ResumeLayout(false);
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
    }
}