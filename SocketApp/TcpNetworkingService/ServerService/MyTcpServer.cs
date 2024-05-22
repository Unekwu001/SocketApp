using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketApp.TcpServices.Server
{
    public class MyTcpServer : IMyTcpServer
    {
        private TcpListener _server;

        public void Start(int port)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();
            Console.WriteLine("Server started on port " + port);
        }

        public void Stop()
        {
            _server.Stop();
        }

        public void Listen()
        {
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                TcpClient client = _server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                NetworkStream stream = client.GetStream();
                byte[] bytes = new byte[256];
                int i;

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);

                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);
                }

                client.Close();
            }
        }



    }
}
