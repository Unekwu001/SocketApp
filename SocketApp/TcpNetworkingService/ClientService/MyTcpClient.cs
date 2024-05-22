using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketApp.TcpServices.ClientService
{
    public class MyTcpClient : IMyTcpClient
    { 

        private TcpClient _client; 
        private NetworkStream _stream;

        public void Connect(string ipAddress, int port)
        {
            _client = new TcpClient(); 
            _client.Connect(ipAddress, port);
            _stream = _client.GetStream();
        }

        public void Send(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            _stream.Write(data, 0, data.Length);
        }

        public string Receive()
        {
            byte[] data = new byte[256];
            int bytes = _stream.Read(data, 0, data.Length);
            return Encoding.ASCII.GetString(data, 0, bytes);
        }

        public void Disconnect()
        {
            _stream.Close();
            _client.Close();
        }
    }
}
