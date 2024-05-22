using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketApp.TcpServices.Server
{
    public interface IMyTcpServer
    {
        void Start(int port);
        void Stop();
        void Listen();
    }
}
