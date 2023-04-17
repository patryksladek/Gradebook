using AutoMapper;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Entities;
using Gradebook.Domain.Abstractions;
using MediatR;
using Gradebook.Domain.Exceptions.Department;

namespace Gradebook.Application.Commands.Departments.AddDepartment;

internal class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, DepartmentDto>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddDepartmentCommandHandler(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DepartmentDto> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
    {
        bool isAlreadyExist = await _departmentRepository.IsAlreadyExistAsync(request.Name, cancellationToken);
        if (isAlreadyExist)
        {
            throw new DepartmentAlreadyExistsException(request.Name);
        }

        var newDepartment = new Department()
        {
            Name = request.Name,
            Building = request.Building
        };

        _departmentRepository.Add(newDepartment);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var departmentDto = _mapper.Map<DepartmentDto>(newDepartment);

        return departmentDto;
    }
}
