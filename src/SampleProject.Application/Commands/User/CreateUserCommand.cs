using MediatR;
using SampleProject.Application.Utils;

namespace SampleProject.Application.Commands.User;

public class CreateUserCommand : IRequest<ResponseService>
{
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public int? CompanyId { get; set; }
    public int? EmployeeId { get; set; }
    public required string Role { get; set; }
}