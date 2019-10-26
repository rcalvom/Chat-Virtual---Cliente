using DataStructures;

namespace Chat_Virtual___Cliente.Backend {
    class Request : ShippingData{
        public string request;
        public LinkedQueue<string> data;

        public Request(string user, string content, string request) {
            this.user = user;
            this.content = content;
            this.request = request;
            data = new LinkedQueue<string>();
        }
    }
}
