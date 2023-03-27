using MediatR;
using SampleProject.Application.Utils;

namespace SampleProject.Application.Commands.User;

public class DeleteUserCommand : IRequest<ResponseService>
{
    public required int Id { get; set; }
}