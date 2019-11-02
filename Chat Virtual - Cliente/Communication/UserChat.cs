using DataStructures;
using ShippingData;

namespace Chat_Virtual___Cliente.Communication {
    class UserChat {
        public string member { get; set; }
        public LinkedStack<ChatMessage> messages { get; set; }

        public UserChat() {
            messages = new LinkedStack<ChatMessage>();
        }

        public UserChat(string member) {
            this.member = member;
            messages = new LinkedStack<ChatMessage>();
        }
    }
}
