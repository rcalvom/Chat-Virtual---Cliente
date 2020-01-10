using System;
using System.Drawing;
using DataStructures;
using ShippingData;
using System.Threading;

namespace Chat_Virtual___Cliente.Communication {
    public class UserChat : ChatBase {

        public string Status { get; set; }

        private LinkedStack<ChatMessage> Messages;
        private LinkedQueue<ChatMessage> NewMessages;
        private Semaphore SMessages;
        private Semaphore SNewMessages;

        public UserChat(Profile member) {
            this.Name = member.Name;
            this.Photo = member.Image;
            this.Status = member.Status;
            this.NumNewMessages = 0;
            this.LastMessage = new Message();
            this.LastMessage.Content = Status;
            this.LastMessage.date = new Message.Date(DateTime.Now);
            Messages = new LinkedStack<ChatMessage>();
            NewMessages = new LinkedQueue<ChatMessage>();
            SMessages = new Semaphore(1, 1);
            SNewMessages = new Semaphore(1, 1);
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
            if (LastMessage.date.CompareTo(a.date) >= 0) {
                LastMessage = a;
                NumNewMessages++;
            }
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
