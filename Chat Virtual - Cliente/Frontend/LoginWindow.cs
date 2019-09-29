using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
                Thread t = new Thread(StartConnection);
                t.Start();
                StartConnection();
            } while (/*!model.IsConnected()*/ false);
        }

        public void StartConnection() {
            try {
                model.Connect();
                errorServerCon.Visible = false;
                Reconnect.Visible = false;
            } catch (ConnectException ce) {
                errorServerCon.Visible = true;
                Reconnect.Visible = true;
            }
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
                model.Write("InicioSesion");
                model.Write(username);
                model.Write(userPassword);
                string serverAnswer = model.ReadSingle();
                if (serverAnswer == "NO") 
                    passwordUserWrong.Visible = true;
                else if (serverAnswer == "SI") {
                    MainView mainView = new MainView(model.getClient(), model.getStream());
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
            SingUp singUp = new SingUp(model.getClient(), model.getStream());
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

        private void Reconnect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            StartConnection();
        }
    }
}
