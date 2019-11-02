namespace Chat_Virtual___Cliente.Frontend {
    partial class SingUpView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingUpView));
            this.topPane = new System.Windows.Forms.Panel();
            this.closeButtonPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.PictureBox();
            this.minButtonPanel = new System.Windows.Forms.Panel();
            this.minButton = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelRepeatPassword = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.passwordRepeat = new System.Windows.Forms.TextBox();
            this.SingUp = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.LinkLabel();
            this.labelLastName = new System.Windows.Forms.Label();
            this.userLastName = new System.Windows.Forms.TextBox();
            this.ServerDisconnected = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.Refresh = new System.ComponentModel.BackgroundWorker();
            this.DragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.topPane.SuspendLayout();
            this.closeButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            this.minButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // topPane
            // 
            this.topPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))));
            this.topPane.Controls.Add(this.closeButtonPanel);
            this.topPane.Controls.Add(this.minButtonPanel);
            this.topPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPane.Location = new System.Drawing.Point(0, 0);
            this.topPane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.topPane.Name = "topPane";
            this.topPane.Size = new System.Drawing.Size(860, 52);
            this.topPane.TabIndex = 5;
            // 
            // closeButtonPanel
            // 
            this.closeButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.closeButtonPanel.Controls.Add(this.exitButton);
            this.closeButtonPanel.Location = new System.Drawing.Point(808, 0);
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
            // 
            // minButtonPanel
            // 
            this.minButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.minButtonPanel.Controls.Add(this.minButton);
            this.minButtonPanel.Location = new System.Drawing.Point(760, 0);
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
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(312, 80);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelPassword.Location = new System.Drawing.Point(132, 345);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(142, 29);
            this.labelPassword.TabIndex = 17;
            this.labelPassword.Text = "Contraseña:";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelUser.Location = new System.Drawing.Point(132, 298);
            this.labelUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(102, 29);
            this.labelUser.TabIndex = 16;
            this.labelUser.Text = "Usuario:";
            // 
            // user
            // 
            this.user.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.user.Location = new System.Drawing.Point(273, 295);
            this.user.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(398, 33);
            this.user.TabIndex = 3;
            // 
            // userName
            // 
            this.userName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.userName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userName.Location = new System.Drawing.Point(273, 203);
            this.userName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(398, 33);
            this.userName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelName.Location = new System.Drawing.Point(132, 206);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(119, 29);
            this.labelName.TabIndex = 18;
            this.labelName.Text = "Nombres:";
            // 
            // labelRepeatPassword
            // 
            this.labelRepeatPassword.AutoSize = true;
            this.labelRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRepeatPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelRepeatPassword.Location = new System.Drawing.Point(132, 391);
            this.labelRepeatPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRepeatPassword.Name = "labelRepeatPassword";
            this.labelRepeatPassword.Size = new System.Drawing.Size(222, 29);
            this.labelRepeatPassword.TabIndex = 19;
            this.labelRepeatPassword.Text = "Repetir contraseña:";
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.password.Location = new System.Drawing.Point(273, 342);
            this.password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(400, 33);
            this.password.TabIndex = 4;
            this.password.UseSystemPasswordChar = true;
            // 
            // passwordRepeat
            // 
            this.passwordRepeat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.passwordRepeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordRepeat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.passwordRepeat.Location = new System.Drawing.Point(346, 388);
            this.passwordRepeat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordRepeat.Name = "passwordRepeat";
            this.passwordRepeat.Size = new System.Drawing.Size(326, 33);
            this.passwordRepeat.TabIndex = 5;
            this.passwordRepeat.UseSystemPasswordChar = true;
            // 
            // SingUp
            // 
            this.SingUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SingUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SingUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SingUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SingUp.Location = new System.Drawing.Point(534, 434);
            this.SingUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SingUp.Name = "SingUp";
            this.SingUp.Size = new System.Drawing.Size(140, 42);
            this.SingUp.TabIndex = 6;
            this.SingUp.Text = "Registrarse";
            this.SingUp.UseVisualStyleBackColor = false;
            this.SingUp.Click += new System.EventHandler(this.SingUp_Click);
            // 
            // Back
            // 
            this.Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Back.AutoSize = true;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back.LinkColor = System.Drawing.Color.DarkCyan;
            this.Back.Location = new System.Drawing.Point(18, 560);
            this.Back.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(81, 29);
            this.Back.TabIndex = 7;
            this.Back.TabStop = true;
            this.Back.Text = "Volver";
            this.Back.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Back_LinkClicked);
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelLastName.Location = new System.Drawing.Point(132, 252);
            this.labelLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(114, 29);
            this.labelLastName.TabIndex = 25;
            this.labelLastName.Text = "Apellidos";
            // 
            // userLastName
            // 
            this.userLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.userLastName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userLastName.Location = new System.Drawing.Point(273, 249);
            this.userLastName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userLastName.Name = "userLastName";
            this.userLastName.Size = new System.Drawing.Size(398, 33);
            this.userLastName.TabIndex = 2;
            // 
            // ServerDisconnected
            // 
            this.ServerDisconnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerDisconnected.AutoSize = true;
            this.ServerDisconnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerDisconnected.ForeColor = System.Drawing.Color.DarkRed;
            this.ServerDisconnected.Location = new System.Drawing.Point(501, 560);
            this.ServerDisconnected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServerDisconnected.Name = "ServerDisconnected";
            this.ServerDisconnected.Size = new System.Drawing.Size(378, 29);
            this.ServerDisconnected.TabIndex = 27;
            this.ServerDisconnected.Text = "Usted se encuentra desconectado";
            this.ServerDisconnected.Visible = false;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLabel.Location = new System.Drawing.Point(132, 500);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(195, 29);
            this.errorLabel.TabIndex = 26;
            this.errorLabel.Text = "Aqui hay un label";
            this.errorLabel.Visible = false;
            // 
            // Refresh
            // 
            this.Refresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Refresh_DoWork);
            // 
            // DragControl
            // 
            this.DragControl.Fixed = true;
            this.DragControl.Horizontal = true;
            this.DragControl.TargetControl = this.topPane;
            this.DragControl.Vertical = true;
            // 
            // SingUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(860, 602);
            this.Controls.Add(this.ServerDisconnected);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.userLastName);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.SingUp);
            this.Controls.Add(this.passwordRepeat);
            this.Controls.Add(this.password);
            this.Controls.Add(this.labelRepeatPassword);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.user);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.topPane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SingUpView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SingUpView";
            this.topPane.ResumeLayout(false);
            this.closeButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            this.minButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPane;
        private System.Windows.Forms.Panel closeButtonPanel;
        private System.Windows.Forms.PictureBox exitButton;
        private System.Windows.Forms.Panel minButtonPanel;
        private System.Windows.Forms.PictureBox minButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelRepeatPassword;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox passwordRepeat;
        private System.Windows.Forms.Button SingUp;
        private System.Windows.Forms.LinkLabel Back;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox userLastName;
        private System.Windows.Forms.Label ServerDisconnected;
        private System.Windows.Forms.Label errorLabel;
        private System.ComponentModel.BackgroundWorker Refresh;
        private Bunifu.Framework.UI.BunifuDragControl DragControl;
    }
}