using System;
using System.IO;
using System.Net.Sockets;
using DataStructures;
using ShippingData;

namespace Chat_Virtual___Cliente.Backend {

    class Model {

        protected NetworkStream stream;
        protected TcpClient client;
        public LinkedQueue<ShippingData.ShippingData> toWrite;
        public LinkedQueue<ShippingData.ShippingData> toRead;

        public Model() {
            this.client = new TcpClient();
            toWrite = toRead = new LinkedQueue<ShippingData.ShippingData>();
        }

        public Model(TcpClient client, NetworkStream stream) {
            this.client = client;
            this.stream = stream;
            toWrite = toRead = new LinkedQueue<ShippingData.ShippingData>();
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

        public bool Write() {
            try {
                Console.WriteLine("Holi");
                BinaryWriter writer = new BinaryWriter(client.GetStream());
                Console.WriteLine("Creado el writer");
                while (!toWrite.IsEmpty()) {
                    Byte[] toSend = Serializer.Serialize(toWrite.Dequeue());
                    Console.WriteLine("Datos serializados");
                    writer.Write(toSend.Length);
                    Console.WriteLine("Escrito el tamaño");
                    writer.Write(toSend);
                    Console.WriteLine("Datos enviados");
                }
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public bool Read() {
            try {
                BinaryReader reader = new BinaryReader(client.GetStream());
                while (!toRead.IsEmpty()) {
                    int size = reader.ReadInt32();
                    byte []data = new byte[size];
                    data = reader.ReadBytes(size);
                    object a = Serializer.Deserialize(data);
                    toRead.Enqueue((ShippingData.ShippingData)a);
                }
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public bool readBool(bool a) {
            try {
                BinaryReader reader = new BinaryReader(client.GetStream());
                a = reader.ReadBoolean();
            } catch (Exception) {
                return false;
            }
            return true; ;
        }
    }
}
