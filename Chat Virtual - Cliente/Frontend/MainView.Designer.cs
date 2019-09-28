namespace Chat_Virtual___Cliente {
    partial class MainView {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.Restaurar = new System.Windows.Forms.PictureBox();
            this.Close = new System.Windows.Forms.PictureBox();
            this.Minimize = new System.Windows.Forms.PictureBox();
            this.Maximize = new System.Windows.Forms.PictureBox();
            this.Menu = new System.Windows.Forms.PictureBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.send = new System.Windows.Forms.Button();
            this.mensaje = new System.Windows.Forms.TextBox();
            this.chat = new System.Windows.Forms.RichTextBox();
            this.DragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Animation = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.SlidePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Animation2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Restaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Menu)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Indigo;
            this.TopPanel.Controls.Add(this.Restaurar);
            this.TopPanel.Controls.Add(this.Close);
            this.TopPanel.Controls.Add(this.Minimize);
            this.TopPanel.Controls.Add(this.Maximize);
            this.TopPanel.Controls.Add(this.Menu);
            this.Animation2.SetDecoration(this.TopPanel, BunifuAnimatorNS.DecorationType.None);
            this.Animation.SetDecoration(this.TopPanel, BunifuAnimatorNS.DecorationType.None);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(2);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(667, 47);
            this.TopPanel.TabIndex = 0;
            // 
            // Restaurar
            // 
            this.Restaurar.AccessibleName = "Restore";
            this.Restaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Animation.SetDecoration(this.Restaurar, BunifuAnimatorNS.DecorationType.None);
            this.Animation2.SetDecoration(this.Restaurar, BunifuAnimatorNS.DecorationType.None);
            this.Restaurar.Image = global::Chat_Virtual___Cliente.Properties.Resources.Restore_Window_2_48px;
            this.Restaurar.Location = new System.Drawing.Point(601, 10);
            this.Restaurar.Margin = new System.Windows.Forms.Padding(2);
            this.Restaurar.Name = "Restaurar";
            this.Restaurar.Size = new System.Drawing.Size(27, 26);
            this.Restaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Restaurar.TabIndex = 3;
            this.Restaurar.TabStop = false;
            this.Restaurar.Visible = false;
            this.Restaurar.Click += new System.EventHandler(this.PictureBox5_Click);
            // 
            // Close
            // 
            this.Close.AccessibleName = "Close";
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Animation.SetDecoration(this.Close, BunifuAnimatorNS.DecorationType.None);
            this.Animation2.SetDecoration(this.Close, BunifuAnimatorNS.DecorationType.None);
            this.Close.Image = global::Chat_Virtual___Cliente.Properties.Resources.Close_Window__2_48px;
            this.Close.Location = new System.Drawing.Point(632, 10);
            this.Close.Margin = new System.Windows.Forms.Padding(2);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(27, 26);
            this.Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Close.TabIndex = 1;
            this.Close.TabStop = false;
            this.Close.Click += new System.EventHandler(this.PictureBox3_Click);
            // 
            // Minimize
            // 
            this.Minimize.AccessibleName = "Minimize";
            this.Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Animation.SetDecoration(this.Minimize, BunifuAnimatorNS.DecorationType.None);
            this.Animation2.SetDecoration(this.Minimize, BunifuAnimatorNS.DecorationType.None);
            this.Minimize.Image = global::Chat_Virtual___Cliente.Properties.Resources.Minimize_Window_2_48px;
            this.Minimize.Location = new System.Drawing.Point(571, 10);
            this.Minimize.Margin = new System.Windows.Forms.Padding(2);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(27, 26);
            this.Minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Minimize.TabIndex = 2;
            this.Minimize.TabStop = false;
            this.Minimize.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // Maximize
            // 
            this.Maximize.AccessibleName = "Maximize";
            this.Maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Animation.SetDecoration(this.Maximize, BunifuAnimatorNS.DecorationType.None);
            this.Animation2.SetDecoration(this.Maximize, BunifuAnimatorNS.DecorationType.None);
            this.Maximize.Image = global::Chat_Virtual___Cliente.Properties.Resources.Maximize_Window_2_48px;
            this.Maximize.Location = new System.Drawing.Point(601, 10);
            this.Maximize.Margin = new System.Windows.Forms.Padding(2);
            this.Maximize.Name = "Maximize";
            this.Maximize.Size = new System.Drawing.Size(27, 26);
            this.Maximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Maximize.TabIndex = 0;
            this.Maximize.TabStop = false;
            this.Maximize.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // Menu
            // 
            this.Animation.SetDecoration(this.Menu, BunifuAnimatorNS.DecorationType.None);
            this.Animation2.SetDecoration(this.Menu, BunifuAnimatorNS.DecorationType.None);
            this.Menu.Image = global::Chat_Virtual___Cliente.Properties.Resources.Menu_48px;
            this.Menu.Location = new System.Drawing.Point(17, 10);
            this.Menu.Margin = new System.Windows.Forms.Padding(2);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(23, 23);
            this.Menu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Menu.TabIndex = 0;
            this.Menu.TabStop = false;
            this.Menu.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MainPanel.Controls.Add(this.send);
            this.MainPanel.Controls.Add(this.mensaje);
            this.MainPanel.Controls.Add(this.chat);
            this.Animation2.SetDecoration(this.MainPanel, BunifuAnimatorNS.DecorationType.None);
            this.Animation.SetDecoration(this.MainPanel, BunifuAnimatorNS.DecorationType.None);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(167, 47);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(500, 343);
            this.MainPanel.TabIndex = 2;
            // 
            // send
            // 
            this.send.BackColor = System.Drawing.Color.White;
            this.Animation.SetDecoration(this.send, BunifuAnimatorNS.DecorationType.None);
            this.Animation2.SetDecoration(this.send, BunifuAnimatorNS.DecorationType.None);
            this.send.Location = new System.Drawing.Point(446, 307);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(41, 24);
            this.send.TabIndex = 2;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = false;
            this.send.Click += new System.EventHandler(this.Send_Click);
            // 
            // mensaje
            // 
            this.Animation.SetDecoration(this.mensaje, BunifuAnimatorNS.DecorationType.None);
            this.Animation2.SetDecoration(this.mensaje, BunifuAnimatorNS.DecorationType.None);
            this.mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaje.Location = new System.Drawing.Point(8, 307);
            this.mensaje.Name = "mensaje";
            this.mensaje.Size = new System.Drawing.Size(432, 21);
            this.mensaje.TabIndex = 1;
            // 
            // chat
            // 
            this.Animation2.SetDecoration(this.chat, BunifuAnimatorNS.DecorationType.None);
            this.Animation.SetDecoration(this.chat, BunifuAnimatorNS.DecorationType.None);
            this.chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chat.Location = new System.Drawing.Point(8, 5);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(480, 296);
            this.chat.TabIndex = 0;
            this.chat.Text = "";
            // 
            // DragControl
            // 
            this.DragControl.Fixed = true;
            this.DragControl.Horizontal = true;
            this.DragControl.TargetControl = this.TopPanel;
            this.DragControl.Vertical = true;
            // 
            // Animation
            // 
            this.Animation.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.Animation.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.Animation.DefaultAnimation = animation1;
            // 
            // SlidePanel
            // 
            this.SlidePanel.BackColor = System.Drawing.Color.Black;
            this.Animation2.SetDecoration(this.SlidePanel, BunifuAnimatorNS.DecorationType.None);
            this.Animation.SetDecoration(this.SlidePanel, BunifuAnimatorNS.DecorationType.None);
            this.SlidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SlidePanel.Location = new System.Drawing.Point(0, 47);
            this.SlidePanel.Margin = new System.Windows.Forms.Padding(2);
            this.SlidePanel.Name = "SlidePanel";
            this.SlidePanel.Size = new System.Drawing.Size(167, 343);
            this.SlidePanel.TabIndex = 1;
            // 
            // Animation2
            // 
            this.Animation2.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.Animation2.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.Animation2.DefaultAnimation = animation3;
            // 
            // GraphicInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 390);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.SlidePanel);
            this.Controls.Add(this.TopPanel);
            this.Animation.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Animation2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GraphicInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GraphicInterface_Load);
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Restaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Menu)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.PictureBox Menu;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.PictureBox Minimize;
        private System.Windows.Forms.PictureBox Close;
        private System.Windows.Forms.PictureBox Maximize;
        private System.Windows.Forms.PictureBox Restaurar;
        private Bunifu.Framework.UI.BunifuDragControl DragControl;
        private BunifuAnimatorNS.BunifuTransition Animation;
        private BunifuAnimatorNS.BunifuTransition Animation2;
        private System.Windows.Forms.FlowLayoutPanel SlidePanel;
        private System.Windows.Forms.RichTextBox chat;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox mensaje;
    }
}

