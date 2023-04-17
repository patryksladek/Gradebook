using AutoMapper;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Entities;
using Gradebook.Domain.Abstractions;
using MediatR;
using Gradebook.Domain.Exceptions.Course;

namespace Gradebook.Application.Commands.Courses.AddCourse;

internal class AddCourseCommandHandler : IRequestHandler<AddCourseCommand, CourseDto>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CourseDto> Handle(AddCourseCommand request, CancellationToken cancellationToken)
    {
        bool isAlreadyExist = await _courseRepository.IsAlreadyExistAsync(request.Name);
        if (isAlreadyExist)
        {
            throw new CourseAlreadyExistsException(request.Name);
        }

        var newCourse = new Course()
        {
            Name = request.Name,
            Description = request.Description
        };

        _courseRepository.Add(newCourse);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var courseDto = _mapper.Map<CourseDto>(newCourse);

        return courseDto;
    }
}
