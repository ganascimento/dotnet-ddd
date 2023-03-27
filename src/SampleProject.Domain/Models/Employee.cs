using SampleProject.Domain.Enums;
using SampleProject.Domain.Models.Base;

namespace SampleProject.Domain.Models;

public class Employee : BaseEntity
{
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required DateTime BirthDate { get; set; }
    public required string MotherName { get; set; }
    public string? FatherName { get; set; }
    public required SexEnum Sex { get; set; }

    public required Address Address { get; set; }
    public required Company Company { get; set; }
    public Phone? Telephone { get; set; }
    public Phone? Cellphone { get; set; }
}