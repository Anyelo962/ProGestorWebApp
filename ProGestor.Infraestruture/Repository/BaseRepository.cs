using Microsoft.EntityFrameworkCore;
using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class BaseRepository<T>: IBaseRepository<T> where T : BaseEntity
{
    private readonly ProGestorDbContext _context;
    private DbSet<T> _entities;

    public BaseRepository(ProGestorDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }
    public Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task AddRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Remove(int id)
    {
        throw new NotImplementedException();
    }
}