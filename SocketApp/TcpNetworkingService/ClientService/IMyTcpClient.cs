using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketApp.TcpServices.ClientService
{
    public interface IMyTcpClient
    {
        void Connect(string ipAddress, int port);
        void Send(string message);
        string Receive();
        void Disconnect();
    }
}
