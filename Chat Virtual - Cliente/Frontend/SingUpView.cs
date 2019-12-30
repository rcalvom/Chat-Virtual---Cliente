using System;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;
using ShippingData;
using System.Drawing;

namespace Chat_Virtual___Cliente.Frontend {
    public partial class SingUpView : Form {

        private readonly Model Model;

        public SingUpView() {
            this.InitializeComponent();
            this.Model = new Model();
        }

        private void SingUp_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            this.ErrorLabel.Visible = false;
            if(this.userName.Text.Length == 0 || this.UserLastName.Text.Length == 0 || this.User.Text.Length == 0 ||
               this.Password.Text.Length == 0 || this.PasswordRepeat.Text.Length == 0){
                this.ErrorMessage("Ninguno de los campos puede estar vacio.");
                this.Cursor = Cursors.Default;
                return;
            }
            if (!this.Password.Text.Equals(this.PasswordRepeat.Text)) {
                this.ErrorMessage("Los campos de contraseña no coinciden.");
                this.Cursor = Cursors.Default;
                return;
            }

            this.Model.toWrite.Enqueue(new SignUp(this.userName.Text + " " + this.UserLastName.Text, this.User.Text, this.Password.Text));

            this.Model.Connect();

            if (!this.Model.Write()) {
                this.ErrorMessage("No se han podido enviar los datos al servidor.");
                this.Cursor = Cursors.Default;
                return;
            }

            if (!this.Model.Read()) {
                this.ErrorMessage("No se ha obtenido respuesta del servidor.");
                this.Model.Disconnect();
            }

            if (this.Model.toRead.GetFrontElement() is RequestAnswer answer) {
                this.Model.toRead.Dequeue();
                if (answer.answer) {
                    this.Model.singleton.userName = this.User.Text;
                    HomeView nextView = new HomeView();
                    nextView.Show();
                    this.Close();
                } else {
                    while (!this.Model.toRead.IsEmpty()) {
                        if (this.Model.toRead.GetFrontElement() is RequestError error) {
                            switch(error.errorCode){
                                case 0: {
                                    this.ErrorMessage("El nombre de usuario ya se encuentra en uso.");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        public void ErrorMessage(string error) {
            this.ErrorLabel.Text = error;
            this.ErrorLabel.Visible = true;
        }

        private void MinButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e) {
            this.ExitButton.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e) {
            this.ExitButton.BackColor = Color.FromArgb(20, 20, 24);
        }

        private void MinButton_MouseEnter(object sender, EventArgs e) {
            this.MinButton.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void MinButton_MouseLeave(object sender, EventArgs e) {
            this.MinButton.BackColor = Color.FromArgb(20, 20, 24);
        }
    }
}
