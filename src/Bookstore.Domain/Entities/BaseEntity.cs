namespace Bookstore.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Updated { get; set; }
    }
}