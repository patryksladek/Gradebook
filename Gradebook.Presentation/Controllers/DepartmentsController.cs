using Gradebook.Application.Commands.Departments.AddDepartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Gradebook.Api.Controllers;

[Route("api/departments")]
[ApiController]
public class DepartmentsController : Controller
{
    private readonly IMediator _mediator;

    public DepartmentsController(IMediator mediator)
	{
        _mediator = mediator;
    }

    [HttpPost()]
    [SwaggerOperation("Add department")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post([FromBody] AddDepartmentCommand command)
    {
        var department = await _mediator.Send(command);
        return Created($"departments/{department.Id}", department);
    }
}
