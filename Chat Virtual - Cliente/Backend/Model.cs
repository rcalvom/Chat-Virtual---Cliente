using System;
using System.IO;
using System.Net.Sockets;
using DataStructures;
using ShippingData;

namespace Chat_Virtual___Cliente.Backend {

    class Model {

        public Singleton singleton { get; set; }
        public LinkedQueue<Data> toWrite { get; set; }
        public LinkedQueue<Data> toRead { get; set; }

        public Model() {
            toWrite = toRead = new LinkedQueue<Data>();
            singleton = Singleton.GetSingleton();
        }

        public bool IsConnected() {
            return singleton.Client.Connected;
        }

        public bool Connect() {
            try {
                singleton.Client.Connect("25.7.220.122", 7777);
                singleton.SetStreams();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public void Disconnect() {
            this.singleton.Client.Close();
        }

        public bool Write() {
            try {
                while (!toWrite.IsEmpty()) {
                    Byte[] toSend = Serializer.Serialize(toWrite.Dequeue());
                    singleton.Writer.Write(toSend.Length);
                    singleton.Writer.Write(toSend);
                }
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public bool Read() {
            try {
                while (this.singleton.stream.DataAvailable) {
                    int size = singleton.Reader.ReadInt32();
                    byte []data = new byte[size];
                    data = singleton.Reader.ReadBytes(size);
                    object a = Serializer.Deserialize(data);
                    toRead.Enqueue((Data)a);
                }
                return true;
            } catch (Exception) {
                return false;
            }
        }
    }
}
