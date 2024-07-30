using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeaveSystem.DataLayer.Repositories
{
    public class FunctionRepository : Repository<Function>, IFunctionRepository
    {
        public FunctionRepository(DbContext dbContext) : base(dbContext) { }
    }
}