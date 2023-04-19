using Movie.Business.Abstract;
using Movie.Business.Utilities.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IJwtHelper _jwtHelper;

        public UserManager(IJwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }

        public AccessToken Login(string email, string password)
        {
            //fakelogin
            if (email == "admin@hotmail.com" && password == "12345")
            {
                return _jwtHelper.CreateToken(email);
            }

            return new AccessToken()
            {
                Token = ""
            };
        }
    }
}
