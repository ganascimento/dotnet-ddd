using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleProject.API.Controllers.Base;
using SampleProject.Application.Commands.Auth;

namespace SampleProject.API.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class AuthController : BaseController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }
}