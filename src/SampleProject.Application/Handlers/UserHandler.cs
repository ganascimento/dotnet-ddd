using MediatR;
using SampleProject.Application.Commands.User;
using SampleProject.Application.Utils;
using SampleProject.Infra.CrossCutting.Identity.Interfaces;
using SampleProject.Infra.CrossCutting.Identity.Models;

namespace SampleProject.Application.Handlers;

public class UserHandler : IRequestHandler<CreateUserCommand, ResponseService>
{
    private readonly IUserService _userService;

    public UserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ResponseService> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var user = new ApplicationUser
            {
                Email = command.Email,
                UserName = command.Email,
                Name = command.Name,
                EmailConfirmed = true,
                CompanyId = command.CompanyId,
                EmployeeId = command.EmployeeId,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userService.CreateAsync(user, command.Password, command.Role);
            if (!result)
                throw new Exception("Error to create user!");

            return new ResponseService(true);
        }
        catch (Exception ex)
        {
            return new ResponseService().AddError(ex.Message);
        }
    }
}