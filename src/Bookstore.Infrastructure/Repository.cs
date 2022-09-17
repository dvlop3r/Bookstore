using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure;

public class Repository<Entity> : IRepository<Entity> where Entity : BaseEntity
{
    protected readonly AppDbContext _dbContext;
    protected DbSet<Entity> _entities;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = _dbContext.Set<Entity>();
    }

    #region Get
    public virtual Entity? GetById(object? id)
    {
        return Entities.Find(id);
    }
    public virtual async Task<Entity?> GetByIdAsync(object? id)
    {
        return await Entities.FindAsync(id);
    }

    public virtual async Task<Entity?> GetByIdNoTrackingAsync(Guid id)
    {
        var entity = await TableNoTracking.FirstOrDefaultAsync(x => x.Id == id);
        return entity;
    }

    public virtual async Task<IReadOnlyList<Entity>> ListAllAsync()
    {
        return await Entities.ToListAsync();
    }
    #endregion

    #region Insert
    public virtual Entity Insert(Entity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        return Entities.Add(entity).Entity;
    }
    public virtual async Task<Entity> InsertAsync(Entity entity)
    {
        if(entity == null)
            throw new ArgumentNullException(nameof(entity));
        var result = await Entities.AddAsync(entity);
        return result.Entity;
    }
    #endregion

    #region Update
    public virtual async Task<Entity> UpdateAsync(Entity entity, bool saveChanges = false)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        try{
            Entities.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            
            if(saveChanges)
                await _dbContext.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return entity;
    }
    #endregion

    #region Delete
    public virtual async Task<bool> DeleteAsync(Entity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        try{
            Entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return true;
    }
    #endregion

    #region Table
    public IQueryable<Entity> Table => Entities;
    public IQueryable<Entity> TableNoTracking => Entities.AsNoTracking();
    protected virtual DbSet<Entity> Entities => _entities ?? (_entities = _dbContext.Set<Entity>());
    #endregion
}