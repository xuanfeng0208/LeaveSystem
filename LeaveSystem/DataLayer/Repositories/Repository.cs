using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LeaveSystem.DataLayer.Repositories
{
    public class Repository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        public DbContext _dbContext { get; set; }

        public Repository(
            DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Entity entity)
        {
            _dbContext.Set<Entity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task CreateAsync(Entity entity)
        {
            await _dbContext.Set<Entity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Entity? FirstOrDefault() => _dbContext.Set<Entity>().FirstOrDefault();

        public async Task<Entity?> FirstOrDefaultAsync() => await _dbContext.Set<Entity>().FirstOrDefaultAsync();

        public Entity? FirstOrDefault(Expression<Func<Entity, bool>> predicate) => _dbContext.Set<Entity>().FirstOrDefault(predicate);

        public async Task<Entity?> FirstOrDefaultAsync(Expression<Func<Entity, bool>> predicate) => await _dbContext.Set<Entity>().FirstOrDefaultAsync(predicate);

        public bool Any(Expression<Func<Entity, bool>> predicate) => _dbContext.Set<Entity>().Any(predicate);

        public IEnumerable<Entity> GetAll() => _dbContext.Set<Entity>();

        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> predicate) => _dbContext.Set<Entity>().Where(predicate);

        public void Update(Entity entity)
        {
            _dbContext.Set<Entity>().Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(Entity entity)
        {
            _dbContext.Set<Entity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}