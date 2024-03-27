using Microsoft.Extensions.Logging;
using System.Transactions;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class TransactionRepository : AbstractRepository, ITransactionRepository
    {
        public TransactionRepository(WalletDb db) : base(db)
        {
        }

        public Task<bool> Create(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Transaction entoty)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetByIdWithDetails(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
