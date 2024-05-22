using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocketApp.Protocols.ProtocolServices;
using SocketApp.TcpServices.ClientService;
using SocketApp.TcpServices.Server;
using SocketBasedBankApp.TransactionServices;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await StartServerAndProcessTransactionAsync();
    }

    private static async Task StartServerAndProcessTransactionAsync()
    {
        var builder = CreateHostBuilder(Array.Empty<string>()).Build();

        // Start the TCP server
        var server = builder.Services.GetRequiredService<IMyTcpServer>();
        server.Start(65432);

        try
        {
            // Simulate receiving a message and processing a transaction
            var transactionService = builder.Services.GetRequiredService<ITransactionService>();
            var client = builder.Services.GetRequiredService<IMyTcpClient>();

            client.Connect("127.0.1.1", 65431);
            string receivedMessage = client.Receive();
            transactionService.ProcessTransaction(receivedMessage);
        }
        finally
        {
            // Stop the TCP server
            server.Stop();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services.AddTransient<IMyTcpClient, MyTcpClient>()
                        .AddTransient<IMyTcpServer, MyTcpServer>()
                        .AddTransient<IISO8583Parser, ISO8583Parser>()
                        .AddTransient<ITransactionService, TransactionService>());
    }
}
