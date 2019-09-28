using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Exceptions;

namespace Chat_Virtual___Cliente {

    public partial class LoginWindow : Form {

        private Model model;
        private string username;
        private string userPassword;

        public LoginWindow() {
            InitializeComponent();
            this.model = new Model();
            do {
                try {
                    model.Connect();
                    errorServerCon.Visible = false;
                } catch (ConnectException ce) {
                    errorServerCon.Visible = true;
                }
            } while (/*!model.IsConnected()*/ false);
        }

        private void SingIn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            username = user.Text;
            userPassword = password.Text;
            user.Clear();
            password.Clear();
            passwordUserWrong.Visible = false;

            try {
                List<string> messages = new List<string>();
                messages.Add("InicioSesion");
                messages.Add(username);
                messages.Add(userPassword);
                model.Write(messages);
                string serverAnswer = model.Read().First();
                if (serverAnswer == "NO") 
                    passwordUserWrong.Visible = true;
                else if (serverAnswer == "SI") {
                    //MainView mainView = new MainView();
                    mainView.Show();
                    Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("Fallo de envio de datos al servidor");
            }

            Cursor = Cursors.Default;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinButton_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void SingUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            SingUp singUp = new SingUp();
            singUp.Show();
            Close();
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
    }
}
