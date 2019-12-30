using System;
using System.Drawing;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Frontend;
using ShippingData;

namespace Chat_Virtual___Cliente {

    public partial class LoginWindow : Form{

        private readonly Model Model;
        private string Username;
        private string UserPassword;

        public LoginWindow() {
            this.InitializeComponent();
            this.Model = new Model();
        }

        private void SingIn_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            this.ErrorLabel.Visible = false;

            this.Username = this.User.Text;
            this.UserPassword = this.Password.Text;

            if (this.Username.Length == 0 || this.UserPassword.Length == 0) {
                this.ErrorMessage("Los campos de nombre de usuario y contraseña\nno pueden estar vacios");
                this.Cursor = Cursors.Default;
                return;
            }

            this.User.Clear();
            this.Password.Clear();

            this.Model.toWrite.Enqueue(new SignIn(this.Username, this.UserPassword));

            this.Model.Connect();

            if (!this.Model.Write()) {
                this.ErrorMessage("Error al enviar los datos al servidor");
                this.Cursor = Cursors.Default;
                return;
            }

            if (!this.Model.Read()) {
                this.ErrorMessage("No se ha obtenido respuesta del servidor");
                this.Model.Disconnect();
                this.Cursor = Cursors.Default;
                return;
            }

            Data answer = this.Model.toRead.Dequeue();
            if (answer is RequestAnswer rs) {
                if (rs.answer) {
                    this.Model.singleton.userName = Username;
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
            SingUpView singUpView = new SingUpView();
            singUpView.Show();
            this.Close();
        }

        public void ErrorMessage(string error) {
            this.ErrorLabel.Text = error;
            this.ErrorLabel.Visible = true;
        }

        
    }
}