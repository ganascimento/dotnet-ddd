using MediatR;
using SampleProject.Application.Utils;

namespace SampleProject.Application.Commands.Auth;

public class LoginCommand : IRequest<ResponseService>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}