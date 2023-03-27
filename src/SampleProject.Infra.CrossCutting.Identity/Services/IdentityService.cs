using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SampleProject.Infra.CrossCutting.Identity.Constants;
using SampleProject.Infra.CrossCutting.Identity.Interfaces;

namespace SampleProject.Infra.CrossCutting.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly IHttpContextAccessor _context;

    public IdentityService(IHttpContextAccessor context)
    {
        _context = context;
    }

    public int GetUserId()
    {
        var userId = _context.HttpContext?.User.FindFirst(ClaimsConstant.USER_ID)?.Value;

        if (userId == null)
            throw new KeyNotFoundException("UserId not found!");

        return int.Parse(userId);
    }

    public int GetUserCompanyId()
    {
        var companyId = _context.HttpContext?.User.FindFirst(ClaimsConstant.COMPANY_ID)?.Value;

        if (companyId == null)
            throw new KeyNotFoundException("CompanyId not found!");

        return int.Parse(companyId);
    }

    public string GetRole()
    {
        var role = _context.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;

        if (role == null)
            throw new KeyNotFoundException("Role not found!");

        return role;
    }
}