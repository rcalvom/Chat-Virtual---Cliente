using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Frontend {
    public partial class TreeView : Form {
        public TreeView() {
            InitializeComponent();
        }

        private void NewTask_Click(object sender, EventArgs e) {
            if(!this.NameText.Text.Equals("")) {
                this.TaskTree.SelectedNode.Nodes.Add(this.NameText.Text);
                this.TaskTree.SelectedNode.Expand();
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

        private void Label3_Click(object sender, EventArgs e) {

        }
    }
}
