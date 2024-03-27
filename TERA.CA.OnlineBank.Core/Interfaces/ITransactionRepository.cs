using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TERA.CA.OnlineBank.Core.Interfaces
{
    public interface ITransactionRepository:ICrudRepository<Transaction>
    {
        Task<Transaction> GetByIdWithDetails(Guid Id);

        Task<IEnumerable<Transaction>> GetAllWithDetails();

    }
}
