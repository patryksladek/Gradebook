using AutoMapper;
using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Exceptions.Course;

namespace Gradebook.Application.Queries.Courses.GetCourseStudents;

internal class GetCourseStudentsQueryHandler : IQueryHandler<GetCourseStudentsQuery, IEnumerable<StudentDto>>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public GetCourseStudentsQueryHandler(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentDto>> Handle(GetCourseStudentsQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdWithStudentsAsync(request.CourseId, cancellationToken);
        if (course is null)
        {
            throw new CourseNotFoundException(request.CourseId);
        }

        var courseStudents = course.CourseStudents.Select(x => x.Student);

        var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(courseStudents);

        return studentsDto;
    }
}
