using MediatR;
using SampleProject.Application.Utils;

namespace SampleProject.Application.Commands.User;

public class UpdateUserCommand : IRequest<ResponseService>
{
    public required int Id { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public int? EmployeeId { get; set; }
}