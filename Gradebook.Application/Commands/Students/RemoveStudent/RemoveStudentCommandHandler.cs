using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Exceptions.Student;
using MediatR;

namespace Gradebook.Application.Commands.Students.RemoveStudent;

internal class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id);
        if (student is null)
        {
            throw new StudentNotFoundException(request.Id);
        }

        _studentRepository.Delete(student);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
