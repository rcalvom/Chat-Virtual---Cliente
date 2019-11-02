using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;
using ShippingData;
using DataStructures;

namespace Chat_Virtual___Cliente.Frontend {
    public partial class SingUpView : Form {

        private Model model;
        private bool subProcess;
        private LinkedList<Label> errorLabels;

        private delegate void SetVisible(bool state);
        private delegate void SetAvailable(bool state, Control button);

        public SingUpView() {
            InitializeComponent();
            errorLabels = new LinkedList<Label>();
            model = new Model();
            subProcess = true;
        }

        private void SingUp_Click(object sender, EventArgs e) {
            errorLabel.Visible = false;
            while (!errorLabels.IsEmpty()) {
                this.Controls.Remove(errorLabels.Get(0));
                errorLabels.Remove(0);
            }

            if(userName.Text.Length == 0 || userLastName.Text.Length == 0 || user.Text.Length == 0 || password.Text.Length == 0 || passwordRepeat.Text.Length == 0){
                ErrorMessage("Ninguno de los campos puede estar vacio");
                return;
            }

            if (!password.Text.Equals(passwordRepeat.Text)) {
                ErrorMessage("Los campos de contraseña no coinciden");
                return;
            }

            model.toWrite.Enqueue(new SignUp(userName.Text + " " + userLastName.Text, user.Text, password.Text));

            if (!model.Write()) {
                ErrorMessage("No se han podido enviar los datos al servidor");
                return;
            }

            if (!model.Read()) {
                ErrorMessage("No se ha obtenido respuesta del servidor");
            }

            if (model.toRead.GetFrontElement() is RequestAnswer answer) {
                model.toRead.Dequeue();
                if (answer.answer) {
                    subProcess = false;
                    model.singleton.userName = user.Text;
                    HomeView nextView = new HomeView();
                    nextView.Show();
                    Close();
                } else {
                    while (!model.toRead.IsEmpty()) {
                        if (model.toRead.GetFrontElement() is RequestError error) {
                            switch(error.errorCode){
                                case 0:
                                    ErrorMessage("El nombre de usuario ya se encuentra en uso");
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            subProcess = false;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        public void ErrorMessage(string error) {
            errorLabel.Text = error;
            errorLabel.Visible = true;
        }

        private void Refresh_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            bool lastEstate = true;
            bool connected = false;
            while (subProcess) {
                connected = model.IsConnected();
                if (connected != lastEstate || !connected) {
                    if (!connected) {
                        SetVisibleControl(true);
                        SetStateButton(false, Back);
                        SetStateButton(false, SingUp);
                        model.Connect();
                    } else {
                        SetVisibleControl(false);
                        SetStateButton(true, Back);
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

        private void MinButton_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            subProcess = false;
            Application.Exit();
        }
    }
}
