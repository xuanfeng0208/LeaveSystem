using AutoMapper;
using LeaveSystem.Domain.Dtos;
using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Interfaces.Repositories;
using LeaveSystem.Domain.Interfaces.Services;
using LeaveSystem.Domain.Models;
using LeaveSystem.Domain.Models.SearchModels;

namespace LeaveSystem.BusinessLayer.Services
{
    public class RoleService : IRoleService
    {
        readonly IRoleRepository _roleRepository;
        readonly IMapper _mapper;

        public RoleService(
            IRoleRepository roleRepository,
            IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public void Create(RoleModel model)
        {
            using var transaction = _roleRepository._dbContext.Database.BeginTransaction();
            try
            {
                var role = _mapper.Map<Role>(model);
                _roleRepository.Create(role);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task CreateAsync(RoleModel model)
        {
            using var transaction = await _roleRepository._dbContext.Database.BeginTransactionAsync();
            try
            {
                var role = _mapper.Map<Role>(model);
                await _roleRepository.CreateAsync(role);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        public void Delete(Guid id)
        {
            var role = _roleRepository.FirstOrDefault(x => x.ID == id);
            if (role == null)
                return;

            using var transaction = _roleRepository._dbContext.Database.BeginTransaction();
            try
            {
                _roleRepository.Delete(role);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var role = await _roleRepository.FirstOrDefaultAsync(x => x.ID == id);
            if (role == null)
                return;

            using var transaction = await _roleRepository._dbContext.Database.BeginTransactionAsync();
            try
            {
                await _roleRepository.DeleteAsync(role);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        public RoleDto? GetByID(Guid id)
        {
            var role = _roleRepository.FirstOrDefault(x => x.ID == id);
            if (role == null)
                return null;

            return _mapper.Map<RoleDto>(role);
        }

        public IEnumerable<RoleDto> GetList(RoleSearchModel searchModel)
        {
            var list = _roleRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                list = list.Where(x => x.Name.Contains(searchModel.Name));

            return _mapper.Map<IEnumerable<RoleDto>>(list);
        }

        public void Update(RoleModel model)
        {
            using var transaction = _roleRepository._dbContext.Database.BeginTransaction();
            try
            {
                var role = _roleRepository.FirstOrDefault(x => x.ID == model.ID);
                if (role == null)
                    return;

                role = _mapper.Map(model, role);
                _roleRepository.Update(role);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task UpdateAsync(RoleModel model)
        {
            using var transaction = await _roleRepository._dbContext.Database.BeginTransactionAsync();
            try
            {
                var role = await _roleRepository.FirstOrDefaultAsync(x => x.ID == model.ID);
                if (role == null)
                    return;

                role = _mapper.Map(model, role);
                await _roleRepository.UpdateAsync(role);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }
    }
}