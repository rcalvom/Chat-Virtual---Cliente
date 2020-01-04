using Chat_Virtual___Cliente.Backend;
using ShippingData;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Frontend {
    public partial class TreeView : Form {

        public MainModel MainModel { get; set; }
        public TreeView(MainModel MainModel) {
            this.InitializeComponent();
            this.MainModel = MainModel;
            if (Singleton.GetSingleton().tree != null) {
                try {
                    this.TaskTree.Nodes.AddRange(Singleton.GetSingleton().tree);
                    this.TaskTree.ExpandAll();
                } catch (Exception) { }
            }
        }

        private void NewTask_Click(object sender, EventArgs e) {
            if (!this.NameText.Text.Equals("") && this.TaskTree.SelectedNode != null) {
                this.TaskTree.SelectedNode.Nodes.Add(this.NameText.Text);
                this.TaskTree.SelectedNode.Expand();
                this.NameText.Text = "";
            } else if (!this.NameText.Text.Equals("") && this.TaskTree.SelectedNode == null) {
                this.TaskTree.Nodes.Add(this.NameText.Text);
                this.NameText.Text = "";
            }
        }

        private void RemoveTask_Click(object sender, EventArgs e) {
            if (this.TaskTree.SelectedNode != null) {
                this.TaskTree.SelectedNode.Remove();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e) {
            this.ExitButton.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e) {
            this.ExitButton.BackColor = Color.FromArgb(20, 20, 24);
        }

        private void SaveTree_Click(object sender, EventArgs e) {
            Singleton.GetSingleton().tree = new TreeNode[this.TaskTree.Nodes.Count];
            this.TaskTree.Nodes.CopyTo(Singleton.GetSingleton().tree, 0);
            this.TaskTree.Nodes.Clear();
            TreeActivities tree = new TreeActivities {
                Node = Singleton.GetSingleton().tree
            };
            this.MainModel.ToWriteEnqueue(tree);
            this.Close();
        }
    }
}
