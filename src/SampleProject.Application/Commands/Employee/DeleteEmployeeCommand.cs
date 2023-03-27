using MediatR;
using SampleProject.Application.Utils;

namespace SampleProject.Application.Commands.Employee;

public class DeleteEmployeeCommand : IRequest<ResponseService>
{
    public required int Id { get; set; }
}