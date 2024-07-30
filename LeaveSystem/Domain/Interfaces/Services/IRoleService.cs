using LeaveSystem.Domain.Dtos;
using LeaveSystem.Domain.Models;
using LeaveSystem.Domain.Models.SearchModels;

namespace LeaveSystem.Domain.Interfaces.Services
{
    public interface IRoleService
    {
        RoleDto? GetByID(Guid id);

        IEnumerable<RoleDto> GetList(RoleSearchModel searchModel);

        void Create(RoleModel model);

        Task CreateAsync(RoleModel model);

        void Update(RoleModel model);

        Task UpdateAsync(RoleModel model);

        void Delete(Guid id);

        Task DeleteAsync(Guid id);
    }
}