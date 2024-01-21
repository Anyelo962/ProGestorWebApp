using ProGestor.Common.Entities;

namespace ProGestor.Common.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<bool> Add(T entity);
    Task AddRange(IEnumerable<T> entities);
    Task<bool> Update(T entity);
    Task<bool> Remove(int id);
}