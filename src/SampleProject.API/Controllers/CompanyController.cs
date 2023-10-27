using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SampleProject.API.Controllers.Base;
using SampleProject.Application.Commands.Company;
using SampleProject.Application.Queries.CompanyQuery;

namespace SampleProject.API.Controllers;

[Authorize]
[ApiController]
[Route("v1/[controller]")]
public class CompanyController : BaseController
{
    private readonly IMediator _mediator;
    private readonly ICompanyQuery _companyQuery;

    public CompanyController(IMediator mediator, ICompanyQuery companyQuery)
    {
        _mediator = mediator;
        _companyQuery = companyQuery;
    }

    [EnableQuery]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_companyQuery.GetOData());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCompanyCommand command)
    {
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCompanyCommand command)
    {
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteCompanyCommand command)
    {
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }
}