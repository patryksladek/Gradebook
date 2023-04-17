using AutoMapper;
using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Exceptions.Course;
using Gradebook.Domain.Exceptions.Student;

namespace Gradebook.Application.Queries.Students.GetStudentCourseGrades;

internal class GetStudentCourseGradesQueryHandler : IQueryHandler<GetStudentCourseGradesQuery, IEnumerable<GradeDto>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IGradeReadOnlyRepository _gradeReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetStudentCourseGradesQueryHandler(IStudentRepository studentRepository, 
                                              ICourseRepository courseRepository,
                                              IGradeReadOnlyRepository gradeReadOnlyRepository,
                                              IMapper mapper)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
        _gradeReadOnlyRepository = gradeReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GradeDto>> Handle(GetStudentCourseGradesQuery request, CancellationToken cancellationToken)
    {

        var course = await _courseRepository.GetByIdAsync(request.CourseId);
        if (course is null)
        {
            throw new CourseNotFoundException(request.CourseId);
        }

        var student = await _studentRepository.GetByIdWithCoursesAsync(request.StudentId);
        if (student is null)
        {
            throw new StudentNotFoundException(request.StudentId);
        }

        var studentCourse = student.StudentCourses.SingleOrDefault(c => c.CourseId == course.Id);
        if (studentCourse is null)
        {
            throw new StudentIsNotEnrolledToCourseException(student.FirstName, student.LastName, course.Name);
        }

        var grades = await _gradeReadOnlyRepository.GetByStudentCourseIdAsync(studentCourse.Id, cancellationToken);

        var gradesDto = _mapper.Map<IEnumerable<GradeDto>>(grades);

        return gradesDto;
    }
}
