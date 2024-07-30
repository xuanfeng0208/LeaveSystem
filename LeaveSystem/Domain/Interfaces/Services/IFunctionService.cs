using LeaveSystem.Domain.Dtos;
using LeaveSystem.Domain.Models;

namespace LeaveSystem.Domain.Interfaces.Services
{
    public interface IFunctionService
    {
        IEnumerable<FunctionDto> GetList();

        void Create(FunctionModel model);

        Task CreateAsync(FunctionModel model);

        bool IsExist(string controllerName, string actionName);
    }
}