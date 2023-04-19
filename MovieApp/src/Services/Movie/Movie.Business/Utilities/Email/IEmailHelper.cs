using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Utilities.Email
{
    public interface IEmailHelper
    {
        Task<bool> SendEmailAsync(string to, string content);
    }
}
