using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Virtual___Cliente.Exceptions {
    class ConnectException : Exception {

        public ConnectException() : base("The connection with the server has failed") {
        }

        public ConnectException(string message) : base(message) {
        }

        public ConnectException(string message, Exception innerException) : base(message, innerException) {
        }

        protected ConnectException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}
