using Gradebook.Application.Dtos;
using MediatR;

namespace Gradebook.Application.Commands.Courses.AddCourse;

public class AddCourseCommand : IRequest<CourseDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
