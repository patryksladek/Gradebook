using Gradebook.Application.Commands.Students.ChangeStudentDepartment;
using Gradebook.Application.Configuration.Commands;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Exceptions.Department;
using Gradebook.Domain.Exceptions.Student;
using MediatR;

namespace Gradebook.Application.Commands.Departments.ChangeStudentDepartment;

internal class ChangeStudentDepartmentCommandHandler : ICommandHandler<ChangeStudentDepartmentCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeStudentDepartmentCommandHandler(IStudentRepository studentRepository, IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
    {
        _studentRepository = studentRepository;
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ChangeStudentDepartmentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id);
        if (student is null)
        {
            throw new StudentNotFoundException(request.Id);
        }

        var department = await _departmentRepository.GetByIdAsync(request.DepartmentId);
        if (department is null)
        {
            throw new DepartmentNotFoundException(request.DepartmentId);
        }

        student.DepartmentId = department.Id;
        student.Department = department;

        _studentRepository.Update(student);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
