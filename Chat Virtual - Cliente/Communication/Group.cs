using DataStructures;
using ShippingData;

namespace Chat_Virtual___Cliente.Communication {
    class Group {
        public bool visible { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public LinkedList<string> members { get; set; } 
        public LinkedStack<GroupMessage> messages { get; set; }
        public LinkedQueue<GroupMessage> NewMessages { get; set; }

        public Group() {
            members = new LinkedList<string>();
            messages = new LinkedStack<GroupMessage>();
            NewMessages = new LinkedQueue<GroupMessage>();
        }

        public Group(int code, string name) {
            this.code = code;
            this.name = name;
            members = new LinkedList<string>();
            messages = new LinkedStack<GroupMessage>();
            NewMessages = new LinkedQueue<GroupMessage>();
        }
    }
}
