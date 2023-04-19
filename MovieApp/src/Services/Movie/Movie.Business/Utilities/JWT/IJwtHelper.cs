using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Utilities.JWT
{
    public interface IJwtHelper
    {
        AccessToken CreateToken(string email);
        string ValidateToken(string token);
    }
}
