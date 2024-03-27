using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERA.CA.OnlineBank.Core.Entities;

namespace TERA.CA.OnlineBank.Core.Interfaces
{
    public interface IWalletRepository:ICrudRepository<Wallet>
    {
        Task<Wallet> GetByIdWithDetails(Guid Id);
        Task<IEnumerable<Wallet>> GetAllWithDetails();
    }
}
