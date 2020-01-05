
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Communication {
    public abstract class ChatBase {

        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public bool Visible { get; set; }

        public Panel Panel { get; set; }

        public abstract string GetLastMessage();
    }
}
