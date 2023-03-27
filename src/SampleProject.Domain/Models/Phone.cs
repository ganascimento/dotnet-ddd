using SampleProject.Domain.Models.Base;

namespace SampleProject.Domain.Models;

public class Phone : BaseEntity
{
    public required string AreaCode { get; set; }
    public required string PhoneNumber { get; set; }
}