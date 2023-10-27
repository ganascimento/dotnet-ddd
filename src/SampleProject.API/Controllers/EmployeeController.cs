using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SampleProject.API.Controllers.Base;
using SampleProject.Application.Commands.Employee;
using SampleProject.Application.Queries.EmployeeQuery;

namespace SampleProject.API.Controllers;

[Authorize]
[ApiController]
[Route("v1/[controller]")]
public class EmployeeController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IEmployeeQuery _employeeQuery;

    public EmployeeController(IMediator mediator, IEmployeeQuery employeeQuery)
    {
        _mediator = mediator;
        _employeeQuery = employeeQuery;
    }

    [EnableQuery]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_employeeQuery.GetOData());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand command)
    {
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateEmployeeCommand command)
    {
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteEmployeeCommand command)
    {
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }
}