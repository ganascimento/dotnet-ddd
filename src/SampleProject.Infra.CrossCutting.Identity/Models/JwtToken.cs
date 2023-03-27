namespace SampleProject.Infra.CrossCutting.Identity.Models;

public class JwtToken
{
    public required string Token { get; set; }
    public int? CompanyId { get; set; }
    public required DateTime ExpireDate { get; set; }
    public required string Role { get; set; }
    public required string Name { get; set; }
    public required string UserEmail { get; set; }
}