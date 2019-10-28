using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Virtual___Cliente.Messages {
    [Serializable]
    class SingUp : ShippingData {

        private string name;
        private string lastName;
        private string userName;
        private string password;
        private string repeatPassword;
        public SingUp(string name, string lastName, string userName, string password, string repeatPassword) {
            this.name = name;
            this.lastName = lastName;
            this.userName = lastName;
            this.password = password;
            this.repeatPassword = repeatPassword;
        }
    }
}
