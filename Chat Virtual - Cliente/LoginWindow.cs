using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente {

    public partial class LoginWindow : Form {

        private NetworkStream Stream;
        private StreamWriter Writer;
        private StreamReader Reader;
        private TcpClient Client;
        private string username;
        private string userPassword;
        private string solicitud;

        public LoginWindow() {
            InitializeComponent();
            this.Client = new TcpClient();
        }

        public void Connect()
        {
            try {
                errorServerCon.Visible = false;
                passwordUserWrong.Visible = false;
                this.Client.Connect("25.7.220.122", 7777);
                this.Stream = this.Client.GetStream();
                this.Writer = new StreamWriter(this.Client.GetStream());
                this.Reader = new StreamReader(this.Client.GetStream());
                this.Writer.WriteLine(solicitud);
                this.Writer.WriteLine(username);
                this.Writer.WriteLine(userPassword);
                this.Writer.Flush();
                string respuesta = this.Reader.ReadLine();
                Console.Write("\n\n\n" + respuesta + "\n\n");
                if (respuesta == "NO") passwordUserWrong.Visible = true;
                else if (respuesta == "SI") {
                    GraphicInterface g = new GraphicInterface(Stream, Writer, Reader, Client);
                    g.Show();
                    Close();
                }
            }
            catch (Exception ex) {
                errorServerCon.Visible = true;
            }
            Cursor = Cursors.Default;
        }

        private void SingIn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            solicitud = "InicioSesion";
            username = user.Text;
            userPassword = password.Text;
            user.Clear();
            password.Clear();
            Connect();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void SingUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            solicitud = "Registro";
        }
    }
}
