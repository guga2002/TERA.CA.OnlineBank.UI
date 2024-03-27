using Microsoft.Extensions.Logging;
using TERA.CA.OnlineBank.Core.Data;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public abstract class AbstractRepository
    {
        protected  readonly WalletDb Context;
        protected AbstractRepository(WalletDb db)
        {
            this.Context = db;
        }

    }
}
