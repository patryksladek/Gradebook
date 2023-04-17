using AutoMapper;
using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;
using Gradebook.Domain;
using Gradebook.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.Application.Queries.Grades.GetGradeTypes;

internal class GetGradeTypesQueryHandler : IQueryHandler<GetGradeTypesQuery, IEnumerable<GradeTypeDto>>
{
    public readonly IMapper _mapper;


    public GetGradeTypesQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }


    public async Task<IEnumerable<GradeTypeDto>> Handle(GetGradeTypesQuery request, CancellationToken cancellationToken)
    {
        IList<GradeTypeDto> gradeTypesDto = new List<GradeTypeDto>();

        foreach (GradeType gradeType in (GradeType[])Enum.GetValues(typeof(GradeType)))
        {
            var gradeTypeDto = _mapper.Map<GradeTypeDto>(gradeType);
            gradeTypesDto.Add(gradeTypeDto);
        }

        await Task.CompletedTask;

        return gradeTypesDto;
    }
}
