using TERA.Ca.OnlineBank.Domain.Models;

namespace TERA.Ca.OnlineBank.Domain.Interfaces
{
    public interface IStatisticServices
    {
        Task<IEnumerable<string>> GetMostPopulatTransactionsTypes(int count);

        Task<IEnumerable<TransactionModel>> GetTransactionsByTransactionType(string type);

        Task<IEnumerable<TransactionModel>> GetTransactonsByPeriod(DateTime start, DateTime end);
    }
}
