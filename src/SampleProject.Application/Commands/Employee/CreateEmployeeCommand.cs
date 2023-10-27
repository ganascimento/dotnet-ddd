using MediatR;
using SampleProject.Application.Utils;

namespace SampleProject.Application.Commands.Employee;

public class CreateEmployeeCommand : IRequest<ResponseService>
{
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required DateTime BirthDate { get; set; }
    public required string MotherName { get; set; }
    public string? FatherName { get; set; }
    public required byte Sex { get; set; }
    public required int CompanyId { get; set; }
    public required CreateEmployeeAddressDto Address { get; set; }
    public CreateEmployeePhoneDto? Telephone { get; set; }
    public CreateEmployeePhoneDto? Cellphone { get; set; }
}

public record CreateEmployeePhoneDto
{
    public required string AreaCode { get; set; }
    public required string PhoneNumber { get; set; }
}

public record CreateEmployeeAddressDto
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required string ZipCode { get; set; }
    public string? BuildingNumber { get; set; }
    public string? Complement { get; set; }
}