using AutoMapper;
using LeaveSystem.Domain.Dtos;
using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Models;

namespace LeaveSystem.BusinessLayer.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserModel, User>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<Function, FunctionDto>();
            CreateMap<FunctionDto, Function>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
        }
    }
}