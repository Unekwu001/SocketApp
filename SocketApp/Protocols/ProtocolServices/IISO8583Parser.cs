using SocketApp.Protocols.Model;

namespace SocketApp.Protocols.ProtocolServices
{
    public interface IISO8583Parser
    {
        ISO8583Message Parse(string message);
        string Serialize(ISO8583Message message);
    }
}
