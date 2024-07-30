using AutoMapper;
using LeaveSystem.Domain.Dtos;
using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Interfaces.Repositories;
using LeaveSystem.Domain.Interfaces.Services;
using LeaveSystem.Domain.Models;
using LeaveSystem.Domain.Models.SearchModels;

namespace LeaveSystem.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void Create(UserModel model)
        {
            using var transaction = _userRepository._dbContext.Database.BeginTransaction();
            try
            {
                var user = _mapper.Map<User>(model);
                _userRepository.Create(user);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task CreateAsync(UserModel model)
        {
            using var transaction = await _userRepository._dbContext.Database.BeginTransactionAsync();
            try
            {
                var user = _mapper.Map<User>(model);
                await _userRepository.CreateAsync(user);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        public void Delete(Guid id)
        {
            var user = _userRepository.FirstOrDefault(x => x.ID == id);
            if (user == null)
                return;

            using var transaction = _userRepository._dbContext.Database.BeginTransaction();
            try
            {
                _userRepository.Delete(user);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.ID == id);
            if (user == null)
                return;

            using var transaction = await _userRepository._dbContext.Database.BeginTransactionAsync();
            try
            {
                await _userRepository.DeleteAsync(user);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        public UserDto? GetByID(Guid id)
        {
            var user = _userRepository.FirstOrDefault(x => x.ID == id);
            if (user == null)
                return null;

            return _mapper.Map<UserDto>(user);
        }

        public IEnumerable<UserDto> GetList(UserSearchModel searchModel)
        {
            var userList = _userRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                userList = userList.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                userList = userList.Where(x => x.Email.Contains(searchModel.Email));

            return _mapper.Map<IEnumerable<UserDto>>(userList);
        }

        public void Update(UserModel model)
        {
            using var transaction = _userRepository._dbContext.Database.BeginTransaction();
            try
            {
                var user = _userRepository.FirstOrDefault(x => x.ID == model.ID);
                if (user == null)
                    return;

                user = _mapper.Map(model, user);
                _userRepository.Update(user);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task UpdateAsync(UserModel model)
        {
            using var transaction = await _userRepository._dbContext.Database.BeginTransactionAsync();
            try
            {
                var user = await _userRepository.FirstOrDefaultAsync(x => x.ID == model.ID);
                if (user == null)
                    return;

                user = _mapper.Map(model, user);
                await _userRepository.UpdateAsync(user);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }
    }
}