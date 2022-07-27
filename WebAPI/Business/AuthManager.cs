using WebAPI.Models;
using WebAPI.Security;

namespace WebAPI.Business
{
    public class AuthManager
    {
        private readonly UserManager _userManager;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthManager(ITokenGenerator tokenGenerator)
        {
            _userManager = new UserManager();
            _tokenGenerator = tokenGenerator;
        }

        public AccessToken Login(UserDto userDto)
        {
            var user=_userManager.GetUser(userDto.UserName, userDto.Password);
            if (user==null)
            {
                throw new System.Exception("User dont avaible");
            }

            var accessToken = _tokenGenerator.GenerateToken(user);
            return accessToken;

        }
    }
}
