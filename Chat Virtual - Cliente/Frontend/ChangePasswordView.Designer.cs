namespace Chat_Virtual___Cliente.Frontend {
    partial class ChangePasswordView {
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
            this.DragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.topPane = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CloseButtonPanel = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.LCurrentPassword = new System.Windows.Forms.Label();
            this.SendChange = new System.Windows.Forms.Button();
            this.CurrentPassword = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.LRepeatPassword = new System.Windows.Forms.Label();
            this.RPassword = new System.Windows.Forms.TextBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.topPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CloseButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            this.SuspendLayout();
            // 
            // DragControl
            // 
            this.DragControl.Fixed = true;
            this.DragControl.Horizontal = true;
            this.DragControl.TargetControl = this.topPane;
            this.DragControl.Vertical = true;
            // 
            // topPane
            // 
            this.topPane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPane.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.topPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))));
            this.topPane.Controls.Add(this.pictureBox1);
            this.topPane.Controls.Add(this.CloseButtonPanel);
            this.topPane.Location = new System.Drawing.Point(0, 0);
            this.topPane.Name = "topPane";
            this.topPane.Size = new System.Drawing.Size(455, 34);
            this.topPane.TabIndex = 22;
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
            // CloseButtonPanel
            // 
            this.CloseButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.CloseButtonPanel.Controls.Add(this.ExitButton);
            this.CloseButtonPanel.Location = new System.Drawing.Point(421, 0);
            this.CloseButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButtonPanel.Name = "CloseButtonPanel";
            this.CloseButtonPanel.Size = new System.Drawing.Size(32, 34);
            this.CloseButtonPanel.TabIndex = 14;
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
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelPassword.Location = new System.Drawing.Point(16, 102);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(132, 18);
            this.labelPassword.TabIndex = 24;
            this.labelPassword.Text = "Nueva contraseña:";
            // 
            // LCurrentPassword
            // 
            this.LCurrentPassword.AutoSize = true;
            this.LCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCurrentPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LCurrentPassword.Location = new System.Drawing.Point(16, 68);
            this.LCurrentPassword.Name = "LCurrentPassword";
            this.LCurrentPassword.Size = new System.Drawing.Size(132, 18);
            this.LCurrentPassword.TabIndex = 23;
            this.LCurrentPassword.Text = "Contraseña actual:";
            // 
            // SendChange
            // 
            this.SendChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SendChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendChange.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SendChange.FlatAppearance.BorderSize = 0;
            this.SendChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SendChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SendChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SendChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SendChange.Location = new System.Drawing.Point(315, 168);
            this.SendChange.Name = "SendChange";
            this.SendChange.Size = new System.Drawing.Size(112, 27);
            this.SendChange.TabIndex = 21;
            this.SendChange.Text = "Confirmar";
            this.SendChange.UseVisualStyleBackColor = false;
            this.SendChange.Click += new System.EventHandler(this.SendChange_Click);
            // 
            // CurrentPassword
            // 
            this.CurrentPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CurrentPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CurrentPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CurrentPassword.Location = new System.Drawing.Point(160, 66);
            this.CurrentPassword.Name = "CurrentPassword";
            this.CurrentPassword.Size = new System.Drawing.Size(267, 24);
            this.CurrentPassword.TabIndex = 19;
            this.CurrentPassword.UseSystemPasswordChar = true;
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Password.Location = new System.Drawing.Point(160, 96);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(267, 24);
            this.Password.TabIndex = 20;
            this.Password.UseSystemPasswordChar = true;
            // 
            // LRepeatPassword
            // 
            this.LRepeatPassword.AutoSize = true;
            this.LRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRepeatPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LRepeatPassword.Location = new System.Drawing.Point(16, 132);
            this.LRepeatPassword.Name = "LRepeatPassword";
            this.LRepeatPassword.Size = new System.Drawing.Size(140, 18);
            this.LRepeatPassword.TabIndex = 26;
            this.LRepeatPassword.Text = "Repetir Contraseña:";
            // 
            // RPassword
            // 
            this.RPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RPassword.Location = new System.Drawing.Point(160, 126);
            this.RPassword.Name = "RPassword";
            this.RPassword.PasswordChar = '*';
            this.RPassword.Size = new System.Drawing.Size(267, 24);
            this.RPassword.TabIndex = 25;
            this.RPassword.UseSystemPasswordChar = true;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ErrorLabel.Location = new System.Drawing.Point(560, 250);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 18);
            this.ErrorLabel.TabIndex = 27;
            this.ErrorLabel.Visible = false;
            // 
            // ChangePasswordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(455, 220);
            this.ControlBox = false;
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.LRepeatPassword);
            this.Controls.Add(this.RPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.LCurrentPassword);
            this.Controls.Add(this.topPane);
            this.Controls.Add(this.SendChange);
            this.Controls.Add(this.CurrentPassword);
            this.Controls.Add(this.Password);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ChangePasswordView";
            this.topPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CloseButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl DragControl;
        private System.Windows.Forms.Panel topPane;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel CloseButtonPanel;
        private System.Windows.Forms.PictureBox ExitButton;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label LCurrentPassword;
        private System.Windows.Forms.Button SendChange;
        private System.Windows.Forms.TextBox CurrentPassword;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label LRepeatPassword;
        private System.Windows.Forms.TextBox RPassword;
        private System.Windows.Forms.Label ErrorLabel;
    }
}