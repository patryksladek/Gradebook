using Gradebook.Application.Commands.Courses.AddCourse;
using Gradebook.Application.Commands.Courses.EnrollStudentToCourse;
using Gradebook.Application.Dtos;
using Gradebook.Application.Queries.Courses.GetCourses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Gradebook.Api.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesController : Controller
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation("Get courses")]
    [ProducesResponseType(typeof(IEnumerable<CourseDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get()
    {
        var result = await _mediator.Send(new GetCoursesQuery());
        return Ok(result);
    }

    [HttpPost()]
    [SwaggerOperation("Add course")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> PostAsync([FromBody] AddCourseCommand command)
    {
        var result = await _mediator.Send(command);
        return Created($"/api/courses/{result.Id}", result);
    }

    [HttpPost("{courseId}/students/{studentId}")]
    [SwaggerOperation("Enroll student to course")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> EnrollStudentToCourse([FromRoute] int courseId, [FromRoute] int studentId)
    {
        await _mediator.Send(new EnrollStudentToCourseCommand(courseId, studentId));
        return NoContent();
    }
}
