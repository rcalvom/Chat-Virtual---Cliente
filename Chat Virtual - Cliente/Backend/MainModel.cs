using System;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using DataStructures;
using ShippingData;

namespace Chat_Virtual___Cliente.Backend {
    class MainModel : Model {

        protected bool runThread;
        protected bool threads;

        public MainModel(TcpClient client) {
            this.Client = client;
            this.Stream = client.GetStream();
            toWrite = toRead = new LinkedQueue<Data>();
            threads = true;
            runThread = false;
            Thread thread = new Thread(DataControl);
            thread.Start();
        }
        public new bool Connect() {
            try {
                this.Client = new TcpClient();
                this.Client.Connect("25.7.220.122", 7777);
                this.Stream = this.Client.GetStream();
                threads = true;
                runThread = false;
                Thread thread = new Thread(DataControl);
                thread.Start();
                return true;
            } catch (Exception) {
                threads = false;
                return false;
            }
        }

        public new void Disconnect() {
            threads = false;
            this.Client.Close();
        }

        private void DataControl() {
            runThread = true;
            while (threads) {
                Write();
                Read();
            }
            runThread = false;
        }

        private new bool Write() {
            try {
                BinaryWriter writer = new BinaryWriter(Client.GetStream());
                Byte[] toSend = Serializer.Serialize(toWrite.GetFrontElement());
                writer.Write(toSend.Length);
                writer.Write(toSend);
                toWrite.Dequeue();
                return true;
            } catch (Exception) {
                toWrite.Enqueue(toWrite.Dequeue());
                return false;
            }
        }

        private new bool Read() {
            try {
                BinaryReader reader = new BinaryReader(Client.GetStream());
                int size = reader.ReadInt32();
                byte[] data = new byte[size];
                data = reader.ReadBytes(size);
                object a = Serializer.Deserialize(data);
                toRead.Enqueue((Data)a);
                return true;
            } catch (Exception) {
                return false;
            }
        }
    }
}
