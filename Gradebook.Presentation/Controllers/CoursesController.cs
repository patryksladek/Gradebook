using Gradebook.Application.Commands.Courses.AddCourse;
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

    [HttpPost()]
    [SwaggerOperation("Add course")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> PostAsync([FromBody] AddCourseCommand command)
    {
        var result = await _mediator.Send(command);
        return Created($"/api/courses/{result.Id}", result);
    }
}
