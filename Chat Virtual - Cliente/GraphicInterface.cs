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
    public partial class GraphicInterface : Form {

        private NetworkStream Stream;
        private StreamWriter Writer;
        private StreamReader Reader;
        private TcpClient Client;
        //private readonly string Name = "ola";

        public GraphicInterface() {
            this.InitializeComponent();
            this.Client = new TcpClient();
            this.Connect();
        }

        public void Connect() {
            try {
                this.Client.Connect("localhost", 7777);
                this.Stream = this.Client.GetStream();
                this.Writer = new StreamWriter(this.Client.GetStream());
                this.Reader = new StreamReader(this.Client.GetStream());
                this.Writer.WriteLine("Ricardo");
                this.Writer.Flush();
            }catch(Exception ex) {

            }

        }

    }
}
