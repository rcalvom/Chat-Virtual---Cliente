using System;
using System.Drawing;
using DataStructures;
using ShippingData;

namespace Chat_Virtual___Cliente.Communication {
    class UserChat {
        public bool visible { get; set; }
        public bool searched { get; set; }
        public Profile profile { get; set; }
        public LinkedStack<ChatMessage> messages { get; set; }
        public LinkedQueue<ChatMessage> NewMessages { get; set; }
        public DateTime LastView { get; set; }

        public UserChat() {
            messages = new LinkedStack<ChatMessage>();
            NewMessages = new LinkedQueue<ChatMessage>();
            LastView = DateTime.Now;
        }

        public UserChat(string member) {
            this.profile = new Profile();
            profile.Name = member;
            messages = new LinkedStack<ChatMessage>();
            NewMessages = new LinkedQueue<ChatMessage>();
            LastView = DateTime.Now;
        }
    }
}
