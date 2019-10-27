using System;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using DataStructures;

namespace Chat_Virtual___Cliente.Backend {

    class Model {

        protected NetworkStream stream;
        protected TcpClient client;
        public LinkedQueue<string> toWriteString;
        public LinkedQueue<string> toReadString;

        public Model() {
            this.client = new TcpClient();
            toWriteString = toReadString = new LinkedQueue<string>();
        }

        public Model(TcpClient client, NetworkStream stream) {
            this.client = client;
            this.stream = stream;
            toWriteString = toReadString = new LinkedQueue<string>();
        }

        public TcpClient getClient() {
            return client;
        }

        public NetworkStream getStream() {
            return stream;
        }

        public bool IsConnected() {
            return client.Connected;
        }

        public bool Connect() {
            try {
		        this.client = new TcpClient();
                this.client.Connect("25.7.220.122", 7777);
                this.stream = this.client.GetStream();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public void Disconnect() {
            this.client.Close();
        }

        public bool WriteString() {
            try {
                StreamWriter writer = new StreamWriter(client.GetStream());
                while (!toWriteString.IsEmpty()) {
                    writer.WriteLine(toWriteString.GetFrontElement());
                    writer.Flush();
                    toWriteString.Dequeue();
                }
                return true;
            } catch (Exception) {
                undoChangesInQueue(toWriteString);
                return false;
            }
        }

        public bool ReadString() {
            try {
                StreamReader reader = new StreamReader(client.GetStream());
                while (!toReadString.IsEmpty())
                    toReadString.Enqueue(reader.ReadLine());
                return true;
            } catch (Exception) {
                undoChangesInQueue(toReadString);
                return false;
            }
        }

        protected void undoChangesInQueue(LinkedQueue<String> queue) {
            string data;
            do {
                data = queue.Dequeue();
            } while (data != null);
        }
    }
}
