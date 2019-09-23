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

        public LoginWindow() {
            InitializeComponent();
            this.Client = new TcpClient();
        }

        public void Connect() {
            Cursor = Cursors.WaitCursor;
            username = user.Text;
            userPassword = password.Text;
            user.Clear();
            password.Clear();
            try {
                errorServerCon.Visible = false;
                passwordUserWrong.Visible = false;
                this.Client.Connect("25.7.220.122", 7777);
                this.Stream = this.Client.GetStream();
                this.Writer = new StreamWriter(this.Client.GetStream());
                this.Reader = new StreamReader(this.Client.GetStream());
            }
            catch (Exception ex) {
                errorServerCon.Visible = true;
            }

            try {

                this.Writer.WriteLine("InicioSesion");
                this.Writer.WriteLine(username);
                this.Writer.WriteLine(userPassword);
                this.Writer.Flush();
                string serverAnswer = this.Reader.ReadLine();
                if (serverAnswer == "NO") passwordUserWrong.Visible = true;
                else if (serverAnswer == "SI") {
                    MainView mainView = new MainView(Stream, Writer, Reader, Client);
                    mainView.Show();
                    Close();
                }
            } catch (Exception ex) { }

            Cursor = Cursors.Default;
        }

        private void SingIn_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinButton_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void SingUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            SingUp singUp = new SingUp();
            singUp.Show();
            Close();
        }

        private void MinButton_MouseEnter(object sender, EventArgs e) {
            minButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }
        private void MinButton_MouseLeave(object sender, EventArgs e) {
            minButtonPanel.BackColor = topPane.BackColor;
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e) {
            closeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e) {
            closeButtonPanel.BackColor = topPane.BackColor;
        }
    }
}
