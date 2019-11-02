﻿using System;
using System.IO;
using System.Net.Sockets;

namespace Chat_Virtual___Cliente.Backend {
    class Singleton {
        public TcpClient Client { get; }
        public NetworkStream stream { get; set; }
        public BinaryWriter Writer { get; set; }
        public BinaryReader Reader { get; set; }
        private static Singleton singleton;

        private Singleton() {
            this.Client = new TcpClient();
        }

        public void SetStreams() {
            this.stream = Client.GetStream();
            this.Writer = new BinaryWriter(Client.GetStream());
            this.Reader = new BinaryReader(Client.GetStream());
        }

        public static Singleton GetSingleton() {
            if (singleton == null) {
                singleton = new Singleton();
            }
            return singleton;
        }
    }
}