using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeaveSystem.DataLayer.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext dbContext) : base(dbContext) { }
    }
}