using AutoMapper;
using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Abstractions;

namespace Gradebook.Application.Queries.Students.GetStudentCourses;

internal class GetStudentCoursesQueryHandler : IQueryHandler<GetStudentCoursesQuery, IEnumerable<CourseDto>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentCoursesQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CourseDto>> Handle(GetStudentCoursesQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdWithCoursesAsync(request.StudentId);

        var studentCourses = student.StudentCourses.Select(x => x.Course);

        var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(studentCourses);

        return coursesDto;
    }
}
