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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Tareas pendientes.");
            this.panel1 = new System.Windows.Forms.Panel();
            this.LTitleTB = new System.Windows.Forms.Label();
            this.LTitle = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.TextBox();
            this.RemoveTask = new System.Windows.Forms.Button();
            this.NewTask = new System.Windows.Forms.Button();
            this.TaskTree = new System.Windows.Forms.TreeView();
            this.SaveTree = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.LTitleBar = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PanelDrag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.panel1.Controls.Add(this.LTitleTB);
            this.panel1.Controls.Add(this.LTitle);
            this.panel1.Controls.Add(this.NameText);
            this.panel1.Controls.Add(this.RemoveTask);
            this.panel1.Controls.Add(this.NewTask);
            this.panel1.Controls.Add(this.TaskTree);
            this.panel1.Controls.Add(this.SaveTree);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 413);
            this.panel1.TabIndex = 1;
            // 
            // LTitleTB
            // 
            this.LTitleTB.AutoSize = true;
            this.LTitleTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitleTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LTitleTB.Location = new System.Drawing.Point(450, 167);
            this.LTitleTB.Name = "LTitleTB";
            this.LTitleTB.Size = new System.Drawing.Size(181, 18);
            this.LTitleTB.TabIndex = 10;
            this.LTitleTB.Text = "Nombre de la nueva tarea:";
            // 
            // LTitle
            // 
            this.LTitle.AutoSize = true;
            this.LTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LTitle.Location = new System.Drawing.Point(294, 35);
            this.LTitle.Name = "LTitle";
            this.LTitle.Size = new System.Drawing.Size(198, 29);
            this.LTitle.TabIndex = 9;
            this.LTitle.Text = "Árbol de tareas.";
            // 
            // NameText
            // 
            this.NameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameText.Location = new System.Drawing.Point(453, 198);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(318, 26);
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
            this.RemoveTask.Location = new System.Drawing.Point(625, 264);
            this.RemoveTask.Name = "RemoveTask";
            this.RemoveTask.Size = new System.Drawing.Size(146, 27);
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
            this.NewTask.Location = new System.Drawing.Point(453, 264);
            this.NewTask.Name = "NewTask";
            this.NewTask.Size = new System.Drawing.Size(166, 27);
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
            this.TaskTree.Location = new System.Drawing.Point(30, 90);
            this.TaskTree.Name = "TaskTree";
            treeNode2.Checked = true;
            treeNode2.Name = "TreeRoot";
            treeNode2.Text = "Tareas pendientes.";
            this.TaskTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.TaskTree.Size = new System.Drawing.Size(389, 292);
            this.TaskTree.TabIndex = 5;
            // 
            // SaveTree
            // 
            this.SaveTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaveTree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveTree.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaveTree.FlatAppearance.BorderSize = 0;
            this.SaveTree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SaveTree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SaveTree.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveTree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SaveTree.Location = new System.Drawing.Point(666, 374);
            this.SaveTree.Name = "SaveTree";
            this.SaveTree.Size = new System.Drawing.Size(112, 27);
            this.SaveTree.TabIndex = 4;
            this.SaveTree.Text = "Guardar";
            this.SaveTree.UseVisualStyleBackColor = false;
            this.SaveTree.Click += new System.EventHandler(this.SaveTree_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))));
            this.TopPanel.Controls.Add(this.LTitleBar);
            this.TopPanel.Controls.Add(this.ExitButton);
            this.TopPanel.Controls.Add(this.pictureBox2);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(2);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 37);
            this.TopPanel.TabIndex = 2;
            // 
            // LTitleBar
            // 
            this.LTitleBar.AutoSize = true;
            this.LTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitleBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LTitleBar.Location = new System.Drawing.Point(42, 9);
            this.LTitleBar.Name = "LTitleBar";
            this.LTitleBar.Size = new System.Drawing.Size(107, 18);
            this.LTitleBar.TabIndex = 8;
            this.LTitleBar.Text = "Árbol de tareas";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Close_Window__2_48px;
            this.ExitButton.Location = new System.Drawing.Point(763, 7);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(25, 25);
            this.ExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExitButton.TabIndex = 30;
            this.ExitButton.TabStop = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TreeView";
            this.Text = "TreeView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RemoveTask;
        private System.Windows.Forms.Button NewTask;
        private System.Windows.Forms.Button SaveTree;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label LTitleBar;
        private System.Windows.Forms.PictureBox ExitButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.TreeView TaskTree;
        private System.Windows.Forms.Label LTitle;
        public System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.Label LTitleTB;
        private Bunifu.Framework.UI.BunifuDragControl PanelDrag;
    }
}