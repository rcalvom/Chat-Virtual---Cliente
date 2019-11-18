namespace Chat_Virtual___Cliente.Frontend {
    partial class TreeView {
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Lista de tareas pendientes.");
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.TextBox();
            this.RemoveTask = new System.Windows.Forms.Button();
            this.NewTask = new System.Windows.Forms.Button();
            this.TaskTree = new System.Windows.Forms.TreeView();
            this.SingIn = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PanelDrag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.NameText);
            this.panel1.Controls.Add(this.RemoveTask);
            this.panel1.Controls.Add(this.NewTask);
            this.panel1.Controls.Add(this.TaskTree);
            this.panel1.Controls.Add(this.SingIn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 635);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(675, 257);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nombre de la nueva tarea:";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(441, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 40);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lista de Tareas";
            // 
            // NameText
            // 
            this.NameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameText.Location = new System.Drawing.Point(680, 305);
            this.NameText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(475, 35);
            this.NameText.TabIndex = 8;
            // 
            // RemoveTask
            // 
            this.RemoveTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RemoveTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveTask.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RemoveTask.FlatAppearance.BorderSize = 0;
            this.RemoveTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RemoveTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RemoveTask.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveTask.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RemoveTask.Location = new System.Drawing.Point(938, 406);
            this.RemoveTask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RemoveTask.Name = "RemoveTask";
            this.RemoveTask.Size = new System.Drawing.Size(219, 42);
            this.RemoveTask.TabIndex = 7;
            this.RemoveTask.Text = "Eliminar Tarea";
            this.RemoveTask.UseVisualStyleBackColor = false;
            this.RemoveTask.Click += new System.EventHandler(this.RemoveTask_Click);
            // 
            // NewTask
            // 
            this.NewTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewTask.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewTask.FlatAppearance.BorderSize = 0;
            this.NewTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.NewTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.NewTask.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NewTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewTask.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NewTask.Location = new System.Drawing.Point(680, 406);
            this.NewTask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NewTask.Name = "NewTask";
            this.NewTask.Size = new System.Drawing.Size(249, 42);
            this.NewTask.TabIndex = 6;
            this.NewTask.Text = "Nueva Tarea";
            this.NewTask.UseVisualStyleBackColor = false;
            this.NewTask.Click += new System.EventHandler(this.NewTask_Click);
            // 
            // TaskTree
            // 
            this.TaskTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.TaskTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskTree.ForeColor = System.Drawing.Color.White;
            this.TaskTree.Location = new System.Drawing.Point(45, 138);
            this.TaskTree.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TaskTree.Name = "TaskTree";
            treeNode1.Name = "Nodo0";
            treeNode1.Text = "Lista de tareas pendientes.";
            this.TaskTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.TaskTree.Size = new System.Drawing.Size(582, 447);
            this.TaskTree.TabIndex = 5;
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
            this.SingIn.Location = new System.Drawing.Point(999, 575);
            this.SingIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SingIn.Name = "SingIn";
            this.SingIn.Size = new System.Drawing.Size(168, 42);
            this.SingIn.TabIndex = 4;
            this.SingIn.Text = "Guardar";
            this.SingIn.UseVisualStyleBackColor = false;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))));
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Controls.Add(this.exitButton);
            this.TopPanel.Controls.Add(this.pictureBox2);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1200, 57);
            this.TopPanel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(63, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Lista de Tareas";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Close_Window__2_48px;
            this.exitButton.Location = new System.Drawing.Point(1144, 11);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(38, 38);
            this.exitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitButton.TabIndex = 30;
            this.exitButton.TabStop = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Chat_Virtual___Cliente.Properties.Resources.SadiriLogo2;
            this.pictureBox2.Location = new System.Drawing.Point(3, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 49);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // PanelDrag
            // 
            this.PanelDrag.Fixed = true;
            this.PanelDrag.Horizontal = true;
            this.PanelDrag.TargetControl = this.TopPanel;
            this.PanelDrag.Vertical = true;
            // 
            // TreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TreeView";
            this.Text = "TreeView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RemoveTask;
        private System.Windows.Forms.Button NewTask;
        private System.Windows.Forms.Button SingIn;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox exitButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.TreeView TaskTree;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuDragControl PanelDrag;
    }
}