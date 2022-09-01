using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Poppers.Application.Common.Interfaces.Authentication;

namespace Poppers.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string Generate(Guid userId, string firstName, string secondName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key")
            ),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, secondName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: "MeetHead",
            expires: DateTime.Now.AddMinutes(15),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}