using AutoMapper;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Abstractions;
using MediatR;

namespace Gradebook.Application.Queries.Students.GetStudentByEmail;

internal class GetStudentByEmailQueryHandler : IRequestHandler<GetStudentByEmailQuery, StudentDto>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentByEmailQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<StudentDto> Handle(GetStudentByEmailQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByEmailAsync(request.Email, cancellationToken);

        var studentDto = _mapper.Map<StudentDto>(student);

        return studentDto;
    }
}
