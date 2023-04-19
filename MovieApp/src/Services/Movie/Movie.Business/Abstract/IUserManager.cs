using Movie.Business.Utilities.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Abstract
{
    public interface IUserManager
    {
        AccessToken Login(string email, string password);
    }
}
