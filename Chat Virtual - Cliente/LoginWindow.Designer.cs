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
            this.minButton = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.PictureBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.singUp = new System.Windows.Forms.LinkLabel();
            this.labelMSJ0 = new System.Windows.Forms.Label();
            this.labelMSJ1 = new System.Windows.Forms.Label();
            this.errorServerCon = new System.Windows.Forms.Label();
            this.passwordUserWrong = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.minButtonPanel = new System.Windows.Forms.Panel();
            this.closeButtonPanel = new System.Windows.Forms.Panel();
            this.topPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.minButtonPanel.SuspendLayout();
            this.closeButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // user
            // 
            this.user.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.user.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.user.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.user.Location = new System.Drawing.Point(168, 157);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(267, 24);
            this.user.TabIndex = 0;
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.password.Location = new System.Drawing.Point(168, 187);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(267, 24);
            this.password.TabIndex = 1;
            this.password.UseSystemPasswordChar = true;
            // 
            // SingIn
            // 
            this.SingIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SingIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SingIn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SingIn.FlatAppearance.BorderSize = 0;
            this.SingIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SingIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SingIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SingIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SingIn.Location = new System.Drawing.Point(323, 217);
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
            this.topPane.Controls.Add(this.closeButtonPanel);
            this.topPane.Controls.Add(this.minButtonPanel);
            this.topPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPane.Location = new System.Drawing.Point(0, 0);
            this.topPane.Name = "topPane";
            this.topPane.Size = new System.Drawing.Size(522, 34);
            this.topPane.TabIndex = 4;
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
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelUser.Location = new System.Drawing.Point(73, 159);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(64, 18);
            this.labelUser.TabIndex = 5;
            this.labelUser.Text = "Usuario:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelPassword.Location = new System.Drawing.Point(73, 189);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(89, 18);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Contraseña:";
            // 
            // singUp
            // 
            this.singUp.AutoSize = true;
            this.singUp.BackColor = System.Drawing.Color.Transparent;
            this.singUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singUp.LinkColor = System.Drawing.Color.Teal;
            this.singUp.Location = new System.Drawing.Point(142, 257);
            this.singUp.Name = "singUp";
            this.singUp.Size = new System.Drawing.Size(74, 18);
            this.singUp.TabIndex = 7;
            this.singUp.TabStop = true;
            this.singUp.Text = "registrarte";
            this.singUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SingUp_LinkClicked);
            // 
            // labelMSJ0
            // 
            this.labelMSJ0.AutoSize = true;
            this.labelMSJ0.BackColor = System.Drawing.Color.Transparent;
            this.labelMSJ0.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMSJ0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelMSJ0.Location = new System.Drawing.Point(73, 257);
            this.labelMSJ0.Name = "labelMSJ0";
            this.labelMSJ0.Size = new System.Drawing.Size(72, 18);
            this.labelMSJ0.TabIndex = 8;
            this.labelMSJ0.Text = "O puedes";
            // 
            // labelMSJ1
            // 
            this.labelMSJ1.AutoSize = true;
            this.labelMSJ1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMSJ1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelMSJ1.Location = new System.Drawing.Point(213, 257);
            this.labelMSJ1.Name = "labelMSJ1";
            this.labelMSJ1.Size = new System.Drawing.Size(191, 18);
            this.labelMSJ1.TabIndex = 9;
            this.labelMSJ1.Text = "si no tienes una cuenta aún.";
            // 
            // errorServerCon
            // 
            this.errorServerCon.AutoSize = true;
            this.errorServerCon.BackColor = System.Drawing.Color.Transparent;
            this.errorServerCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorServerCon.ForeColor = System.Drawing.Color.DarkRed;
            this.errorServerCon.Location = new System.Drawing.Point(73, 221);
            this.errorServerCon.Name = "errorServerCon";
            this.errorServerCon.Size = new System.Drawing.Size(234, 18);
            this.errorServerCon.TabIndex = 10;
            this.errorServerCon.Text = "Fallo al conectarse con el servidor";
            this.errorServerCon.Visible = false;
            // 
            // passwordUserWrong
            // 
            this.passwordUserWrong.AutoSize = true;
            this.passwordUserWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordUserWrong.ForeColor = System.Drawing.Color.DarkRed;
            this.passwordUserWrong.Location = new System.Drawing.Point(73, 221);
            this.passwordUserWrong.Name = "passwordUserWrong";
            this.passwordUserWrong.Size = new System.Drawing.Size(230, 18);
            this.passwordUserWrong.TabIndex = 11;
            this.passwordUserWrong.Text = "Usuario o contraseña incorrectos";
            this.passwordUserWrong.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(176, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // DragControl
            // 
            this.DragControl.Fixed = true;
            this.DragControl.Horizontal = true;
            this.DragControl.TargetControl = this.topPane;
            this.DragControl.Vertical = true;
            // 
            // minButtonPanel
            // 
            this.minButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.minButtonPanel.Controls.Add(this.minButton);
            this.minButtonPanel.Location = new System.Drawing.Point(458, 0);
            this.minButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.minButtonPanel.Name = "minButtonPanel";
            this.minButtonPanel.Size = new System.Drawing.Size(32, 34);
            this.minButtonPanel.TabIndex = 13;
            // 
            // closeButtonPanel
            // 
            this.closeButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.closeButtonPanel.Controls.Add(this.exitButton);
            this.closeButtonPanel.Location = new System.Drawing.Point(490, 0);
            this.closeButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.closeButtonPanel.Name = "closeButtonPanel";
            this.closeButtonPanel.Size = new System.Drawing.Size(32, 34);
            this.closeButtonPanel.TabIndex = 14;
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(522, 326);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.passwordUserWrong);
            this.Controls.Add(this.labelMSJ1);
            this.Controls.Add(this.labelMSJ0);
            this.Controls.Add(this.singUp);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.topPane);
            this.Controls.Add(this.SingIn);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user);
            this.Controls.Add(this.errorServerCon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loggin";
            this.topPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.minButtonPanel.ResumeLayout(false);
            this.closeButtonPanel.ResumeLayout(false);
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
        private System.Windows.Forms.LinkLabel singUp;
        private System.Windows.Forms.Label labelMSJ0;
        private System.Windows.Forms.Label labelMSJ1;
        private System.Windows.Forms.Label errorServerCon;
        private System.Windows.Forms.Label passwordUserWrong;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuDragControl DragControl;
        private System.Windows.Forms.Panel minButtonPanel;
        private System.Windows.Forms.Panel closeButtonPanel;
    }
}