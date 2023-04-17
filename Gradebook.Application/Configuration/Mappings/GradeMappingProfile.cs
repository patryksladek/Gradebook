using AutoMapper;
using Gradebook.Application.Dtos;
using Gradebook.Domain;
using Gradebook.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.Application.Configuration.Mappings;

public class GradeMappingProfile : Profile
{
	public GradeMappingProfile()
	{
        CreateMap<GradeType, GradeTypeDto>()
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetDisplayName()))
              .ForMember(dest => dest.Value, opt => opt.MapFrom(src => (int)src))
              .ReverseMap();

        CreateMap<Grade, GradeDto>();
    }
}
