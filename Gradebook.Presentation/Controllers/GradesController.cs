using Gradebook.Application.Commands.Grades.AddGrade;
using Gradebook.Application.Commands.Students.AddStudent;
using Gradebook.Application.Dtos;
using Gradebook.Application.Queries.Courses.GetCourses;
using Gradebook.Application.Queries.Grades.GetGradeTypes;
using Gradebook.Application.Queries.Grades.GetGradeValues;
using Gradebook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Gradebook.Presentation.Controllers;

[ApiController]
[Route("api/grades")]
public class GradesController : Controller
{
    private readonly IMediator _mediator;

    public GradesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("types")]
    [SwaggerOperation("Get grade types")]
    [ProducesResponseType(typeof(IEnumerable<GradeTypeDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetGradeTypes()
    {
        var result = await _mediator.Send(new GetGradeTypesQuery());
        return Ok(result);
    }

    [HttpGet("values")]
    [SwaggerOperation("Get grade values")]
    [ProducesResponseType(typeof(IEnumerable<double>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetGradeValues()
    {
        var result = await _mediator.Send(new GetGradeValuesQuery());
        return Ok(result);
    }

    [HttpPost()]
    [SwaggerOperation("Add grade to student for course")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Post([FromBody] AddGradeCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
