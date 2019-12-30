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
            this.LTitleBar = new System.Windows.Forms.Label();
            this.closeButtonPanel = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.minButtonPanel = new System.Windows.Forms.Panel();
            this.MinButton = new System.Windows.Forms.PictureBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.User = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelRepeatPassword = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.PasswordRepeat = new System.Windows.Forms.TextBox();
            this.SingUp = new System.Windows.Forms.Button();
            this.LBack = new System.Windows.Forms.LinkLabel();
            this.labelLastName = new System.Windows.Forms.Label();
            this.UserLastName = new System.Windows.Forms.TextBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.DragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.AppIcon = new System.Windows.Forms.PictureBox();
            this.PBSadiri = new System.Windows.Forms.PictureBox();
            this.topPane.SuspendLayout();
            this.closeButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            this.minButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBSadiri)).BeginInit();
            this.SuspendLayout();
            // 
            // topPane
            // 
            this.topPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))));
            this.topPane.Controls.Add(this.LTitleBar);
            this.topPane.Controls.Add(this.closeButtonPanel);
            this.topPane.Controls.Add(this.minButtonPanel);
            this.topPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPane.Location = new System.Drawing.Point(0, 0);
            this.topPane.Name = "topPane";
            this.topPane.Size = new System.Drawing.Size(573, 34);
            this.topPane.TabIndex = 5;
            // 
            // LTitleBar
            // 
            this.LTitleBar.AutoSize = true;
            this.LTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitleBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LTitleBar.Location = new System.Drawing.Point(40, 9);
            this.LTitleBar.Name = "LTitleBar";
            this.LTitleBar.Size = new System.Drawing.Size(146, 18);
            this.LTitleBar.TabIndex = 29;
            this.LTitleBar.Text = "Registrate en SADIRI";
            // 
            // closeButtonPanel
            // 
            this.closeButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.closeButtonPanel.Controls.Add(this.ExitButton);
            this.closeButtonPanel.Location = new System.Drawing.Point(539, 0);
            this.closeButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.closeButtonPanel.Name = "closeButtonPanel";
            this.closeButtonPanel.Size = new System.Drawing.Size(32, 34);
            this.closeButtonPanel.TabIndex = 14;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Close_Window__2_48px;
            this.ExitButton.Location = new System.Drawing.Point(4, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(25, 25);
            this.ExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExitButton.TabIndex = 5;
            this.ExitButton.TabStop = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // minButtonPanel
            // 
            this.minButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.minButtonPanel.Controls.Add(this.MinButton);
            this.minButtonPanel.Location = new System.Drawing.Point(507, 0);
            this.minButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.minButtonPanel.Name = "minButtonPanel";
            this.minButtonPanel.Size = new System.Drawing.Size(32, 34);
            this.minButtonPanel.TabIndex = 13;
            // 
            // MinButton
            // 
            this.MinButton.BackColor = System.Drawing.Color.Transparent;
            this.MinButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Minimize_Window_2_48px;
            this.MinButton.Location = new System.Drawing.Point(3, 3);
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(25, 25);
            this.MinButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MinButton.TabIndex = 7;
            this.MinButton.TabStop = false;
            this.MinButton.Click += new System.EventHandler(this.MinButton_Click);
            this.MinButton.MouseEnter += new System.EventHandler(this.MinButton_MouseEnter);
            this.MinButton.MouseLeave += new System.EventHandler(this.MinButton_MouseLeave);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelPassword.Location = new System.Drawing.Point(96, 252);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(89, 18);
            this.labelPassword.TabIndex = 17;
            this.labelPassword.Text = "Contraseña:";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelUser.Location = new System.Drawing.Point(96, 222);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(64, 18);
            this.labelUser.TabIndex = 16;
            this.labelUser.Text = "Usuario:";
            // 
            // User
            // 
            this.User.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.User.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.User.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.User.Location = new System.Drawing.Point(190, 220);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(266, 24);
            this.User.TabIndex = 3;
            // 
            // userName
            // 
            this.userName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.userName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userName.Location = new System.Drawing.Point(190, 160);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(266, 24);
            this.userName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelName.Location = new System.Drawing.Point(96, 162);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(74, 18);
            this.labelName.TabIndex = 18;
            this.labelName.Text = "Nombres:";
            // 
            // labelRepeatPassword
            // 
            this.labelRepeatPassword.AutoSize = true;
            this.labelRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRepeatPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelRepeatPassword.Location = new System.Drawing.Point(96, 282);
            this.labelRepeatPassword.Name = "labelRepeatPassword";
            this.labelRepeatPassword.Size = new System.Drawing.Size(137, 18);
            this.labelRepeatPassword.TabIndex = 19;
            this.labelRepeatPassword.Text = "Repetir contraseña:";
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Password.Location = new System.Drawing.Point(190, 250);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(267, 24);
            this.Password.TabIndex = 4;
            this.Password.UseSystemPasswordChar = true;
            // 
            // PasswordRepeat
            // 
            this.PasswordRepeat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PasswordRepeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordRepeat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PasswordRepeat.Location = new System.Drawing.Point(239, 280);
            this.PasswordRepeat.Name = "PasswordRepeat";
            this.PasswordRepeat.Size = new System.Drawing.Size(218, 24);
            this.PasswordRepeat.TabIndex = 5;
            this.PasswordRepeat.UseSystemPasswordChar = true;
            // 
            // SingUp
            // 
            this.SingUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SingUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SingUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SingUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SingUp.Location = new System.Drawing.Point(364, 310);
            this.SingUp.Name = "SingUp";
            this.SingUp.Size = new System.Drawing.Size(93, 27);
            this.SingUp.TabIndex = 6;
            this.SingUp.Text = "Registrarse";
            this.SingUp.UseVisualStyleBackColor = false;
            this.SingUp.Click += new System.EventHandler(this.SingUp_Click);
            // 
            // LBack
            // 
            this.LBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LBack.AutoSize = true;
            this.LBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBack.LinkColor = System.Drawing.Color.DarkCyan;
            this.LBack.Location = new System.Drawing.Point(56, 343);
            this.LBack.Name = "LBack";
            this.LBack.Size = new System.Drawing.Size(49, 18);
            this.LBack.TabIndex = 7;
            this.LBack.TabStop = true;
            this.LBack.Text = "Volver";
            this.LBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Back_LinkClicked);
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelLastName.Location = new System.Drawing.Point(96, 192);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(67, 18);
            this.labelLastName.TabIndex = 25;
            this.labelLastName.Text = "Apellidos";
            // 
            // UserLastName
            // 
            this.UserLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UserLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.UserLastName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UserLastName.Location = new System.Drawing.Point(190, 190);
            this.UserLastName.Name = "UserLastName";
            this.UserLastName.Size = new System.Drawing.Size(266, 24);
            this.UserLastName.TabIndex = 2;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ErrorLabel.Location = new System.Drawing.Point(88, 325);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 18);
            this.ErrorLabel.TabIndex = 26;
            this.ErrorLabel.Visible = false;
            // 
            // DragControl
            // 
            this.DragControl.Fixed = true;
            this.DragControl.Horizontal = true;
            this.DragControl.TargetControl = this.topPane;
            this.DragControl.Vertical = true;
            // 
            // AppIcon
            // 
            this.AppIcon.Image = global::Chat_Virtual___Cliente.Properties.Resources.SadiriLogo2;
            this.AppIcon.Location = new System.Drawing.Point(0, 0);
            this.AppIcon.Margin = new System.Windows.Forms.Padding(2);
            this.AppIcon.Name = "AppIcon";
            this.AppIcon.Size = new System.Drawing.Size(35, 32);
            this.AppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AppIcon.TabIndex = 28;
            this.AppIcon.TabStop = false;
            // 
            // PBSadiri
            // 
            this.PBSadiri.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PBSadiri.Image = ((System.Drawing.Image)(resources.GetObject("PBSadiri.Image")));
            this.PBSadiri.Location = new System.Drawing.Point(215, 73);
            this.PBSadiri.Name = "PBSadiri";
            this.PBSadiri.Size = new System.Drawing.Size(181, 60);
            this.PBSadiri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PBSadiri.TabIndex = 13;
            this.PBSadiri.TabStop = false;
            // 
            // SingUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(573, 391);
            this.Controls.Add(this.LBack);
            this.Controls.Add(this.SingUp);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.AppIcon);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.UserLastName);
            this.Controls.Add(this.PasswordRepeat);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.labelRepeatPassword);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.User);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.PBSadiri);
            this.Controls.Add(this.topPane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SingUpView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SingUpView";
            this.topPane.ResumeLayout(false);
            this.topPane.PerformLayout();
            this.closeButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            this.minButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MinButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBSadiri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPane;
        private System.Windows.Forms.Panel closeButtonPanel;
        private System.Windows.Forms.PictureBox ExitButton;
        private System.Windows.Forms.Panel minButtonPanel;
        private System.Windows.Forms.PictureBox MinButton;
        private System.Windows.Forms.PictureBox PBSadiri;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox User;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelRepeatPassword;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox PasswordRepeat;
        private System.Windows.Forms.Button SingUp;
        private System.Windows.Forms.LinkLabel LBack;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox UserLastName;
        private System.Windows.Forms.Label ErrorLabel;
        private Bunifu.Framework.UI.BunifuDragControl DragControl;
        private System.Windows.Forms.PictureBox AppIcon;
        private System.Windows.Forms.Label LTitleBar;
    }
}