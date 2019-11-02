using System;
using System.Threading;
using DataStructures;
using ShippingData;
using Chat_Virtual___Cliente.Communication;

namespace Chat_Virtual___Cliente.Backend {
    class MainModel : Model {

        protected bool runThread;
        protected bool threads;
        public int CurrentGroup { get; set; }
        public string CurrentChat { get; set; }
        public HashTable<string, UserChat> chats { get; set; }
        public HashTable<int, Group> groups { get; set; }

        public MainModel() {
            singleton = Singleton.GetSingleton();
            toWrite = toRead = new LinkedQueue<Data>();
            chats = new HashTable<string, UserChat>(50);
            groups = new HashTable<int, Group>(20);
            threads = true;
            runThread = false;
            Thread thread = new Thread(DataControl);
            thread.Start();
        }

        public new bool Connect() {
            try {
                singleton.Client.Connect("25.7.220.122", 7777);
                singleton.SetStreams();
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
            this.singleton.Client.Close();
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
                if (!toWrite.IsEmpty()) {
                    Byte[] toSend = Serializer.Serialize(toWrite.GetFrontElement());
                    singleton.Writer.Write(toSend.Length);
                    singleton.Writer.Write(toSend);
                    toWrite.Dequeue();
                }
                return true;
            } catch (Exception) {
                toWrite.Enqueue(toWrite.Dequeue());
                return false;
            }
        }

        private new bool Read() {
            try {
                if (singleton.stream.DataAvailable) {
                    int size = singleton.Reader.ReadInt32();
                    byte[] data = new byte[size];
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
