using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Backend {
    public class Singleton {
        public bool ProfileHasChanged { get; set; }
        public TcpClient Client { get; }
        public NetworkStream stream { get; set; }
        public BinaryWriter Writer { get; set; }
        public BinaryReader Reader { get; set; }
        public string userName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string Status { get; set; }
        public TreeNode[] tree { get; set; }

        private static Singleton singleton;

        private Singleton() {
            this.Client = new TcpClient();
        }

        public void SetStreams() {
            this.stream = Client.GetStream();
            this.Writer = new BinaryWriter(Client.GetStream());
            this.Reader = new BinaryReader(Client.GetStream());
        }

        public static Singleton GetSingleton() {
            if (singleton == null) {
                singleton = new Singleton();
            }
            return singleton;
        }

        public void Disconect() {
            this.Client.Close();
            this.stream = null;
            this.Writer = null;
            this.Reader = null;
        }
    }
}
