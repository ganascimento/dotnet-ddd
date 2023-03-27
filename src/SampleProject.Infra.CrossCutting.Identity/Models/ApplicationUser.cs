using Microsoft.AspNetCore.Identity;

namespace SampleProject.Infra.CrossCutting.Identity.Models;

public class ApplicationUser : IdentityUser<int>
{
    public required string Name { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public int? CompanyId { get; set; }
    public int? EmployeeId { get; set; }
}