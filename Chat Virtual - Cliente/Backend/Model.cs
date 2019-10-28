using System;
using System.IO;
using System.Net.Sockets;
using DataStructures;
using ShippingData;

namespace Chat_Virtual___Cliente.Backend {

    class Model {

        protected NetworkStream stream;
        protected TcpClient client;
        public LinkedQueue<Data> toWrite;
        public LinkedQueue<Data> toRead;

        public Model() {
            this.client = new TcpClient();
            toWrite = toRead = new LinkedQueue<Data>();
        }

        public Model(TcpClient client) {
            this.client = client;
            this.stream = client.GetStream();
            toWrite = toRead = new LinkedQueue<Data>();
        }

        public TcpClient getClient() {
            return client;
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
                BinaryWriter writer = new BinaryWriter(stream);
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
                BinaryReader reader = new BinaryReader(stream);
                while (stream.DataAvailable) {
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
                if (stream.DataAvailable) {
                    BinaryReader reader = new BinaryReader(client.GetStream());
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
