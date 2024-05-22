using SocketApp.Protocols.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketApp.Protocols.ProtocolServices
{
    public class ISO8583Parser : IISO8583Parser
    {


        public ISO8583Message Parse(string message)
        {
            // Assuming fixed positions for simplicity
            var isoMessage = new ISO8583Message
            {
                MTI = message.Substring(0, 4),
                Bitmap = message.Substring(4, 16)
            };

            string data = message.Substring(20);
            isoMessage.DataElements[2] = data.Substring(0, 16);  // Primary Account Number
            isoMessage.DataElements[4] = data.Substring(16, 6);  // Amount
            isoMessage.DataElements[11] = data.Substring(22, 4); // System Trace Audit Number

            return isoMessage;
        }




        public string Serialize(ISO8583Message message)
        {
            // Simplified serialization logic
            return $"{message.MTI}{message.Bitmap}{string.Join("", message.DataElements.Values)}";
        }





    }
}
