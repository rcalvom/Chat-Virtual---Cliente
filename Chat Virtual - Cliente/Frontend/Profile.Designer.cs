namespace Chat_Virtual___Cliente.Frontend
{
    partial class Profile
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.LTitleBar = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.PictureBox();
            this.AppIcon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TBStatus = new System.Windows.Forms.TextBox();
            this.LTStatus = new System.Windows.Forms.Label();
            this.LabelUser = new System.Windows.Forms.Label();
            this.ChangePassword = new System.Windows.Forms.LinkLabel();
            this.ChangePicture = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.UserPicture = new System.Windows.Forms.PictureBox();
            this.ProfileDrag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppIcon)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChangePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))));
            this.TopPanel.Controls.Add(this.LTitleBar);
            this.TopPanel.Controls.Add(this.exitButton);
            this.TopPanel.Controls.Add(this.AppIcon);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(2);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(573, 37);
            this.TopPanel.TabIndex = 0;
            // 
            // LTitleBar
            // 
            this.LTitleBar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LTitleBar.AutoSize = true;
            this.LTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitleBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LTitleBar.Location = new System.Drawing.Point(42, 9);
            this.LTitleBar.Name = "LTitleBar";
            this.LTitleBar.Size = new System.Drawing.Size(41, 18);
            this.LTitleBar.TabIndex = 8;
            this.LTitleBar.Text = "Perfil";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Close_Window__2_48px;
            this.exitButton.Location = new System.Drawing.Point(536, 7);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 25);
            this.exitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitButton.TabIndex = 30;
            this.exitButton.TabStop = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.exitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // AppIcon
            // 
            this.AppIcon.Image = global::Chat_Virtual___Cliente.Properties.Resources.SadiriLogo2;
            this.AppIcon.Location = new System.Drawing.Point(2, 3);
            this.AppIcon.Margin = new System.Windows.Forms.Padding(2);
            this.AppIcon.Name = "AppIcon";
            this.AppIcon.Size = new System.Drawing.Size(35, 32);
            this.AppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AppIcon.TabIndex = 29;
            this.AppIcon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.panel1.Controls.Add(this.TBStatus);
            this.panel1.Controls.Add(this.LTStatus);
            this.panel1.Controls.Add(this.LabelUser);
            this.panel1.Controls.Add(this.ChangePassword);
            this.panel1.Controls.Add(this.ChangePicture);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.UserPicture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 354);
            this.panel1.TabIndex = 0;
            // 
            // TBStatus
            // 
            this.TBStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.TBStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TBStatus.Location = new System.Drawing.Point(207, 140);
            this.TBStatus.MaxLength = 50;
            this.TBStatus.Name = "TBStatus";
            this.TBStatus.Size = new System.Drawing.Size(354, 18);
            this.TBStatus.TabIndex = 10;
            // 
            // LTStatus
            // 
            this.LTStatus.AutoSize = true;
            this.LTStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LTStatus.Location = new System.Drawing.Point(204, 112);
            this.LTStatus.Name = "LTStatus";
            this.LTStatus.Size = new System.Drawing.Size(59, 18);
            this.LTStatus.TabIndex = 8;
            this.LTStatus.Text = "Estado:";
            // 
            // LabelUser
            // 
            this.LabelUser.AutoSize = true;
            this.LabelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LabelUser.Location = new System.Drawing.Point(204, 44);
            this.LabelUser.Name = "LabelUser";
            this.LabelUser.Size = new System.Drawing.Size(72, 18);
            this.LabelUser.TabIndex = 7;
            this.LabelUser.Text = "Usuario:  ";
            // 
            // ChangePassword
            // 
            this.ChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChangePassword.AutoSize = true;
            this.ChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePassword.LinkColor = System.Drawing.Color.Cyan;
            this.ChangePassword.Location = new System.Drawing.Point(31, 252);
            this.ChangePassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.Size = new System.Drawing.Size(145, 18);
            this.ChangePassword.TabIndex = 6;
            this.ChangePassword.TabStop = true;
            this.ChangePassword.Text = "Cambiar Contraseña";
            this.ChangePassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChangePassword_LinkClicked);
            // 
            // ChangePicture
            // 
            this.ChangePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangePicture.Image = global::Chat_Virtual___Cliente.Properties.Resources.ImageAdd;
            this.ChangePicture.Location = new System.Drawing.Point(130, 121);
            this.ChangePicture.Margin = new System.Windows.Forms.Padding(2);
            this.ChangePicture.Name = "ChangePicture";
            this.ChangePicture.Size = new System.Drawing.Size(37, 36);
            this.ChangePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ChangePicture.TabIndex = 5;
            this.ChangePicture.TabStop = false;
            this.ChangePicture.Click += new System.EventHandler(this.ChangePicture_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SaveButton.Location = new System.Drawing.Point(449, 315);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(112, 27);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Guardar";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SingIn_Click);
            // 
            // UserPicture
            // 
            this.UserPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UserPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserPicture.Location = new System.Drawing.Point(34, 27);
            this.UserPicture.Margin = new System.Windows.Forms.Padding(2);
            this.UserPicture.Name = "UserPicture";
            this.UserPicture.Size = new System.Drawing.Size(133, 130);
            this.UserPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserPicture.TabIndex = 0;
            this.UserPicture.TabStop = false;
            this.UserPicture.Click += new System.EventHandler(ChangePicture_Click);
            // 
            // ProfileDrag
            // 
            this.ProfileDrag.Fixed = true;
            this.ProfileDrag.Horizontal = true;
            this.ProfileDrag.TargetControl = this.TopPanel;
            this.ProfileDrag.Vertical = true;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 391);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Profile";
            this.Text = "Profile";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChangePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox AppIcon;
        private System.Windows.Forms.PictureBox exitButton;
        private System.Windows.Forms.PictureBox UserPicture;
        private System.Windows.Forms.Button SaveButton;
        private Bunifu.Framework.UI.BunifuDragControl ProfileDrag;
        private System.Windows.Forms.PictureBox ChangePicture;
        private System.Windows.Forms.LinkLabel ChangePassword;
        private System.Windows.Forms.Label LTitleBar;
        public System.Windows.Forms.Label LabelUser;
        public System.Windows.Forms.Label LTStatus;
        private System.Windows.Forms.TextBox TBStatus;
    }
}