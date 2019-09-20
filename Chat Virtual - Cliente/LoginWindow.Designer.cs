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
            this.user = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.SingUp = new System.Windows.Forms.Button();
            this.SingIn = new System.Windows.Forms.Button();
            this.topPane = new System.Windows.Forms.Panel();
            this.minButton = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.PictureBox();
            this.resizeButton = new System.Windows.Forms.PictureBox();
            this.topPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizeButton)).BeginInit();
            this.SuspendLayout();
            // 
            // user
            // 
            this.user.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.ForeColor = System.Drawing.Color.Gray;
            this.user.Location = new System.Drawing.Point(144, 138);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(222, 24);
            this.user.TabIndex = 0;
            this.user.Text = "Ususario";
            this.user.TextChanged += new System.EventHandler(this.User_TextChanged);
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.Gray;
            this.password.Location = new System.Drawing.Point(145, 168);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(221, 24);
            this.password.TabIndex = 1;
            this.password.Text = "Contraseña";
            this.password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // SingUp
            // 
            this.SingUp.Location = new System.Drawing.Point(144, 209);
            this.SingUp.Name = "SingUp";
            this.SingUp.Size = new System.Drawing.Size(108, 24);
            this.SingUp.TabIndex = 2;
            this.SingUp.Text = "Registrarse";
            this.SingUp.UseVisualStyleBackColor = true;
            this.SingUp.Click += new System.EventHandler(this.SingUp_Click);
            // 
            // SingIn
            // 
            this.SingIn.Location = new System.Drawing.Point(259, 209);
            this.SingIn.Name = "SingIn";
            this.SingIn.Size = new System.Drawing.Size(107, 24);
            this.SingIn.TabIndex = 3;
            this.SingIn.Text = "Iniciar sesión";
            this.SingIn.UseVisualStyleBackColor = true;
            this.SingIn.Click += new System.EventHandler(this.SingIn_Click);
            // 
            // topPane
            // 
            this.topPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))));
            this.topPane.Controls.Add(this.minButton);
            this.topPane.Controls.Add(this.exitButton);
            this.topPane.Controls.Add(this.resizeButton);
            this.topPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPane.Location = new System.Drawing.Point(0, 0);
            this.topPane.Name = "topPane";
            this.topPane.Size = new System.Drawing.Size(522, 34);
            this.topPane.TabIndex = 4;
            // 
            // minButton
            // 
            this.minButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Minimize_Window_2_48px;
            this.minButton.Location = new System.Drawing.Point(431, 3);
            this.minButton.Name = "minButton";
            this.minButton.Size = new System.Drawing.Size(25, 25);
            this.minButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minButton.TabIndex = 7;
            this.minButton.TabStop = false;
            this.minButton.Click += new System.EventHandler(this.MinButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Close_Window__2_48px;
            this.exitButton.Location = new System.Drawing.Point(493, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 25);
            this.exitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitButton.TabIndex = 5;
            this.exitButton.TabStop = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // resizeButton
            // 
            this.resizeButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Maximize_Window_2_48px;
            this.resizeButton.Location = new System.Drawing.Point(462, 3);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(25, 25);
            this.resizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resizeButton.TabIndex = 6;
            this.resizeButton.TabStop = false;
            this.resizeButton.Click += new System.EventHandler(this.ResizeButton_Click);
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(522, 276);
            this.Controls.Add(this.topPane);
            this.Controls.Add(this.SingIn);
            this.Controls.Add(this.SingUp);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loggin";
            this.topPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizeButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button SingUp;
        private System.Windows.Forms.Button SingIn;
        private System.Windows.Forms.Panel topPane;
        private System.Windows.Forms.PictureBox minButton;
        private System.Windows.Forms.PictureBox exitButton;
        private System.Windows.Forms.PictureBox resizeButton;
    }
}