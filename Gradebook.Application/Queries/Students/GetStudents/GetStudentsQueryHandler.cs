using AutoMapper;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Abstractions;
using MediatR;
using System.Collections.Generic;

namespace Gradebook.Application.Queries.Students.GetStudents;

internal class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<StudentDto>>
{
    private readonly IStudentReadOnlyRepository _studentReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetStudentsQueryHandler(IStudentReadOnlyRepository studentReadOnlyRepository, IMapper mapper)
    {
        _studentReadOnlyRepository = studentReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentReadOnlyRepository.GetAllAsync();

        var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);

        return studentsDto;
    }
}
