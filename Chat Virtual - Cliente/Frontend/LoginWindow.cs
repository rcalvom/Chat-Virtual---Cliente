using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Frontend;
using ShippingData;

namespace Chat_Virtual___Cliente {

    public partial class LoginWindow : Form {

        private Model model;
        private string username;
        private string userPassword;
        private bool subProcess;

        private delegate void SetVisible(bool state);
        private delegate void SetAvailable(bool state, Control button);

        public LoginWindow() {
            InitializeComponent();
            this.model = new Model();
            subProcess = true;
            Refresh.RunWorkerAsync();
        }

        private void SingIn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            errorLabel.Visible = false;

            username = user.Text;
            userPassword = password.Text;

            if (username.Length == 0 || userPassword.Length == 0) {
                ErrorMessage("Los campos de nombre de usuario y contraseña\nno pueden estar vacios");
                Cursor = Cursors.Default;
                return;
            }

            user.Clear();
            password.Clear();

            model.toWrite.Enqueue(new SignIn(username, userPassword));

            if (!model.Write()) {
                ErrorMessage("Error al enviar los datos al servidor");
                Cursor = Cursors.Default;
                return;
            }

            if (!model.Read()) {
                ErrorMessage("No se ha obtenido respuesta del servidor");
                Cursor = Cursors.Default;
                return;
            }

            Data answer = model.toRead.Dequeue();
            if (answer is RequestAnswer rs) {
                if (rs.answer) {
                    subProcess = false;
                    MainView m = new MainView();
                    m.Show();
                    //HomeView homeView = new HomeView();
                    //homeView.Show();
                    Close();
                } else
                    ErrorMessage("Usuario o contraseña incorrectos");
            }
            Cursor = Cursors.Default;
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            subProcess = false;
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

        private void SingUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            subProcess = false;
            SingUpView singUpView = new SingUpView();
            singUpView.Show();
            Close();
        }

        public void ErrorMessage(string error) {
            errorLabel.Text = error;
            errorLabel.Visible = true;
        }

        private void Refresh_DoWork(object sender, DoWorkEventArgs e) {
            bool lastEstate = true;
            bool connected = false;
            while (subProcess) {
                connected = model.IsConnected();
                if (connected != lastEstate || !connected) {
                    if (!connected) {
                        SetVisibleControl(true);
                        SetStateButton(false, SingIn);
                        SetStateButton(false, SingUp);
                        model.Connect();
                    } else {
                        SetVisibleControl(false);
                        SetStateButton(true, SingIn);
                        SetStateButton(true, SingUp);
                    }
                }
                lastEstate = connected;
                Thread.Sleep(1000);
            }
        }

        private void SetVisibleControl(bool state) {
            if (this.ServerDisconnected.InvokeRequired) {
                var d = new SetVisible(this.SetVisibleControl);
                ServerDisconnected.Invoke(d, state);
            } else {
                this.ServerDisconnected.Visible = state;
            }
        }

        private void SetStateButton(bool state, Control option) {
            if (option.InvokeRequired) {
                var d = new SetAvailable(this.SetStateButton);
                option.Invoke(d, state, option);
            } else {
                option.Enabled = state;
            }
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }
    }
}