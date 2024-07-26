using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeaveSystem.DataLayer.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }
    }
}