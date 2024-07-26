using LeaveSystem.Domain.Dtos;
using LeaveSystem.Domain.Models;
using LeaveSystem.Domain.Models.SearchModels;

namespace LeaveSystem.Domain.Interfaces.Services
{
    public interface IUserService
    {
        UserDto? GetByID(Guid id);

        IEnumerable<UserDto> GetList(UserSearchModel searchModel);

        void Create(UserModel model);

        Task CreateAsync(UserModel model);

        void Update(UserModel model);

        Task UpdateAsync(UserModel model);

        void Delete(Guid id);

        Task DeleteAsync(Guid id);
    }
}