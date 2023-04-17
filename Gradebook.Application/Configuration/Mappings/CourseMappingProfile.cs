using AutoMapper;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Entities;

namespace Gradebook.Application.Configuration.Mappings;

public class CourseMappingProfile : Profile
{
	public CourseMappingProfile()
	{
        CreateMap<Course, CourseDto>();
    }
}
