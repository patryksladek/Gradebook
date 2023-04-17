using AutoMapper;
using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Abstractions;

namespace Gradebook.Application.Queries.Departments.GetDepartments;

internal class GetDepartmentsQueryHandler : IQueryHandler<GetDepartmentsQuery, IEnumerable<DepartmentDto>>
{
    private readonly IDepartmentReadOnlyRepository _departmentReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetDepartmentsQueryHandler(IDepartmentReadOnlyRepository departmentReadOnlyRepository, IMapper mapper)
    {
        _departmentReadOnlyRepository = departmentReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DepartmentDto>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var departments = await _departmentReadOnlyRepository.GetAllAsync();

        var departmentsDto = _mapper.Map<IEnumerable<DepartmentDto>>(departments);

        return departmentsDto;
    }
}
