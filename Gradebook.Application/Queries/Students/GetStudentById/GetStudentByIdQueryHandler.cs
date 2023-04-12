using AutoMapper;
using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Abstractions;

namespace Gradebook.Application.Queries.Students.GetStudentById;

internal class GetStudentByIdQueryHandler : IQueryHandler<GetStudentByIdQuery, StudentDto>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentByIdQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);

        var studentDto = _mapper.Map<StudentDto>(student);

        return studentDto;
    }
}
