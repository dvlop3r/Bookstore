using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bookstore.Application.Interfaces;
using Bookstore.Contracts.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Application.Services;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly AppSettings _options;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<AppSettings> options)
    {
        _dateTimeProvider = dateTimeProvider;
        _options = options.Value;
    }

    public string generateToken()
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.JwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new []
        {
            new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, "Sarwan"),
            new Claim(JwtRegisteredClaimNames.FamilyName, "Hakm"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _options.JwtSettings.Issuer,
            audience: _options.JwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_options.JwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
