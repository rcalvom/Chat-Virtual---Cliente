using System;
using System.Threading;
using DataStructures;
using ShippingData;
using Chat_Virtual___Cliente.Communication;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Backend {
    class MainModel : Model {

        protected bool runThread;
        protected bool threads;
        protected Semaphore CanRead;
        protected Semaphore CanWrite;
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
            CanRead = new Semaphore(1, 1);
            CanWrite = new Semaphore(1, 1);
            Thread thread = new Thread(DataControl);
            thread.Start();
        }

        public void ToWriteEnqueue(Data a) {
            CanWrite.WaitOne();
            toWrite.Enqueue(a);
            CanWrite.Release();
        }

        public void ToReadEnqueue(Data a) {
            CanRead.WaitOne();
            toRead.Enqueue(a);
            CanRead.Release();
        }

        public Data ToWriteDequeue() {
            CanWrite.WaitOne();
            Data a = toWrite.Dequeue();
            CanWrite.Release();
            return a;
        }

        public Data ToReadDequeue() {
            CanRead.WaitOne();
            Data a = toRead.Dequeue();
            CanRead.Release();
            return a;
        }

        private void DataControl() {
            runThread = true;
            while (threads) {
                Data data = ToWriteDequeue();
                if (data != default)
                    if (!Write(data))
                        ToWriteEnqueue(data);
                Read();
            }
            runThread = false;
        }

        public new void Disconnect() {
            threads = false;
            this.singleton.Client.Close();
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

        private bool Write(Data a) {
            try {
                Byte[] toSend = Serializer.Serialize(a);
                if (toSend.Length <= 0)
                    return false;
                singleton.Writer.Write(toSend.Length);
                singleton.Writer.Write(toSend);
                return true;
            } catch (Exception) {
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
                    ToReadEnqueue((Data)a);
                }
                return true;
            } catch (Exception) {
                return false;
            }
        }
    }
}
