using Microsoft.AspNetCore.Identity;
using SampleProject.Infra.CrossCutting.Identity.Models;

namespace SampleProject.Infra.CrossCutting.Identity.Interfaces;

public interface IUserService
{
    Task<ApplicationUser?> FindByEmailAsync(string email);
    Task<string> GetUserRoleAsync(ApplicationUser user);
    Task<bool> CreateAsync(ApplicationUser user, string password, string role);
    Task<SignInResult> SignInAsync(ApplicationUser user, string password);
    JwtToken GenerateJwtToken(ApplicationUser user, string role);
}