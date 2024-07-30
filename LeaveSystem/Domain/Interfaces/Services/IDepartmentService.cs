using LeaveSystem.Domain.Dtos;
using LeaveSystem.Domain.Models;
using LeaveSystem.Domain.Models.SearchModels;

namespace LeaveSystem.Domain.Interfaces.Services
{
    public interface IDepartmentService
    {
        DepartmentDto? GetByID(Guid id);

        IEnumerable<DepartmentDto> GetList(DepartmentSearchModel searchModel);

        void Create(DepartmentModel model);

        Task CreateAsync(DepartmentModel model);

        void Update(DepartmentModel model);

        Task UpdateAsync(DepartmentModel model);

        void Delete(Guid id);

        Task DeleteAsync(Guid id);
    }
}