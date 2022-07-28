using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Business
{
    public class UserManager
    {
        private List<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName="Ömer Faruk",
                LastName="Sandıkçı",
                UserName="deneme123",
                Password="123456",
                Email="deneme321@gmail.com",
                Roles=new string[]{"admin"}
            },
            new User
            {
                Id = 2,
                FirstName="Hatice Betül",
                LastName="Sandıkçı",
                UserName="hatice789",
                Password="654321",
                Email="hatice789@gmail.com",
                Roles=new string[]{"user"}
            }
        };

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetUser(string userName, string password)
        {
            return _users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }
    }
}
