namespace TERA.CA.OnlineBank.Core.Interfaces
{
    public interface ICrudRepository<T> where T:class
    {
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entoty);
        Task<T> GetById(Guid Id);
        Task<IEnumerable<T>> GetAll();
    }
}
