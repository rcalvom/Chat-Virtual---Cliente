using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;

namespace Chat_Virtual___Cliente {

    public partial class MainView : Form {

        private MainModel model;

        private delegate void DChatAppend(string text);

        public MainView(TcpClient client, NetworkStream stream) {
            this.InitializeComponent();
            model = new MainModel(client, stream);
            Thread t = new Thread(ChatLectura) {
                IsBackground = true,
            };
            t.Start();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if ( SlidePanel.Width == 250)
            {
                SlidePanel.Visible = false;
                SlidePanel.Width = 68;
                Animation.Show(SlidePanel);
            }
            else
            {
                SlidePanel.Visible = false;
                SlidePanel.Width = 250;
                Animation2.Show(SlidePanel);
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximize.Visible = false;
            Restaurar.Visible = true;
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible = false;
            Maximize.Visible = true;
            
        }
        private void ChatLectura() {
            while (true) {
                if (!this.model.toRead.IsEmpty()) {
                    //ChatAppend(this.model.toRead.Dequeue());
                }
            }
        }

        private void Send_Click(object sender, EventArgs e){
            //this.model.toWrite.Enqueue(mensaje.Text);
            mensaje.Clear();
        }

        private void ChatAppend(string text) {
            if(this.chat.InvokeRequired) {
                var d = new DChatAppend(this.ChatAppend);
                this.chat.Invoke(d, new object[] { text });
            } else {
                this.chat.AppendText(text);
            }
        }

        private void Mensaje_KeyPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == (int)Keys.Enter) {
                Send_Click(sender, e);
            }
        }
    }
}
