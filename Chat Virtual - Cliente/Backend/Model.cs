using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using DataStructures;

namespace Chat_Virtual___Cliente.Backend {

    class Model {
        private NetworkStream stream;
        private TcpClient client;

        public Model() {
            this.client = new TcpClient();
        }

        public Model(TcpClient client, NetworkStream stream) {
            this.client = client;
            this.stream = stream;
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

        public void Connect() {
            try {
                this.client.Connect("25.7.220.122", 7777);
                this.stream = this.client.GetStream();
            } catch (Exception) {
                
            }
        }

        public bool Write(LinkedQueue<string> messages) {
            try {
                StreamWriter writer = new StreamWriter(client.GetStream());
                while (!messages.IsEmpty()) {
                    writer.WriteLine(messages.GetFrontElement());
                    writer.Flush();
                }
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public bool Write(string message) {
            try {
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine(message);
                writer.Flush();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public LinkedQueue<string> Read() {
            LinkedQueue<string> read = new LinkedQueue<string>();
            StreamReader reader = new StreamReader(client.GetStream());
            try {
                while(this.client.Available > 0){
                    read.Put(reader.ReadLine());
                }
            } catch (Exception) {
                return null;
            }
            return read;
        }

        public string ReadSingle() {
            StreamReader reader = new StreamReader(client.GetStream());
            try {
                return reader.ReadLine();
            } catch (Exception) {
                return null;
            }
        }
    }
}
