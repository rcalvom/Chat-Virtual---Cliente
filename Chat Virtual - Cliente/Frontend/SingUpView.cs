﻿using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;
using DataStructures;

namespace Chat_Virtual___Cliente.Frontend {
    public partial class SingUpView : Form {

        private Model model;
        private bool subProcess;

        private delegate void SetVisible(bool state);
        private delegate void SetAvailable(bool state, Control button);

        public SingUpView(TcpClient client, NetworkStream stream) {
            InitializeComponent();
            model = new Model(client, stream);
            subProcess = true;
        }

        private void SingUp_Click(object sender, EventArgs e) {
            errorLabel.Visible = false;
            model.toWriteString.Enqueue(userName.Text);
            model.toWriteString.Enqueue(userLastName.Text);
            model.toWriteString.Enqueue(user.Text);
            model.toWriteString.Enqueue(password.Text);
            model.toWriteString.Enqueue(passwordRepeat.Text);
            //model.toWriteString.Enqueue(null);

            if (!model.WriteString()) {
                ErrorMessage("No se han podido enviar los datos al servidor");
                return;
            }

            if (!model.ReadString()) {
                ErrorMessage("No se ha obtenido respuesta del servidor");
                return;
            }

            while (!model.toReadString.IsEmpty()) {
                string answer = model.toReadString.Dequeue();
                switch (answer) {
                    default:
                        break;
                }
            }
        }

        private void Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            LoginWindow loginWindow = new LoginWindow(model.getClient(), model.getStream());
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

        }
    }
}
