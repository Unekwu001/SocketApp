using SocketApp.Protocols.ProtocolServices;
using SocketApp.TcpServices.ClientService;

namespace SocketBasedBankApp.TransactionServices
{
    public class TransactionService : ITransactionService
    {
        private readonly IMyTcpClient _client;
        private readonly IISO8583Parser _parser;

        public TransactionService(IMyTcpClient client, IISO8583Parser parser)
        {
            _client = client;
            _parser = parser;
        }

        public void ProcessTransaction(string message)
        {
            var isoMessage = _parser.Parse(message);
            // Process the ISO 8583 message (e.g., log it, send to another service, etc.)
            Console.WriteLine($"Processing transaction with MTI: {isoMessage.MTI}");

            // Example of sending a response back
            string responseMessage = _parser.Serialize(isoMessage);
            _client.Send(responseMessage);
        }
    }
}