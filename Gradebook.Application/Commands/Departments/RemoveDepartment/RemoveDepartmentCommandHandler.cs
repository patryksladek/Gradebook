using Gradebook.Application.Configuration.Commands;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Exceptions.Department;
using MediatR;

namespace Gradebook.Application.Commands.Departments.RemoveDepartment;

internal class RemoveDepartmentCommandHandler : ICommandHandler<RemoveDepartmentCommand>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveDepartmentCommandHandler(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
    {
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _departmentRepository.GetByIdWithStudentsAsync(request.Id);
        if (department is null)
        {
            throw new DepartmentNotFoundException(request.Id);
        }

        if (department.Students.Count > 0)
        {
            throw new DepartmentHasAssignedStudentsException(department.Name);
        }

        _departmentRepository.Remove(department);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}