using MediatR;
using SampleProject.Application.Utils;

namespace SampleProject.Application.Commands.Company;

public class UpdateCompanyCommand : IRequest<ResponseService>
{
    public required int Id { get; set; }
    public required string CorporateName { get; set; }
    public required string FantasyName { get; set; }
    public required UpdateAddressDto Address { get; set; }
}

public record UpdateAddressDto
{
    public int Id { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required string ZipCode { get; set; }
    public string? BuildingNumber { get; set; }
    public string? Complement { get; set; }
}