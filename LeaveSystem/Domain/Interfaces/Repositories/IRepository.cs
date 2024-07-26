using LeaveSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LeaveSystem.Domain.Interfaces.Repositories
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        DbContext _dbContext { get; set; }

        Entity? FirstOrDefault();

        Entity? FirstOrDefault(Expression<Func<Entity, bool>> predicate);

        Task<Entity?> FirstOrDefaultAsync(Expression<Func<Entity, bool>> predicate);

        IEnumerable<Entity> GetAll();

        IEnumerable<Entity> Where(Expression<Func<Entity, bool>> predicate);

        void Create(Entity entity);

        Task CreateAsync(Entity entity);

        void Update(Entity entity);

        Task UpdateAsync(Entity entity);

        void Delete(Entity entity);

        Task DeleteAsync(Entity entity);
    }
}