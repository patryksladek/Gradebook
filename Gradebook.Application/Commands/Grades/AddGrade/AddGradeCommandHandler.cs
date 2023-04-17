using Gradebook.Application.Configuration.Commands;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Gradebook.Domain.Exceptions.Course;
using Gradebook.Domain.Exceptions.Grade;
using Gradebook.Domain.Exceptions.Student;
using MediatR;

namespace Gradebook.Application.Commands.Grades.AddGrade;

internal class AddGradeCommandHandler : ICommandHandler<AddGradeCommand>
{
    private readonly IGradeRepository _gradeRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddGradeCommandHandler(IGradeRepository gradeRepository, IStudentRepository studentRepository, ICourseRepository courseRepository, IUnitOfWork unitOfWork)
    {
        _gradeRepository = gradeRepository;
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task Handle(AddGradeCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdWithCoursesAsync(request.StudentId);
        if (student is null)
        {
            throw new StudentNotFoundException(request.StudentId);
        }

        var course = await _courseRepository.GetByIdAsync(request.CourseId);
        if (course is null)
        {
            throw new CourseNotFoundException(request.CourseId);
        }

        var studentCourse = student.StudentCourses.SingleOrDefault(x => x.CourseId == request.CourseId);
        if (studentCourse is null)
        {
            throw new StudentIsNotEnrolledToCourseException(student.FirstName, student.LastName, course.Name);
        }

        bool isAlreadyExist = await _gradeRepository.IsAlreadyExistAsync(studentCourse.Id, (GradeType)request.Type, cancellationToken);
        if (isAlreadyExist)
        {
            throw new GradeAlreadyExistsException((GradeType)request.Type);
        }

        var grade = new Grade()
        {
            StudentCourseId = studentCourse.Id,
            Type = (GradeType)request.Type,
            Value = request.Grade
        };

        _gradeRepository.Add(grade);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
