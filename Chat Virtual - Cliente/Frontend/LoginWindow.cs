using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Exceptions;

namespace Chat_Virtual___Cliente {

    public partial class LoginWindow : Form {

        private Model model;
        private string username;
        private string userPassword;

        private delegate void DErrorLabelV(bool flag);
        private delegate void DReconnectLabelV(bool flag);

        //falta crear un hilo que se intente conectar al sevidor y que cambie los estados de los controles mediante un delegado
        public LoginWindow() {
            InitializeComponent();
            this.model = new Model();
            bool stateCon = StartConnection(1);
            if (!stateCon)
                errorMessage("Error al conectarse con el servidor");
            reconnect.Visible = !stateCon;
        }

        private void SingIn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            username = user.Text;
            userPassword = password.Text;
            user.Clear();
            password.Clear();
            errorLabel.Visible = false;

            bool shipping = true;
            shipping &= model.Write("InicioSesion");
            shipping &= model.Write(username);
            shipping &= model.Write(userPassword);

            if (!shipping) {
                errorMessage("Error al enviar los datos al servidor");
                Cursor = Cursors.Default;
                return;
            }

            string answer = model.ReadSingle();
            switch (answer) {
                case null:
                    errorMessage("No se ha obtenido respuesta del servidor");
                    break;
                case "SI":
                    MainView mainView = new MainView(model.getClient(), model.getStream());
                    mainView.Show();
                    Close();
                    break;
                case "NO":
                    errorMessage("Usuario o contraseña incorrectos");
                    break;
                default:
                    errorMessage("Error desconocido");
                    break;
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
            Cursor = Cursors.WaitCursor;
            errorLabel.Visible = false;
            reconnect.Visible = false;
            bool stateCon = StartConnection(3);
            if (!stateCon)
                errorMessage("Error al conectarse con el servidor");
            reconnect.Visible = !stateCon;
            Cursor = Cursors.Default;
        }

        private bool StartConnection(int nAttemps) {
            int attemps = 0;
            do {
                try {
                    model.Connect();
                    return true;
                } catch (ConnectException) {
                } finally {
                    attemps++;
                    Console.WriteLine("Intentos de conexion: " + attemps);
                }
            } while (!model.IsConnected() && attemps < nAttemps);
            return false;
        }

        private void SingUp_Click(object sender, EventArgs e) {
            errorLabel.Visible = false;
            bool shipping = true;
            shipping &= model.Write("Registro");
            shipping &= model.Write(user.Text);
            shipping &= model.Write(password.Text);

            if (!shipping) {
                errorMessage("No se han podido enviar los datos al servidor");
                return;
            }

            string answer = model.ReadSingle();
            switch (answer) {
                case null:
                    errorMessage("No se ha obtenido respuesta del servidor");
                    break;
                case "SI":
                    user.Clear();
                    password.Clear();
                    break;
                case "NO":
                    errorMessage("El nombre de ususario ya está en uso");
                    break;
                default:
                    errorMessage("Error desconocido");
                    break;
            }
        }

        public void errorMessage(string error) {
            errorLabel.Text = error;
            errorLabel.Visible = true;
        }
    }
}
