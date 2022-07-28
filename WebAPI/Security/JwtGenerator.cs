using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Security
{
    public class JwtGenerator:ITokenGenerator
    {
        private readonly IConfiguration Configuration;
        private readonly TokenOptions tokenOptions;
        public JwtGenerator(IConfiguration configuration)
        {
            Configuration = configuration;
            tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        
        public AccessToken GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)), SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken
                (
                    issuer:tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    claims:GetUserClaims(user),
                    expires: DateTime.Now.AddDays(tokenOptions.ExpirationTime),
                    notBefore: DateTime.Now,
                    signingCredentials: signingCredentials

                );

            string token=new JwtSecurityTokenHandler().WriteToken(securityToken);
            var accessToken = new AccessToken
            {
                Token = token,
            };
            return accessToken;
        }

        private List<Claim> GetUserClaims(User user)
        {
            var claims = new List<Claim>();
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            return claims;
        }
    }
}
