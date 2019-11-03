﻿using System.Drawing;
using DataStructures;
using ShippingData;

namespace Chat_Virtual___Cliente.Communication {
    class UserChat {
        public string member { get; set; }
        public Image photo { get; set; }
        public LinkedStack<ChatMessage> messages { get; set; }
        public LinkedQueue<ChatMessage> NewMessages { get; set; }

        public UserChat() {
            messages = new LinkedStack<ChatMessage>();
            NewMessages = new LinkedQueue<ChatMessage>();
        }

        public UserChat(string member) {
            this.member = member;
            messages = new LinkedStack<ChatMessage>();
            NewMessages = new LinkedQueue<ChatMessage>();
        }
    }
}
