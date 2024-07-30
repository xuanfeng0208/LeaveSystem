using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeaveSystem.DataLayer.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext dbContext) : base(dbContext) { }
    }
}