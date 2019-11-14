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
            this.label2 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LStatus = new System.Windows.Forms.Label();
            this.LTStatus = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.ChangePassword = new System.Windows.Forms.LinkLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.SingIn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ProfileDrag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))));
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Controls.Add(this.exitButton);
            this.TopPanel.Controls.Add(this.pictureBox2);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(2);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(573, 37);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TopPanel_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(49, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Perfil";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Close_Window__2_48px;
            this.exitButton.Location = new System.Drawing.Point(545, 7);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 25);
            this.exitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitButton.TabIndex = 30;
            this.exitButton.TabStop = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Chat_Virtual___Cliente.Properties.Resources.SadiriLogo2;
            this.pictureBox2.Location = new System.Drawing.Point(2, 3);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.panel1.Controls.Add(this.LStatus);
            this.panel1.Controls.Add(this.LTStatus);
            this.panel1.Controls.Add(this.labelUser);
            this.panel1.Controls.Add(this.ChangePassword);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.SingIn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 354);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // LStatus
            // 
            this.LStatus.AutoSize = true;
            this.LStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LStatus.Location = new System.Drawing.Point(204, 139);
            this.LStatus.Name = "LStatus";
            this.LStatus.Size = new System.Drawing.Size(178, 18);
            this.LStatus.TabIndex = 9;
            this.LStatus.Text = "No hay estado disponible.";
            // 
            // LTStatus
            // 
            this.LTStatus.AutoSize = true;
            this.LTStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LTStatus.Location = new System.Drawing.Point(204, 102);
            this.LTStatus.Name = "LTStatus";
            this.LTStatus.Size = new System.Drawing.Size(59, 18);
            this.LTStatus.TabIndex = 8;
            this.LTStatus.Text = "Estado:";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelUser.Location = new System.Drawing.Point(204, 44);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(72, 18);
            this.labelUser.TabIndex = 7;
            this.labelUser.Text = "Usuario:  ";
            this.labelUser.Click += new System.EventHandler(this.LabelUser_Click);
            // 
            // ChangePassword
            // 
            this.ChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChangePassword.AutoSize = true;
            this.ChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePassword.LinkColor = System.Drawing.Color.Cyan;
            this.ChangePassword.Location = new System.Drawing.Point(31, 181);
            this.ChangePassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.Size = new System.Drawing.Size(145, 18);
            this.ChangePassword.TabIndex = 6;
            this.ChangePassword.TabStop = true;
            this.ChangePassword.Text = "Cambiar Contraseña";
            this.ChangePassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Chat_Virtual___Cliente.Properties.Resources.ImageAdd;
            this.pictureBox3.Location = new System.Drawing.Point(130, 121);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.PictureBox3_Click_1);
            // 
            // SingIn
            // 
            this.SingIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SingIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SingIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SingIn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SingIn.FlatAppearance.BorderSize = 0;
            this.SingIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SingIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SingIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SingIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SingIn.Location = new System.Drawing.Point(449, 315);
            this.SingIn.Name = "SingIn";
            this.SingIn.Size = new System.Drawing.Size(112, 27);
            this.SingIn.TabIndex = 4;
            this.SingIn.Text = "Guardar";
            this.SingIn.UseVisualStyleBackColor = false;
            this.SingIn.Click += new System.EventHandler(this.SingIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(34, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox exitButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SingIn;
        private Bunifu.Framework.UI.BunifuDragControl ProfileDrag;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel ChangePassword;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label labelUser;
        public System.Windows.Forms.Label LStatus;
        public System.Windows.Forms.Label LTStatus;
    }
}