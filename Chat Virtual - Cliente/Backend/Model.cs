using Chat_Virtual___Cliente.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

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
            } catch (Exception ex) {
                throw new ConnectException();
            }
        }

        public bool Write(List<string> messages) {
            try {
                StreamWriter writer = new StreamWriter(client.GetStream());
                foreach (string message in messages) {
                    writer.WriteLine(message);
                    writer.Flush();
                }
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Write(string message) {
            try {
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine(message);
                writer.Flush();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        //despus se cambia a una colita :3
        public List<string> Read() {
            List<string> read = new List<string>();
            StreamReader reader = new StreamReader(client.GetStream());
            try {
                while(this.client.Available > 0){
                    read.Add(reader.ReadLine());
                }
            } catch (Exception ex) {
                return null;
            }
            return read;
        }

        public string ReadSingle() {
            StreamReader reader = new StreamReader(client.GetStream());
            try {
                return reader.ReadLine();
            } catch (Exception ex) {
                return null;
            }
        }
    }
}
