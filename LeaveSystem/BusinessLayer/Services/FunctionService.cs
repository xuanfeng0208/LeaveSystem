using AutoMapper;
using LeaveSystem.Domain.Dtos;
using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Interfaces.Repositories;
using LeaveSystem.Domain.Interfaces.Services;
using LeaveSystem.Domain.Models;

namespace LeaveSystem.BusinessLayer.Services
{
    public class FunctionService : IFunctionService
    {
        readonly IFunctionRepository _functionRepository;
        readonly IMapper _mapper;

        public FunctionService(
            IFunctionRepository functionRepository,
            IMapper mapper)
        {
            _functionRepository = functionRepository;
            _mapper = mapper;
        }

        public void Create(FunctionModel model)
        {
            using var transaction = _functionRepository._dbContext.Database.BeginTransaction();
            try
            {
                var function = _mapper.Map<Function>(model);
                _functionRepository.Create(function);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task CreateAsync(FunctionModel model)
        {
            using var transaction = await _functionRepository._dbContext.Database.BeginTransactionAsync();
            try
            {
                var function = _mapper.Map<Function>(model);
                await _functionRepository.CreateAsync(function);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        public IEnumerable<FunctionDto> GetList()
        {
            var list = _functionRepository.GetAll();

            return _mapper.Map<IEnumerable<FunctionDto>>(list);
        }

        public bool IsExist(string controllerName, string actionName) => _functionRepository.Any(x => x.ControllerName == controllerName && x.ActionName == actionName);
    }
}