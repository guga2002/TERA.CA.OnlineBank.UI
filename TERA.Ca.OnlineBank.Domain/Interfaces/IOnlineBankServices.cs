using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TERA.Ca.OnlineBank.Domain.Models;

namespace TERA.Ca.OnlineBank.Domain.Interfaces
{
    public interface IOnlineBankServices
    {
        Task<bool> TransferMoney(TransactionModel mod);
        Task<WalletModel> CheckBalance(Guid Userid);
        Task<UserModel>CheckProfile(Guid Userid);

    }
}
