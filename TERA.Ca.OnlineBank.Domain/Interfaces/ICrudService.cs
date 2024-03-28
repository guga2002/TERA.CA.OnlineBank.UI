namespace TERA.Ca.OnlineBank.Domain.Interfaces
{
    public interface ICrudService<T>where T:class
    {
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid Id);
        Task<T> GetById(Guid Id);
        Task<IEnumerable<T>> GetAll();
    }
}
