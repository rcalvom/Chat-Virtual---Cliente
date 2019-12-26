namespace Chat_Virtual___Cliente {
    partial class LoginWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginWindow));
            this.user = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.SingIn = new System.Windows.Forms.Button();
            this.topPane = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.closeButtonPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.PictureBox();
            this.minButtonPanel = new System.Windows.Forms.Panel();
            this.minButton = new System.Windows.Forms.PictureBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.DragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.errorLabel = new System.Windows.Forms.Label();
            this.Refresh = new System.ComponentModel.BackgroundWorker();
            this.ServerDisconnected = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SingUp = new System.Windows.Forms.LinkLabel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.topPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.closeButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            this.minButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // user
            // 
            this.user.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.user.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.user.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.user.Location = new System.Drawing.Point(168, 133);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(267, 24);
            this.user.TabIndex = 0;
            this.user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.User_KeyPress);
            // 
            // password
            // 
            this.password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.password.Location = new System.Drawing.Point(168, 163);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(267, 24);
            this.password.TabIndex = 1;
            this.password.UseSystemPasswordChar = true;
            this.password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Password_KeyPress);
            // 
            // SingIn
            // 
            this.SingIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SingIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SingIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SingIn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SingIn.FlatAppearance.BorderSize = 0;
            this.SingIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SingIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SingIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SingIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SingIn.Location = new System.Drawing.Point(323, 193);
            this.SingIn.Name = "SingIn";
            this.SingIn.Size = new System.Drawing.Size(112, 27);
            this.SingIn.TabIndex = 3;
            this.SingIn.Text = "Iniciar sesión";
            this.SingIn.UseVisualStyleBackColor = false;
            this.SingIn.Click += new System.EventHandler(this.SingIn_Click);
            // 
            // topPane
            // 
            this.topPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))));
            this.topPane.Controls.Add(this.pictureBox1);
            this.topPane.Controls.Add(this.closeButtonPanel);
            this.topPane.Controls.Add(this.minButtonPanel);
            this.topPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPane.Location = new System.Drawing.Point(0, 0);
            this.topPane.Name = "topPane";
            this.topPane.Size = new System.Drawing.Size(522, 34);
            this.topPane.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Chat_Virtual___Cliente.Properties.Resources.SadiriLogo2;
            this.pictureBox1.Location = new System.Drawing.Point(2, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // closeButtonPanel
            // 
            this.closeButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.closeButtonPanel.Controls.Add(this.exitButton);
            this.closeButtonPanel.Location = new System.Drawing.Point(488, 0);
            this.closeButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.closeButtonPanel.Name = "closeButtonPanel";
            this.closeButtonPanel.Size = new System.Drawing.Size(32, 34);
            this.closeButtonPanel.TabIndex = 14;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Close_Window__2_48px;
            this.exitButton.Location = new System.Drawing.Point(4, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 25);
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
            this.minButtonPanel.Location = new System.Drawing.Point(456, 0);
            this.minButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.minButtonPanel.Name = "minButtonPanel";
            this.minButtonPanel.Size = new System.Drawing.Size(32, 34);
            this.minButtonPanel.TabIndex = 13;
            // 
            // minButton
            // 
            this.minButton.BackColor = System.Drawing.Color.Transparent;
            this.minButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Minimize_Window_2_48px;
            this.minButton.Location = new System.Drawing.Point(3, 3);
            this.minButton.Name = "minButton";
            this.minButton.Size = new System.Drawing.Size(25, 25);
            this.minButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minButton.TabIndex = 7;
            this.minButton.TabStop = false;
            this.minButton.Click += new System.EventHandler(this.MinButton_Click);
            this.minButton.MouseEnter += new System.EventHandler(this.MinButton_MouseEnter);
            this.minButton.MouseLeave += new System.EventHandler(this.MinButton_MouseLeave);
            // 
            // labelUser
            // 
            this.labelUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelUser.Location = new System.Drawing.Point(73, 135);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(64, 18);
            this.labelUser.TabIndex = 5;
            this.labelUser.Text = "Usuario:";
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelPassword.Location = new System.Drawing.Point(73, 165);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(89, 18);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Contraseña:";
            // 
            // DragControl
            // 
            this.DragControl.Fixed = true;
            this.DragControl.Horizontal = true;
            this.DragControl.TargetControl = this.topPane;
            this.DragControl.Vertical = true;
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLabel.Location = new System.Drawing.Point(73, 263);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(117, 18);
            this.errorLabel.TabIndex = 11;
            this.errorLabel.Text = "Aqui hay un label";
            this.errorLabel.Visible = false;
            // 
            // Refresh
            // 
            this.Refresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Refresh_DoWork);
            // 
            // ServerDisconnected
            // 
            this.ServerDisconnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerDisconnected.AutoSize = true;
            this.ServerDisconnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerDisconnected.ForeColor = System.Drawing.Color.DarkRed;
            this.ServerDisconnected.Location = new System.Drawing.Point(276, 288);
            this.ServerDisconnected.Name = "ServerDisconnected";
            this.ServerDisconnected.Size = new System.Drawing.Size(234, 18);
            this.ServerDisconnected.TabIndex = 15;
            this.ServerDisconnected.Text = "Usted se encuentra desconectado";
            this.ServerDisconnected.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(74, 237);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "O puedes";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(220, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "si no tienes una cuenta aún.";
            // 
            // SingUp
            // 
            this.SingUp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SingUp.AutoSize = true;
            this.SingUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingUp.LinkColor = System.Drawing.Color.DarkCyan;
            this.SingUp.Location = new System.Drawing.Point(146, 237);
            this.SingUp.Margin = new System.Windows.Forms.Padding(0);
            this.SingUp.Name = "SingUp";
            this.SingUp.Size = new System.Drawing.Size(74, 18);
            this.SingUp.TabIndex = 18;
            this.SingUp.TabStop = true;
            this.SingUp.Text = "registrarte";
            this.SingUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SingUp_LinkClicked);
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(191, 65);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(181, 60);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Logo.TabIndex = 12;
            this.Logo.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Conectandose";
            this.notifyIcon1.Visible = true;
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(522, 315);
            this.Controls.Add(this.SingUp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerDisconnected);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.topPane);
            this.Controls.Add(this.SingIn);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user);
            this.Controls.Add(this.errorLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loggin";
            this.topPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.closeButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            this.minButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button SingIn;
        private System.Windows.Forms.Panel topPane;
        private System.Windows.Forms.PictureBox minButton;
        private System.Windows.Forms.PictureBox exitButton;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.PictureBox Logo;
        private Bunifu.Framework.UI.BunifuDragControl DragControl;
        private System.Windows.Forms.Panel minButtonPanel;
        private System.Windows.Forms.Panel closeButtonPanel;
        private System.Windows.Forms.Label errorLabel;
        private System.ComponentModel.BackgroundWorker Refresh;
        private System.Windows.Forms.Label ServerDisconnected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel SingUp;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}