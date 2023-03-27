using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SampleProject.Infra.CrossCutting.Identity.Constants;
using SampleProject.Infra.CrossCutting.Identity.Models;

namespace SampleProject.Infra.CrossCutting.Identity.Services;

public class JwtFactory
{
    public JwtToken GenerateJwtToken(ApplicationUser user, string role, IConfiguration configuration)
    {
        var claims = new List<Claim>();
        var secret = configuration.GetValue<string>("JWT:Secret")!;
        var issuer = configuration.GetValue<string>("JWT:Issuer")!;
        var audience = configuration.GetValue<string>("JWT:Audience")!;
        var expiration = configuration.GetValue<double>("JWT:Expiration")!;

        claims.Add(new Claim(ClaimsConstant.USER_ID, user.Id.ToString()));
        claims.Add(new Claim(ClaimsConstant.COMPANY_ID, user.CompanyId?.ToString() ?? ""));
        claims.Add(new Claim(ClaimTypes.Role, role));

        var identityClaims = new ClaimsIdentity();
        identityClaims.AddClaims(claims);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        var expireDate = DateTime.UtcNow.AddHours(expiration);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identityClaims,
            Issuer = issuer,
            Audience = audience,
            Expires = expireDate,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        return new JwtToken
        {
            Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
            ExpireDate = expireDate,
            Role = role,
            Name = user.Name,
            UserEmail = user.Email!,
            CompanyId = user.CompanyId
        };
    }
}