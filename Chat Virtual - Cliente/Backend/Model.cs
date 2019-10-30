using System;
using System.IO;
using System.Net.Sockets;
using DataStructures;
using ShippingData;

namespace Chat_Virtual___Cliente.Backend {

    class Model {

        protected NetworkStream Stream { get; set; }
        protected TcpClient Client { get; set; }
        public LinkedQueue<Data> toWrite { get; set; }
        public LinkedQueue<Data> toRead { get; set; }

        public Model() {
            this.Client = new TcpClient();
            toWrite = toRead = new LinkedQueue<Data>();
        }

        public Model(TcpClient client) {
            this.Client = client;
            this.Stream = client.GetStream();
            toWrite = toRead = new LinkedQueue<Data>();
        }

        public bool IsConnected() {
            return Client.Connected;
        }

        public bool Connect() {
            try {
		        this.Client = new TcpClient();
                this.Client.Connect("25.7.220.122", 7777);
                this.Stream = this.Client.GetStream();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public void Disconnect() {
            this.Client.Close();
        }

        public bool Write() {
            try {
                BinaryWriter writer = new BinaryWriter(Stream);
                Console.WriteLine("Creado el writer");
                while (!toWrite.IsEmpty()) {
                    Byte[] toSend = Serializer.Serialize(toWrite.Dequeue());
                    writer.Write(toSend.Length);
                    writer.Write(toSend);
                }
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public bool Read() {
            try {
                BinaryReader reader = new BinaryReader(Stream);
                while (Stream.DataAvailable) {
                    int size = reader.ReadInt32();
                    byte []data = new byte[size];
                    data = reader.ReadBytes(size);
                    object a = Serializer.Deserialize(data);
                    toRead.Enqueue((Data)a);
                }
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public bool readBool(ref bool a) {
            try {
                if (Stream.DataAvailable) {
                    BinaryReader reader = new BinaryReader(Client.GetStream());
                    a = reader.ReadBoolean();
                    return true;
                } else {
                    return false;
                }
            } catch (Exception) {
                return false;
            }
        }
    }
}
