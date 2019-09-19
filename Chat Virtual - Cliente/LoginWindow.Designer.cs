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
            this.SuspendLayout();
            // 
            // user
            // 
            this.user.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.ForeColor = System.Drawing.Color.Gray;
            this.user.Location = new System.Drawing.Point(239, 166);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(221, 24);
            this.user.TabIndex = 0;
            this.user.Text = "Ususario";
            this.user.TextChanged += new System.EventHandler(this.User_TextChanged);
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.Gray;
            this.password.Location = new System.Drawing.Point(239, 196);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(221, 24);
            this.password.TabIndex = 1;
            this.password.Text = "Contraseña";
            this.password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // SingUp
            // 
            this.SingUp.Location = new System.Drawing.Point(239, 226);
            this.SingUp.Name = "SingUp";
            this.SingUp.Size = new System.Drawing.Size(108, 24);
            this.SingUp.TabIndex = 2;
            this.SingUp.Text = "Registrarse";
            this.SingUp.UseVisualStyleBackColor = true;
            this.SingUp.Click += new System.EventHandler(this.SingUp_Click);
            // 
            // SingIn
            // 
            this.SingIn.Location = new System.Drawing.Point(353, 226);
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
            this.topPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPane.Location = new System.Drawing.Point(0, 0);
            this.topPane.Name = "topPane";
            this.topPane.Size = new System.Drawing.Size(800, 58);
            this.topPane.TabIndex = 4;
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.topPane);
            this.Controls.Add(this.SingIn);
            this.Controls.Add(this.SingUp);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginWindow";
            this.Text = "Loggin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button SingUp;
        private System.Windows.Forms.Button SingIn;
        private System.Windows.Forms.Panel topPane;
        private string username;
        private string userPassword;
    }
}