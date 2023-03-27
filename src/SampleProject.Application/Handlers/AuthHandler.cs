using MediatR;
using SampleProject.Application.Commands.Auth;
using SampleProject.Application.Utils;
using SampleProject.Infra.CrossCutting.Identity.Interfaces;

namespace SampleProject.Application.Handlers;

public class AuthHandler : IRequestHandler<LoginCommand, ResponseService>
{
    private readonly IUserService _userService;

    public AuthHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ResponseService> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userService.FindByEmailAsync(command.Email);

            if (user == null)
                throw new Exception("Login or password is incorret");

            var result = await _userService.SignInAsync(user, command.Password);

            if (result.Succeeded)
            {
                var role = await _userService.GetUserRoleAsync(user);
                var token = _userService.GenerateJwtToken(user, role);
                return new ResponseService(token);
            }

            throw new Exception("Login or password is incorret");
        }
        catch (Exception ex)
        {
            return new ResponseService().AddError(ex.Message);
        }
    }
}
