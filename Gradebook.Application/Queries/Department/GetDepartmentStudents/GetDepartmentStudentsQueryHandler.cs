using AutoMapper;
using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;
using Gradebook.Application.Queries.Departments.GetDepartments;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Exceptions.Department;

namespace Gradebook.Application.Queries.Department.GetDepartmentStudents;

internal class GetDepartmentStudentsQueryHandler : IQueryHandler<GetDepartmentStudentsQuery, IEnumerable<StudentDto>>
{
    private readonly IDepartmentRepository _departmentReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetDepartmentStudentsQueryHandler(IDepartmentRepository departmentReadOnlyRepository, IMapper mapper)
    {
        _departmentReadOnlyRepository = departmentReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentDto>> Handle(GetDepartmentStudentsQuery request, CancellationToken cancellationToken)
    {
        var department = await _departmentReadOnlyRepository.GetByIdWithStudentsAsync(request.Id);
        if (department is null)
        {
            throw new DepartmentNotFoundException(request.Id);
        }

        var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(department.Students);

        return studentsDto;
    }
}
