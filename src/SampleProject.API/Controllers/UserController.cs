using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleProject.API.Controllers.Base;
using SampleProject.Application.Commands.User;

namespace SampleProject.API.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class UserController : BaseController
{
    private readonly IMediator _mediatr;

    public UserController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand command)
    {
        var result = await _mediatr.Send(command);
        return HandleResult(result);
    }
}