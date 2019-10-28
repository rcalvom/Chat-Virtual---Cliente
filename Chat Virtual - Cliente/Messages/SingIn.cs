using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Virtual___Cliente.Messages {
    [Serializable]
    class SingIn : ShippingData{
        public string user;
        public string password;

        public SingIn(string user, string password) {
            this.user = user;
            this.password = password;
        }
    }
}
