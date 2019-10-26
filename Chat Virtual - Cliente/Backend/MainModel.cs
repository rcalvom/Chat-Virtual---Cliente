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
        public bool threads;
        public bool readString;
        public bool writeString;
        public bool readData;
        public bool writeData;
        public new bool Connect() {
            try {
                this.client = new TcpClient();
                this.client.Connect("25.7.220.122", 7777);
                this.stream = this.client.GetStream();
                threads = readString = readData = writeString = writeData = true;
                runThread = false;
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public new void Disconnect() {
            threads = runThread = false;
            this.client = new TcpClient();
        }

        private void DataControl() {
            runThread = true;
            while (threads) {
                writeString = WriteString();
                readString = ReadString();
                //writeData = WriteData();
                //readString = ReadData();
            }
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
