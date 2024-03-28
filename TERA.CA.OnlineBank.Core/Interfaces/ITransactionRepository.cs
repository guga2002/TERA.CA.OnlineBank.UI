using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TERA.CA.OnlineBank.Core.Interfaces
{
    public interface ITransactionRepository:ICrudRepository<TERA.CA.OnlineBank.Core.Entities.Transaction>
    {
        Task<TERA.CA.OnlineBank.Core.Entities.Transaction> GetByIdWithDetails(Guid Id);

        Task<IEnumerable<TERA.CA.OnlineBank.Core.Entities.Transaction>> GetAllWithDetails();

    }
}
