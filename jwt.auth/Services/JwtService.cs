using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using jwt.auth.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace jwt.auth.Services;

public class JwtService
{
    private readonly ILogger<JwtService> _logger;
    private readonly JwtOptions _options;

    public JwtService(
        IOptionsMonitor<JwtOptions> options,
        ILogger<JwtService> logger)
    {
        _logger = logger;
        _options = options.CurrentValue;
    }

    public string GenerateToken(string userName, string role)
    {
        var secret = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.IssuerSigningKey));

        var authClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userName),
                new Claim("role", role)
            };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(authClaims),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = _options.ValidIssuer,
            Audience = _options.ValidAudience,
            SigningCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public bool IsValidToken(string token)
    {
        var secret = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.IssuerSigningKey));
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var result = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = secret
            }, out SecurityToken validatedToken);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public string GetClaim(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
        return securityToken.Claims.FirstOrDefault().Value;
    }
}