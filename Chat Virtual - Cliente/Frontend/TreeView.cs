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
                this.TaskTree.Nodes[0] = Singleton.GetSingleton().tree;
            }
        }

        private void NewTask_Click(object sender, EventArgs e) {
            if(!this.NameText.Text.Equals("") && this.TaskTree.SelectedNode != null) {
                this.TaskTree.SelectedNode.Nodes.Add(this.NameText.Text);
                this.TaskTree.SelectedNode.Expand();
                this.NameText.Text = "";
            }
        }

        private void RemoveTask_Click(object sender, EventArgs e) {
            if(this.TaskTree.SelectedNode.Parent != null) {
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
            TreeNode[] TreeNodes = new TreeNode[1];
            this.TaskTree.Nodes.CopyTo(TreeNodes, 0);
            TreeActivities tree = new TreeActivities {
                Node = TreeNodes[0]
            };
            this.MainModel.ToWriteEnqueue(tree);
            this.Close();

            Singleton.GetSingleton().tree = tree.Node;

        }
    }
}
