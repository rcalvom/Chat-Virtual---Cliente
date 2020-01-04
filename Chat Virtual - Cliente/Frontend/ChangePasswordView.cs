using Chat_Virtual___Cliente.Backend;
using ShippingData;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Frontend {
    public partial class ChangePasswordView : Form {

        public MainModel MainModel { get; set; }

        public ChangePasswordView(MainModel MainModel) {
            this.InitializeComponent();
            this.MainModel = MainModel;
        }

        private void SendChange_Click(object sender, EventArgs e) {
            this.ErrorLabel.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            if (this.CurrentPassword.Text.Length == 0 || this.Password.Text.Length == 0 || this.RPassword.Text.Length == 0) {
                this.ErrorMessage("Los campos no pueden estar vacios.");
                this.Cursor = Cursors.Default;
                return;
            }
            if (!this.Password.Text.Equals(this.RPassword.Text)) {
                this.ErrorMessage("Las contraseñas nuevas no son iguales.");
                this.Cursor = Cursors.Default;
                return;
            }

            ChangePassword data = new ChangePassword {
                UserName = Singleton.GetSingleton().userName,
                CurrentPassword = this.CurrentPassword.Text,
                NewPassword = this.Password.Text
            };

            this.MainModel.ToWriteEnqueue(data);

            // TODO: Revisar el manejo el objeto respuesta de la cola.
            //if (respuesta es afirmativa) { el codigo es 3.
            //    this.ErrorMessage("Se ha cambiado la contraseña satisfactoriamente.");
            //} else {
            //    this.ErrorMessage("La contraseña actual no coincide con la contraseña del sistema.");
            //}


            this.Cursor = Cursors.Default;
        }

        public void ErrorMessage(string error) {
            this.ErrorLabel.Text = error;
            this.ErrorLabel.Visible = true;
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

        private void CurrentPassword_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (int)Keys.Enter) {
                this.SendChange_Click(sender, e);
            }
        }

        private void Password_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (int)Keys.Enter) {
                this.SendChange_Click(sender, e);
            }
        }

        private void RPassword_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (int)Keys.Enter) {
                this.SendChange_Click(sender, e);
            }
        }
    }
}
