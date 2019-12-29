using System;
using ShippingData;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Frontend {

    public partial class SendImage : Form {

        public byte[] ImageSelected { get; private set; }
        public string Coment { get; private set; }

        public SendImage() {
            InitializeComponent();
            ImageSelected = null;
            Coment = "";
        }

        private void SendButton_Click(object sender, EventArgs e) {
            Coment = ComentTextBox.Text;
            ImageSelected = Serializer.SerializeImage(SelectPictureBox.Image);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void Select_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    SelectPictureBox.ImageLocation = dialog.FileName;
                    SendButton.Enabled = true;
                }

            } catch (Exception) {
                MessageBox.Show("SASA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
