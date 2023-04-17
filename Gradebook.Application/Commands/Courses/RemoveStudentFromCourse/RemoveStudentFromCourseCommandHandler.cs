using Gradebook.Application.Configuration.Commands;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Exceptions.Course;
using Gradebook.Domain.Exceptions.Student;
using MediatR;

namespace Gradebook.Application.Commands.Courses.RemoveStudentFromCourse;

internal class RemoveStudentFromAllCoursesCommandHandler : ICommandHandler<RemoveStudentFromCourseCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveStudentFromAllCoursesCommandHandler(ICourseRepository courseRepository, IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveStudentFromCourseCommand request, CancellationToken cancellationToken)
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

        course.CourseStudents.Remove(studentCourse);

        _courseRepository.Update(course);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
