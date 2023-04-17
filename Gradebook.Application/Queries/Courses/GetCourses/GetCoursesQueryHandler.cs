using AutoMapper;
using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Abstractions;

namespace Gradebook.Application.Queries.Courses.GetCourses;

internal class GetCoursesQueryHandler : IQueryHandler<GetCoursesQuery, IEnumerable<CourseDto>>
{
    private readonly ICourseReadOnlyRepository _courseReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetCoursesQueryHandler(ICourseReadOnlyRepository courseReadOnlyRepository, IMapper mapper)
    {
        _courseReadOnlyRepository = courseReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await _courseReadOnlyRepository.GetAllAsync();

        var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(courses);

        return coursesDto;
    }
}
