﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;
using ShippingData;

namespace Chat_Virtual___Cliente.Frontend {
    public partial class HomeView : Form {

        private MainModel model;
        private bool maximized;
        private bool subprocess;

        public HomeView() {
            InitializeComponent();
            model = new MainModel();
            maximized = false;
            subprocess = true;
            receptor.RunWorkerAsync();
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

        private void ResizeButton_Click(object sender, EventArgs e) {
            if (maximized) {
                WindowState = FormWindowState.Normal;
                resizeButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Maximize_Window_2_48px;
            } else {
                WindowState = FormWindowState.Maximized;
                resizeButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Restore_Window_2_48px;
            }
            maximized = !maximized;
        }

        private void ResizeButton_MouseEnter(object sender, EventArgs e) {
            resizeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ResizeButton_MouseLeave(object sender, EventArgs e) {
            resizeButtonPanel.BackColor = topPane.BackColor;
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            model.Disconnect();
            subprocess = false;
            Application.Exit();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e) {
            closeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e) {
            closeButtonPanel.BackColor = topPane.BackColor;
        }

        private void Receptor_DoWork(object sender, DoWorkEventArgs e) {
            while (subprocess) {
                if (!model.toRead.IsEmpty()) {
                    Data data = model.toRead.Dequeue();

                    if (data is ChatMessage chatMessages) {
                        
                    } else if (data is GroupMessage groupMessage) {

                    } else if (data is ChatGroup chatGroup) {

                    } else if (data is Chat chat) {

                    } else if(data is RequestAnswer requestAnswer) {

                    } else if (data is RequestError requestError) {

                    }
                }
            }
        }
    }
}