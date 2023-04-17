using Gradebook.Application.Configuration.Commands;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Gradebook.Domain.Exceptions.Course;
using Gradebook.Domain.Exceptions.Student;
using MediatR;

namespace Gradebook.Application.Commands.Courses.EnrollStudentToCourse;

internal class EnrollStudentToCourseCommandHandler : ICommandHandler<EnrollStudentToCourseCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EnrollStudentToCourseCommandHandler(ICourseRepository courseRepository, IStudentRepository studentRepository,IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(EnrollStudentToCourseCommand request, CancellationToken cancellationToken)
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

        bool isAlreadyEnrolledToCourse = student.StudentCourses.Any(c => c.CourseId == course.Id);
        if (isAlreadyEnrolledToCourse)
        {
            throw new StudentIsAlreadyEnrolledToCourseException(student.FirstName, student.LastName, course.Name);
        }

        var studentCourse = new StudentCourse()
        {
            CourseId = course.Id,
            StudentId = student.Id
        };

        course.CourseStudents.Add(studentCourse);

        _courseRepository.Update(course);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
