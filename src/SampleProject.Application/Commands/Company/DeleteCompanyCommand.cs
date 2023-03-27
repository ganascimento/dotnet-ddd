using MediatR;
using SampleProject.Application.Utils;

namespace SampleProject.Application.Commands.Company;

public class DeleteCompanyCommand : IRequest<ResponseService>
{
    public required int Id { get; set; }
}