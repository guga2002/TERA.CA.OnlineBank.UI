namespace TERA.CA.OnlineBank.Core.Interfaces
{
    public interface IUniteOfWork:IDisposable
    {
        public ICurencyRepository CurencyRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
        public IUserRepository UserRepository { get; }
        public IWalletRepository WalletRepository { get; }
        public ITransactionType TransactionType { get; }
        Task SaveChanges();
    }
}
