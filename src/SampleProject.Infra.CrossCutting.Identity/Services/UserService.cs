using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SampleProject.Infra.CrossCutting.Identity.Interfaces;
using SampleProject.Infra.CrossCutting.Identity.Models;

namespace SampleProject.Infra.CrossCutting.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public UserService(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<ApplicationUser?> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<string> GetUserRoleAsync(ApplicationUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        if (roles == null || roles.Count == 0)
            throw new KeyNotFoundException("Roles not fount");

        return roles.Single();
    }

    public async Task<bool> CreateAsync(ApplicationUser user, string password, string role)
    {
        var existsUser = await _userManager.FindByEmailAsync(user.Email!);

        if (existsUser != null || !(await RoleExists(role)))
            return false;

        user.CreateAt = DateTime.Now;
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            var newUser = await _userManager.FindByEmailAsync(user.Email!);
            await _userManager.AddToRoleAsync(newUser!, role);

            return true;
        }

        return false;
    }

    public Task<SignInResult> SignInAsync(ApplicationUser user, string password)
    {
        return _signInManager.PasswordSignInAsync(user, password, false, false);
    }

    public JwtToken GenerateJwtToken(ApplicationUser user, string role)
    {
        return new JwtFactory().GenerateJwtToken(user, role, _configuration);
    }

    private async Task<bool> RoleExists(string role)
    {
        var result = await _roleManager.RoleExistsAsync(role);
        return result;
    }
}