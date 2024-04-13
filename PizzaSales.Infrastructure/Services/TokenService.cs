using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using PizzaSales.Core.Contracts.Interfaces.Services;
using PizzaSales.Domain.Entities.Identity;
using PizzaSales.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Infrastructure.Services
{
    public class TokenService(IOptions<TokenConfiguration> options) : ITokenService
    {
        private readonly TokenConfiguration _tokenConfiguration = options.Value;

        public Task<Token> GenerateToken(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = _tokenConfiguration.AUDIENCE,
                Issuer = _tokenConfiguration.ISSUER,
                TokenType = "JWT",
                Expires = DateTime.UtcNow.AddHours(8).AddHours(_tokenConfiguration.EXPIRY_HOURS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenConfiguration.SECRET_KEY)), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var expiry = new DateTimeOffset(tokenDescriptor.Expires.Value).ToUnixTimeSeconds();

            return Task.FromResult(new Token()
            {
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                AccessToken = tokenString,
                ExpiresIn = expiry
            });
        }
    }
}
