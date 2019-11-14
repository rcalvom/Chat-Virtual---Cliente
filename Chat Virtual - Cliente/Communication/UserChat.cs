using System;
using System.Drawing;
using DataStructures;
using ShippingData;
using System.Threading;

namespace Chat_Virtual___Cliente.Communication {
    class UserChat {
        public bool visible { get; set; }
        public bool searched { get; set; }
        public Profile profile { get; set; }

        private LinkedStack<ChatMessage> Messages;
        private LinkedQueue<ChatMessage> NewMessages;
        private Semaphore SMessages;
        private Semaphore SNewMessages;

        public DateTime LastView { get; set; }

        public UserChat() {
            Messages = new LinkedStack<ChatMessage>();
            NewMessages = new LinkedQueue<ChatMessage>();
            SMessages = new Semaphore(1, 1);
            SNewMessages = new Semaphore(1, 1);
            LastView = DateTime.Now;
        }

        public UserChat(Profile member) {
            this.profile = member;
            Messages = new LinkedStack<ChatMessage>();
            NewMessages = new LinkedQueue<ChatMessage>();
            SMessages = new Semaphore(1, 1);
            SNewMessages = new Semaphore(1, 1);
            LastView = DateTime.Now;
        }

        public void OldMessagesPush(ChatMessage a) {
            SMessages.WaitOne();
            Messages.Push(a);
            SMessages.Release();
        }

        public ChatMessage OldMessagePeek() {
            ChatMessage a;
            SMessages.WaitOne();
            a = Messages.Peek();
            SMessages.Release();
            return a;
        }

        public ChatMessage OldMessagePop() {
            ChatMessage a;
            SMessages.WaitOne();
            a = Messages.Pop();
            SMessages.Release();
            return a;
        }

        public void NewMessagesEnqueue(ChatMessage a) {
            SNewMessages.WaitOne();
            NewMessages.Enqueue(a);
            SNewMessages.Release();
        }

        public ChatMessage NewMessagePeek() {
            ChatMessage a;
            SNewMessages.WaitOne();
            a = NewMessages.GetFrontElement();
            SNewMessages.Release();
            return a;
        }

        public ChatMessage NewMessageDequeue() {
            ChatMessage a;
            SNewMessages.WaitOne();
            a = NewMessages.Dequeue();
            SNewMessages.Release();
            return a;
        }
    }
}
