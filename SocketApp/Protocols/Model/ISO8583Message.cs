using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketApp.Protocols.Model
{
    public class ISO8583Message
    {
        public string MTI { get; set; }
        public string Bitmap { get; set; }
        public Dictionary<int, string> DataElements { get; set; } = new Dictionary<int, string>();
    }
}
