using Gradebook.Application.Configuration.Commands;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Exceptions.Course;
using Gradebook.Domain.Exceptions.Student;
using MediatR;

namespace Gradebook.Application.Commands.Courses.TransferStudentBetweenCourses;

internal class TransferStudentBetweenCoursesCommandHandler : ICommandHandler<TransferStudentBetweenCoursesCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TransferStudentBetweenCoursesCommandHandler(ICourseRepository courseRepository, IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(TransferStudentBetweenCoursesCommand request, CancellationToken cancellationToken)
    {
        var oldCourse = await _courseRepository.GetByIdAsync(request.OldCourseId);
        if (oldCourse is null)
        {
            throw new CourseNotFoundException(request.OldCourseId);
        }

        var newCourse = await _courseRepository.GetByIdAsync(request.NewCourseId);
        if (newCourse is null)
        {
            throw new CourseNotFoundException(request.NewCourseId);
        }

        var student = await _studentRepository.GetByIdWithCoursesAsync(request.StudentId);
        if (student is null)
        {
            throw new StudentNotFoundException(request.StudentId);
        }

        var oldStudentCourse = student.StudentCourses.SingleOrDefault(c => c.CourseId == oldCourse.Id);
        if (oldStudentCourse is null)
        {
            throw new StudentIsNotEnrolledToCourseException(student.FirstName, student.LastName, oldCourse.Name);
        }

        var newStudentCourse = student.StudentCourses.SingleOrDefault(c => c.CourseId == newCourse.Id);
        if (newStudentCourse is not null)
        {
            throw new StudentIsAlreadyEnrolledToCourseException(student.FirstName, student.LastName, newCourse.Name);
        }

        oldCourse.CourseStudents.Remove(oldStudentCourse);
        _courseRepository.Update(oldCourse);

        newCourse.CourseStudents.Add(oldStudentCourse);
        _courseRepository.Update(newCourse);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
