using AutoMapper;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Abstractions;
using MediatR;
using System.Collections.Generic;

namespace Gradebook.Application.Queries.Students.GetStudents;

internal class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<StudentDto>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetAllAsync();

        var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);

        return studentsDto;
    }
}
