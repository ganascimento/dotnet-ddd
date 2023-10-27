using MediatR;
using SampleProject.Application.Utils;

namespace SampleProject.Application.Commands.Employee;

public class UpdateEmployeeCommand : IRequest<ResponseService>
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required DateTime BirthDate { get; set; }
    public required string MotherName { get; set; }
    public string? FatherName { get; set; }
    public required byte Sex { get; set; }
    public required UpdateEmployeeAddressDto Address { get; set; }
    public UpdateEmployeePhoneDto? Telephone { get; set; }
    public UpdateEmployeePhoneDto? Cellphone { get; set; }
}

public record UpdateEmployeePhoneDto
{
    public required string AreaCode { get; set; }
    public required string PhoneNumber { get; set; }
}

public record UpdateEmployeeAddressDto
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required string ZipCode { get; set; }
    public string? BuildingNumber { get; set; }
    public string? Complement { get; set; }
}