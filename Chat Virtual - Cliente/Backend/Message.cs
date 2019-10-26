using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Virtual___Cliente.Backend {
    class Message : ShippingData {

        public string message;
        //y una imagen :3

        public Message(string user, string content) {
            this.user = user;
            this.content = content;
        }
    }
}
