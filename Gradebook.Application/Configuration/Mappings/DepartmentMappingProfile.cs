using AutoMapper;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Entities;

namespace Gradebook.Application.Configuration.Mappings;

public class DepartmentMappingProfile : Profile
{
    public DepartmentMappingProfile()
    {
        CreateMap<Department, DepartmentDto>();
    }
}
