using MediatR;
using SampleProject.Application.Utils;

namespace SampleProject.Application.Commands.Company;

public class CreateCompanyCommand : IRequest<ResponseService>
{
    public required string CorporateName { get; set; }
    public required string FantasyName { get; set; }
    public required string Document { get; set; }
    public required CreateCompanyAddressDto Address { get; set; }

}

public record CreateCompanyAddressDto
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required string ZipCode { get; set; }
    public string? BuildingNumber { get; set; }
    public string? Complement { get; set; }
}