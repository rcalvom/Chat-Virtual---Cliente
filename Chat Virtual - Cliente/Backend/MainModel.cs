using System;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using DataStructures;

namespace Chat_Virtual___Cliente.Backend {
    class MainModel : Model {

        public LinkedQueue<ShippingData> toWriteData;
        public LinkedQueue<ShippingData> toReadData;
        protected bool runThread;
        protected bool threads;
        public MainModel(TcpClient client, NetworkStream stream) {
            this.client = client;
            this.stream = stream;
            toWriteString = toReadString = new LinkedQueue<string>();
            toWriteData = toReadData = new LinkedQueue<ShippingData>();
            threads = true;
            runThread = false;
            Thread thread = new Thread(DataControl);
            thread.Start();
        }
        public new bool Connect() {
            try {
                this.client = new TcpClient();
                this.client.Connect("25.7.220.122", 7777);
                this.stream = this.client.GetStream();
                threads = true;
                runThread = false;
                Thread thread = new Thread(DataControl);
                thread.Start();
                return true;
            } catch (Exception) {
                threads = false;
                return false;
            }
        }

        public new void Disconnect() {
            threads = false;
            this.client.Close();
        }

        private void DataControl() {
            runThread = true;
            while (threads) {
                WriteString();
                ReadString();
                WriteData();
                ReadData();
            }
            runThread = false;
        }

        private new bool WriteString() {
            try {
                StreamWriter writer = new StreamWriter(client.GetStream());
                if (!toWriteString.IsEmpty()) {
                    writer.WriteLine(toWriteString.GetFrontElement());
                    writer.Flush();
                    toWriteString.Dequeue();
                }
                return true;
            } catch (Exception) {
                return false;
            }
        }

        private new bool ReadString() {
            try {
                StreamReader reader = new StreamReader(client.GetStream());
                if (this.client.Available > 0)
                    toReadString.Enqueue(reader.ReadLine());
                return true;
            } catch (Exception) {
                return false;
            }
        }

        private bool WriteData() {
            try {
                return true;
            } catch (Exception) {
                return false;
            }
        }

        private bool ReadData() {
            try {
                return true;
            } catch (Exception) {
                return false;
            }
        }

        protected void undoChangesInQueue(LinkedQueue<ShippingData> queue) {
            ShippingData data;
            do {
                data = queue.Dequeue();
            } while (data != null);
        }
    }
}
