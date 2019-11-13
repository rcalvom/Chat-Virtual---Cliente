using DataStructures;
using ShippingData;
using System;
using System.Threading;

namespace Chat_Virtual___Cliente.Communication {
    class Group {
        public bool visible { get; set; }
        public bool searched { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public LinkedList<string> members { get; set; }

        private LinkedStack<GroupMessage> Messages;
        private LinkedQueue<GroupMessage> NewMessages;
        private Semaphore SMessages;
        private Semaphore SNewMessages;

        public DateTime LastView { get; set; }

        public Group() {
            members = new LinkedList<string>();
            Messages = new LinkedStack<GroupMessage>();
            NewMessages = new LinkedQueue<GroupMessage>();
            SMessages = new Semaphore(1, 1);
            SNewMessages = new Semaphore(1, 1);
            LastView = DateTime.Now;
        }

        public Group(int code, string name) {
            this.code = code;
            this.name = name;
            members = new LinkedList<string>();
            Messages = new LinkedStack<GroupMessage>();
            NewMessages = new LinkedQueue<GroupMessage>();
            SMessages = new Semaphore(1, 1);
            SNewMessages = new Semaphore(1, 1);
            LastView = DateTime.Now;
        }

        public void OldMessagesPush(GroupMessage a) {
            SMessages.WaitOne();
            Messages.Push(a);
            SMessages.Release();
        }

        public GroupMessage OldMessagePeek() {
            GroupMessage a;
            SMessages.WaitOne();
            a = Messages.Peek();
            SMessages.Release();
            return a;
        }

        public GroupMessage OldMessagePop() {
            GroupMessage a;
            SMessages.WaitOne();
            a = Messages.Pop();
            SMessages.Release();
            return a;
        }

        public void NewMessagesEnqueue(GroupMessage a) {
            SNewMessages.WaitOne();
            NewMessages.Enqueue(a);
            SNewMessages.Release();
        }

        public GroupMessage NewMessagePeek() {
            GroupMessage a;
            SNewMessages.WaitOne();
            a = NewMessages.GetFrontElement();
            SNewMessages.Release();
            return a;
        }

        public GroupMessage NewMessageDequeue() {
            GroupMessage a;
            SNewMessages.WaitOne();
            a = NewMessages.Dequeue();
            SNewMessages.Release();
            return a;
        }
    }
}
