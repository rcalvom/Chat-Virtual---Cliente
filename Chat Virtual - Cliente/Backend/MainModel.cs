using System;
using System.Threading;
using DataStructures;
using ShippingData;
using Chat_Virtual___Cliente.Communication;

namespace Chat_Virtual___Cliente.Backend {
    public class MainModel : Model {

        protected Semaphore CanRead;
        protected Semaphore CanWrite;

        public int CurrentGroup { get; set; }
        public string CurrentChat { get; set; }
        public LinkedList<UserChat> Chats { get; set; }
        public LinkedList<UserChat> SearchedChats { get; set; }
        public LinkedList<Group> Groups { get; set; }
        public LinkedList<Group> SearchedGroups { get; set; }

        public MainModel() {
            singleton = Singleton.GetSingleton();
            toWrite = new LinkedQueue<Data>();
            toRead = new LinkedQueue<Data>();
            Chats = new LinkedList<UserChat>();
            SearchedChats = new LinkedList<UserChat>();
            Groups = new LinkedList<Group>();
            SearchedGroups = new LinkedList<Group>();
            CanRead = new Semaphore(1, 1);
            CanWrite = new Semaphore(1, 1);
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

        public void DataControl() {
            Data data = ToWriteDequeue();
            if (data != default)
                if (!Write(data))
                    ToWriteEnqueue(data);
            Read(); 
        }

        public new void Disconnect() {
            this.singleton.Client.Close();
        }

        public new bool Connect() {
            try {
                singleton.Client.Connect("25.7.220.122", 7777);
                singleton.SetStreams();
                return true;
            } catch (Exception) {
                Disconnect();
                return false;
            }
        }

        private bool Write(Data a) {
            try {
                Byte[] toSend = Serializer.Serialize(a);
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
