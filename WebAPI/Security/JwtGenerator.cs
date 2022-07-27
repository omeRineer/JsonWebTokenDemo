using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
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
    }
}
