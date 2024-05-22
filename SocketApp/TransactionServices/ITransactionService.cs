using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketBasedBankApp.TransactionServices
{
    public interface ITransactionService
    {
        void ProcessTransaction(string message);
    }
}
