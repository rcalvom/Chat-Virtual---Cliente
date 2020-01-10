using ShippingData;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Communication {
    public abstract class ChatBase {

        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public bool Visible { get; set; }
        public bool HasChanged { get; set; }
        public int NumNewMessages { get; set; }
        public ShippingData.Message LastMessage { get; set; }
        public Panel Panel { get; set; }
    }
}
