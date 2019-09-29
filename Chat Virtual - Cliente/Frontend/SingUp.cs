using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;

namespace Chat_Virtual___Cliente
{

    public partial class SingUp : Form {

        private Model model;
        public SingUp(TcpClient client, NetworkStream stream)
        {
            InitializeComponent();
            model = new Model(client, stream);
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void MinButton_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void MinButton_MouseEnter(object sender, EventArgs e) {
            minButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }
        private void MinButton_MouseLeave(object sender, EventArgs e) {
            minButtonPanel.BackColor = topPane.BackColor;
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e) {
            closeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e) {
            closeButtonPanel.BackColor = topPane.BackColor;
        }

        private void Button1_Click(object sender, EventArgs e) {
            model.Write("Registro");
            model.Write("juanitoAlimanna");
            model.Write("cuchillos");
        }
    }
}
