using AutoMapper;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Abstractions;
using MediatR;

namespace Gradebook.Application.Queries.Students.GetStudentsWithDetails;

internal class GetStudentsWithDetailsQueryHandler : IRequestHandler<GetStudentsWithDetailsQuery, IEnumerable<StudentDetailsDto>>
{
    private readonly IStudentReadOnlyRepository _studentReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetStudentsWithDetailsQueryHandler(IStudentReadOnlyRepository studentReadOnlyRepository, IMapper mapper)
    {
        _studentReadOnlyRepository = studentReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentDetailsDto>> Handle(GetStudentsWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentReadOnlyRepository.GetAllWithDetailsAsync();

        var studentsDto = _mapper.Map<IEnumerable<StudentDetailsDto>>(students);

        return studentsDto;
    }
}
