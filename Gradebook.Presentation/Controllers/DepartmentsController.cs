﻿using Gradebook.Application.Commands.Departments.AddDepartment;
using Gradebook.Application.Commands.Departments.RemoveDepartment;
using Gradebook.Application.Dtos;
using Gradebook.Application.Queries.Department.GetDepartmentStudents;
using Gradebook.Application.Queries.Departments.GetDepartments;
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

    [HttpGet]
    [SwaggerOperation("Get departments")]
    [ProducesResponseType(typeof(IEnumerable<DepartmentDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetDepartmentsQuery());
        return Ok(result);
    }

    [HttpGet("{id}/students")]
    [SwaggerOperation("Get department students")]
    [ProducesResponseType(typeof(IEnumerable<StudentDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetDepartmentStudents([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetDepartmentStudentsQuery(id));
        return Ok(result);
    }

    [HttpPost()]
    [SwaggerOperation("Add department")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post([FromBody] AddDepartmentCommand command)
    {
        var department = await _mediator.Send(command);
        return Created($"departments/{department.Id}", department);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation("Remove department")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveDepartmentCommand(id));
        return NoContent();
    }
}
