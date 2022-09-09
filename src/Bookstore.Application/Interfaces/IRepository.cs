using Bookstore.Domain.Entities;

namespace Bookstore.Application.Interfaces;

public interface IRepository<Entity> where Entity : BaseEntity
{
    Entity? GetById(object? id);
    Task<Entity?> GetByIdAsync(object? id);
    Task<Entity?> GetByIdNoTrackingAsync(Guid id);
    Task<IReadOnlyList<Entity>> ListAllAsync();
    Entity Insert(Entity entity);
    Task<Entity> InsertAsync(Entity entity);
    Task UpdateAsync(Entity entity, bool saveChanges = false);
    Task DeleteAsync(Entity entity);
    IQueryable<Entity> Table { get; }
    IQueryable<Entity> TableNoTracking { get; }
}