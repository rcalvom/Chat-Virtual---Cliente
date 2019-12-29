namespace Chat_Virtual___Cliente.Frontend {
    partial class SendImage {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendImage));
            this.SendButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.TittleLabel = new System.Windows.Forms.Label();
            this.TextLabel = new System.Windows.Forms.Label();
            this.ComentTextBox = new System.Windows.Forms.TextBox();
            this.SelectPictureBox = new System.Windows.Forms.PictureBox();
            this.SelectPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.SelectPictureBox)).BeginInit();
            this.SelectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.Teal;
            this.SendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendButton.Enabled = false;
            this.SendButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.SendButton.FlatAppearance.BorderSize = 2;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SendButton.Location = new System.Drawing.Point(299, 451);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(89, 37);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "ENVIAR";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CancelButton.Location = new System.Drawing.Point(191, 451);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(92, 37);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "CANCELAR";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // TittleLabel
            // 
            this.TittleLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TittleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TittleLabel.Location = new System.Drawing.Point(12, 22);
            this.TittleLabel.Name = "TittleLabel";
            this.TittleLabel.Size = new System.Drawing.Size(376, 32);
            this.TittleLabel.TabIndex = 2;
            this.TittleLabel.Text = "SELECCIONA UNA IMAGEN";
            this.TittleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TextLabel.Location = new System.Drawing.Point(14, 273);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(156, 18);
            this.TextLabel.TabIndex = 3;
            this.TextLabel.Text = "Agrega un comentario ;)";
            // 
            // ComentTextBox
            // 
            this.ComentTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.ComentTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComentTextBox.Font = new System.Drawing.Font("Calibri", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComentTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ComentTextBox.Location = new System.Drawing.Point(17, 305);
            this.ComentTextBox.Multiline = true;
            this.ComentTextBox.Name = "ComentTextBox";
            this.ComentTextBox.Size = new System.Drawing.Size(371, 127);
            this.ComentTextBox.TabIndex = 4;
            // 
            // SelectPictureBox
            // 
            this.SelectPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("SelectPictureBox.Image")));
            this.SelectPictureBox.Location = new System.Drawing.Point(49, 0);
            this.SelectPictureBox.Name = "SelectPictureBox";
            this.SelectPictureBox.Size = new System.Drawing.Size(259, 174);
            this.SelectPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SelectPictureBox.TabIndex = 0;
            this.SelectPictureBox.TabStop = false;
            this.SelectPictureBox.Click += new System.EventHandler(this.Select_Click);
            // 
            // SelectPanel
            // 
            this.SelectPanel.Controls.Add(this.SelectPictureBox);
            this.SelectPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectPanel.Location = new System.Drawing.Point(17, 73);
            this.SelectPanel.Name = "SelectPanel";
            this.SelectPanel.Size = new System.Drawing.Size(370, 174);
            this.SelectPanel.TabIndex = 5;
            this.SelectPanel.Click += new System.EventHandler(this.Select_Click);
            // 
            // SendImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.SelectPanel);
            this.Controls.Add(this.ComentTextBox);
            this.Controls.Add(this.TextLabel);
            this.Controls.Add(this.TittleLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SendButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SendImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendImage";
            ((System.ComponentModel.ISupportInitialize)(this.SelectPictureBox)).EndInit();
            this.SelectPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label TittleLabel;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.TextBox ComentTextBox;
        private System.Windows.Forms.PictureBox SelectPictureBox;
        private System.Windows.Forms.Panel SelectPanel;
    }
}