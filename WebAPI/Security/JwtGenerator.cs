using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Security
{
    public class JwtGenerator
    {
        public string GenerateToken()
        {
            var securityToken = new JwtSecurityToken
                (
                    issuer:"deneme",
                    audience: "deneme",
                    expires: System.DateTime.UtcNow.AddDays(1),
                    notBefore: System.DateTime.Now,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("security key anahtarı 40 karakterden uzun olmalıdır")),
                    SecurityAlgorithms.HmacSha256)

                );

            string token=new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
