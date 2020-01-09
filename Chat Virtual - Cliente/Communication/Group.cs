using DataStructures;
using ShippingData;
using System;
using System.Threading;

namespace Chat_Virtual___Cliente.Communication {
    public class Group : ChatBase {
        public int code { get; set; }
        public LinkedList<string> members { get; set; }

        private LinkedStack<GroupMessage> Messages;
        private LinkedQueue<GroupMessage> NewMessages;
        private Semaphore SMessages;
        private Semaphore SNewMessages;

        public Group() {
            members = new LinkedList<string>();
            Messages = new LinkedStack<GroupMessage>();
            NewMessages = new LinkedQueue<GroupMessage>();
            SMessages = new Semaphore(1, 1);
            SNewMessages = new Semaphore(1, 1);
            this.NumNewMessages = 0;
            this.LastMessage = new Message();
            this.LastMessage.Content = "¡Bienvenido al grupo!";
            this.LastMessage.date = new Message.Date(DateTime.Now);
        }

        public Group(int code, string name) {
            this.code = code;
            this.Name = name;
            members = new LinkedList<string>();
            Messages = new LinkedStack<GroupMessage>();
            NewMessages = new LinkedQueue<GroupMessage>();
            SMessages = new Semaphore(1, 1);
            SNewMessages = new Semaphore(1, 1);
            this.NumNewMessages = 0;
            this.LastMessage = new Message();
            this.LastMessage.Content = "¡Bienvenido al grupo!";
            this.LastMessage.date = new Message.Date(DateTime.Now);
        }

        public Group(ChatGroup group) {
            this.code = group.idGroup;
            this.Name = group.name;
            this.Photo = group.photo;
            members = new LinkedList<string>();
            Messages = new LinkedStack<GroupMessage>();
            NewMessages = new LinkedQueue<GroupMessage>();
            SMessages = new Semaphore(1, 1);
            SNewMessages = new Semaphore(1, 1);
            this.NumNewMessages = 0;
            this.LastMessage = new Message();
            this.LastMessage.Content = "¡Bienvenido al grupo!";
            this.LastMessage.date = new Message.Date(DateTime.Now);
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
            if (LastMessage.date.CompareTo(a.date) < 0) {
                LastMessage = a;
                NumNewMessages++;
            }
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
