using WebAPI.Models;

namespace WebAPI.Security
{
    public interface ITokenGenerator
    {
        AccessToken GenerateToken(User user);
    }
}
