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

    public async Task<IEnumerable<T>> GetAll() => await _entities.ToListAsync();

    public async Task<T> GetById(int id) => await _entities.FindAsync(id);

    public async Task<bool> Add(T entity)
    {
        await _entities.AddAsync(entity);
        var isTrue = await _context.SaveChangesAsync();

        return isTrue > 0 ? true : false;
    }

    public async Task AddRange(IEnumerable<T> entities)
    {
        await _entities.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Update(T entity)
    {
        var updateEntity = _entities.Update(entity);

        var isTrue = await _context.SaveChangesAsync();

        return isTrue > 0 ? true : false;
    }

    public async Task<bool> Remove(int id)
    {
        var entity = await _entities.FindAsync(id);
        _entities.Remove(entity);

        var isTrue = await _context.SaveChangesAsync();

        return isTrue > 0 ? true : false;
    }
}