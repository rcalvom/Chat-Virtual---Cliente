using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Frontend;
using ShippingData;

namespace Chat_Virtual___Cliente {

    public partial class LoginWindow : Form {

        private readonly Model Model;
        private bool SubProcess;

        private delegate void SetVisible(bool state);
        private delegate void SetEnable(bool state, Control control);

        public LoginWindow() {
            this.InitializeComponent();
            this.Model = new Model();
            SubProcess = true;
            Refresh.RunWorkerAsync();
        }

        private void SingIn_Click(object sender, EventArgs e) {
            string UserName, UserPassword;
            this.Cursor = Cursors.WaitCursor;
            this.ErrorLabel.Visible = false;

            UserName = this.User.Text;
            UserPassword = this.Password.Text;

            if (UserName.Length == 0 || UserPassword.Length == 0) {
                this.ErrorMessage("Los campos de nombre de usuario y contraseña\nno pueden estar vacios");
                this.Cursor = Cursors.Default;
                return;
            }

            this.User.Clear();
            this.Password.Clear();

            this.Model.toWrite.Enqueue(new SignIn(UserName, UserPassword));

            if (!this.Model.Write()) {
                this.ErrorMessage("Error al enviar los datos al servidor");
                this.Cursor = Cursors.Default;
                return;
            }

            if (!this.Model.Read()) {
                this.ErrorMessage("No se ha obtenido respuesta del servidor");
                this.Cursor = Cursors.Default;
                return;
            }

            Data answer = this.Model.toRead.Dequeue();
            if (answer is RequestAnswer rs) {
                if (rs.answer) {
                    this.Model.singleton.userName = UserName;
                    SubProcess = false;
                    HomeView homeView = new HomeView();
                    homeView.Show();
                    this.Close();
                } else {
                    this.ErrorMessage("Usuario o contraseña incorrectos");
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void Password_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (int)Keys.Enter) {
                this.SingIn_Click(sender, e);
            }
        }

        private void User_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (int)Keys.Enter) {
                this.SingIn_Click(sender, e);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            SubProcess = false;
            Application.Exit();
        }

        private void MinButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MinButton_MouseEnter(object sender, EventArgs e) {
            this.MinButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void MinButton_MouseLeave(object sender, EventArgs e) {
            this.MinButtonPanel.BackColor = this.topPane.BackColor;
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e) {
            this.CloseButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e) {
            this.CloseButtonPanel.BackColor = this.topPane.BackColor;
        }

        private void SingUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            SubProcess = false;
            SingUpView singUpView = new SingUpView();
            singUpView.Show();
            this.Close();
        }

        public void ErrorMessage(string error) {
            this.ErrorLabel.Text = error;
            this.ErrorLabel.Visible = true;
        }

        private void Refresh_DoWork(object sender, DoWorkEventArgs e) {
            bool lastEstate = true;
            bool connected = false;
            while (SubProcess) {
                connected = Model.IsConnected();
                if (!connected) {
                    Model.Connect();
                }
                if (connected != lastEstate) {
                    if (!connected) {
                        SetVisibleControl(true);
                        SetStateButton(false, SingIn);
                        SetStateButton(false, SingUp);
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
                var d = new SetEnable(this.SetStateButton);
                option.Invoke(d, state, option);
            } else {
                option.Enabled = state;
            }
        }
    }
}