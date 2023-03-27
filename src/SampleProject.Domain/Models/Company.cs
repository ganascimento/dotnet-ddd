using SampleProject.Domain.Models.Base;

namespace SampleProject.Domain.Models;

public class Company : BaseEntity
{
    public required string CorporateName { get; set; }
    public required string FantasyName { get; set; }
    public required string Document { get; set; }
    public required Address Address { get; set; }
    public virtual IEnumerable<Employee>? Employees { get; set; }
}