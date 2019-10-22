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
            LinkedQueue<string> writingQueue = new LinkedQueue<string>();
            writingQueue.Put(userName.Text);
            writingQueue.Put(userLastName.Text);
            writingQueue.Put(user.Text);
            writingQueue.Put(password.Text);
            writingQueue.Put(passwordRepeat.Text);

            if (!model.Write(writingQueue)) {
                ErrorMessage("Se ha producirdo un error enviando los datos al servidor");
                return;
            }

            LinkedQueue<string> serverAnswer = model.Read();
            if (serverAnswer == null) {
                ErrorMessage("No se ha obtenido respuesta del servidor");
                return;
            }

            while (!serverAnswer.IsEmpty()) {
                string answer = serverAnswer.GetFrontElement();
                switch (answer) {
                    case null:
                        break;
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
