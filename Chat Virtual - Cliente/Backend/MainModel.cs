using System;
using System.Threading;
using DataStructures;
using ShippingData;
using Chat_Virtual___Cliente.Communication;
using System.IO;

namespace Chat_Virtual___Cliente.Backend {
    public class MainModel : Model {

        protected Semaphore CanRead;
        protected Semaphore CanWrite;

        public ChatBase CurrentChat { get; set; }
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
            CurrentChat = null;
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
            this.singleton.Disconnect();
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
            } catch (IOException) {
                Disconnect();
                return false;
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


        public UserChat SearchChat(string name) {
            Iterator<UserChat> i = Chats.Iterator();
            while (i.HasNext()) {
                UserChat c = i.Next();
                if (c.Name.Equals(name)) {
                    return c;
                }
            }
            return default;
        }

        public Group SearchGroup(int code) {
            Iterator<Group> i = Groups.Iterator();
            while (i.HasNext()) {
                Group c = i.Next();
                if (c.code == code) {
                    return c;
                } else if(c.code < 0) {
                    Groups.RemoveElement(c);
                }
            }
            return default;
        }

        public UserChat SearchSearchedChat(string name) {
            Iterator<UserChat> i = SearchedChats.Iterator();
            while (i.HasNext()) {
                UserChat c = i.Next();
                if (c.Name.Equals(name)) {
                    return c;
                }
            }
            return default;
        }

        public Group SearchSearchedGroup(int code) {
            Iterator<Group> i = SearchedGroups.Iterator();
            while (i.HasNext()) {
                Group c = i.Next();
                if (c.code == code) {
                    return c;
                } else if (c.code < 0) {
                    Groups.RemoveElement(c);
                }
            }
            return default;
        }
    }
}
