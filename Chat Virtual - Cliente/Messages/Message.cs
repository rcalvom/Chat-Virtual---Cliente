using System;

namespace Chat_Virtual___Cliente.Messages {
    [Serializable]
    class Message : ShippingData {

        public string user;
        public string message;
        public string destinatario;

        public Message() {

        }
    }
}
