using Chat_Virtual___Cliente.Backend;
using ShippingData;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Frontend {
    public partial class ChangePasswordView : Form {
        public ChangePasswordView() {
            this.InitializeComponent();
        }

        private void SendChange_Click(object sender, EventArgs e) {
            this.ErrorLabel.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            if (this.User.Text.Length == 0 || this.Password.Text.Length == 0 || this.RPassword.Text.Length == 0) {
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
                NewPassword = this.Password.Text
            };
            // Encolar Data. ¿y la contraseña actual?
            // Analizar respuesta.
            this.Cursor = Cursors.WaitCursor;

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

        
    }
}
