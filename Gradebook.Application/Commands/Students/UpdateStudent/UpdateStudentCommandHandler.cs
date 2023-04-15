using FluentValidation;
using FluentValidation.Results;
using Gradebook.Application.Commands.Students.AddStudent;
using Gradebook.Application.Configuration.Commands;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Exceptions.Student;

namespace Gradebook.Application.Commands.Students.UpdateStudent;

internal class UpdateStudentCommandHandler : ICommandHandler<UpdateStudentCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private IValidator<UpdateStudentCommand> _validator;


    public UpdateStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork, IValidator<UpdateStudentCommand> validator)
    {
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        ValidationResult result = await _validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            var errorsList = result.Errors.Select(x => x.ErrorMessage);
            throw new ValidationException($"Invalid command, reasons: {string.Join(", ", errorsList.ToArray())}");
        }

        var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);
        if (student is null)
        {
            throw new StudentNotFoundException(request.Id);
        }

        student.FirstName = request.FirstName;
        student.LastName = request.LastName;
        student.Email = request.Email;
        student.DateOfBirth = request.DateOfBirth;
        student.YearEnrolled = request.YearEnrolled;

        _studentRepository.Update(student);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
