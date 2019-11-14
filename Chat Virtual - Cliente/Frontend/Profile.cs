﻿using ShippingData;
using System;
using Chat_Virtual___Cliente.Backend;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Frontend
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            try {
                labelUser.Text += "" + Backend.Singleton.GetSingleton().userName;
                pictureBox1.Image = Serializer.DeserializeImage(Backend.Singleton.GetSingleton().ProfilePicture);
                LStatus.Text = Backend.Singleton.GetSingleton().Status;
            } catch (Exception) { }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("SASA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void PictureBox3_Click_1(object sender, EventArgs e)
        {
            try {
                OpenFileDialog dialog = new OpenFileDialog {
                    Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string imageLocation = dialog.FileName;
                    if (imageLocation != null) {
                        pictureBox1.ImageLocation = imageLocation;
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("SASA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }

        private void LabelUser_Click(object sender, EventArgs e)
        {

        }

        private void SingIn_Click(object sender, EventArgs e) {
            Singleton s = Singleton.GetSingleton();
            s.ProfilePicture = Serializer.SerializeImage(pictureBox1.Image);
            s.Status = LStatus.Text;
            s.ProfileHasChanged = true;
        }

        private void TopPanel_Paint(object sender, PaintEventArgs e) {

        }

        private void Label2_Click(object sender, EventArgs e) {

        }
    }
}
