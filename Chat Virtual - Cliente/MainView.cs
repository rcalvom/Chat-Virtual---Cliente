using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente {

    public partial class MainView : Form {

        private NetworkStream Stream;
        private StreamWriter Writer;
        private StreamReader Reader;
        private TcpClient Client;

        private delegate void DChatAppend(string text);

        public MainView(NetworkStream Stream, StreamWriter Writer, StreamReader Reader, TcpClient Client) {
            this.InitializeComponent();
            this.Stream = Stream;
            this.Writer = Writer;
            this.Reader = Reader;
            this.Client = Client;
            Thread t = new Thread(ChatLectura)
            {
                IsBackground = true,
            };
            t.Start();
        }

        private void GraphicInterface_Load(object sender, EventArgs e)
        {

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

        private void Slider_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChatLectura()
        {
            while (true)
            {
                if(this.Reader.BaseStream.CanRead && this.Visible) { 
                    ChatAppend(Reader.ReadLine()+"\n");
                }
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            this.Writer.WriteLine(mensaje.Text);
            this.Writer.Flush();
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

    }
}
