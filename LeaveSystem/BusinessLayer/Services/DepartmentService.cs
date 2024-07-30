using AutoMapper;
using LeaveSystem.Domain.Dtos;
using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Interfaces.Repositories;
using LeaveSystem.Domain.Interfaces.Services;
using LeaveSystem.Domain.Models;
using LeaveSystem.Domain.Models.SearchModels;

namespace LeaveSystem.BusinessLayer.Services
{
    public class DepartmentService : IDepartmentService
    {
        readonly IDepartmentRepository _departmentRepository;
        readonly IMapper _mapper;

        public DepartmentService(
            IDepartmentRepository departmentRepository,
            IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public void Create(DepartmentModel model)
        {
            using var transaction = _departmentRepository._dbContext.Database.BeginTransaction();
            try
            {
                var department = _mapper.Map<Department>(model);
                _departmentRepository.Create(department);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task CreateAsync(DepartmentModel model)
        {
            using var transaction = await _departmentRepository._dbContext.Database.BeginTransactionAsync();
            try
            {
                var department = _mapper.Map<Department>(model);
                await _departmentRepository.CreateAsync(department);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        public void Delete(Guid id)
        {
            var department = _departmentRepository.FirstOrDefault(x => x.ID == id);
            if (department == null)
                return;

            using var transaction = _departmentRepository._dbContext.Database.BeginTransaction();
            try
            {
                _departmentRepository.Delete(department);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var department = await _departmentRepository.FirstOrDefaultAsync(x => x.ID == id);
            if (department == null)
                return;

            using var transaction = await _departmentRepository._dbContext.Database.BeginTransactionAsync();
            try
            {
                await _departmentRepository.DeleteAsync(department);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        public DepartmentDto? GetByID(Guid id)
        {
            var department = _departmentRepository.FirstOrDefault(x => x.ID == id);
            if (department == null)
                return null;

            return _mapper.Map<DepartmentDto?>(department);
        }

        public IEnumerable<DepartmentDto> GetList(DepartmentSearchModel searchModel)
        {
            var list = _departmentRepository.GetAll();
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                list = list.Where(x => x.Name.Contains(searchModel.Name));

            return _mapper.Map<IEnumerable<DepartmentDto>>(list);
        }

        public void Update(DepartmentModel model)
        {
            using var transaction = _departmentRepository._dbContext.Database.BeginTransaction();
            try
            {
                var department = _departmentRepository.FirstOrDefault(x => x.ID == model.ID);
                if (department == null)
                    return;

                department = _mapper.Map(model, department);
                _departmentRepository.Update(department);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task UpdateAsync(DepartmentModel model)
        {
            using var transaction = await _departmentRepository._dbContext.Database.BeginTransactionAsync();
            try
            {
                var department = await _departmentRepository.FirstOrDefaultAsync(x => x.ID == model.ID);
                if (department == null)
                    return;

                department = _mapper.Map(model, department);
                await _departmentRepository.UpdateAsync(department);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }
    }
}