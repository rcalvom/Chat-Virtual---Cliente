﻿using ShippingData;
using System;
using Chat_Virtual___Cliente.Backend;
using System.Windows.Forms;
using System.Drawing;

namespace Chat_Virtual___Cliente.Frontend {
    public partial class Profile : Form {
        public Profile() {
            this.InitializeComponent();
            try {
                this.LabelUser.Text += "" + Singleton.GetSingleton().userName;
                this.UserPicture.Image = Serializer.DeserializeImage(Singleton.GetSingleton().ProfilePicture);
                this.TBStatus.Text = Singleton.GetSingleton().Status;
            } catch (Exception) { }
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void UserPicture_Click(object sender, EventArgs e) {
            // TODO: ¿Agrandar foto?
        }

        private void ChangePicture_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "JPG files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK) {
                string imageLocation = dialog.FileName;
                if (imageLocation != null) {
                    this.UserPicture.ImageLocation = imageLocation;
                }
            }
            dialog.Dispose();

        }

        private void ChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ChangePasswordView cpv = new ChangePasswordView();
            cpv.ShowDialog();
            cpv.Dispose();
        }

        private void SingIn_Click(object sender, EventArgs e) {
            Singleton s = Singleton.GetSingleton();
            s.ProfilePicture = Serializer.SerializeImage(this.UserPicture.Image);
            s.Status = this.TBStatus.Text;
            s.ProfileHasChanged = true;
            this.Close();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e) {
            this.exitButton.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e) {
            this.exitButton.BackColor = Color.FromArgb(20, 20, 24);
        }
    }
}
