using SampleProject.Domain.Models.Base;

namespace SampleProject.Domain.Models;

public class Address : BaseEntity
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required string ZipCode { get; set; }
    public string? BuildingNumber { get; set; }
    public string? Complement { get; set; }
}