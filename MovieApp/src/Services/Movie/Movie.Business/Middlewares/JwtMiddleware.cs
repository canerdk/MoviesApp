using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Movie.Business.Utilities.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtHelper jwtHelper)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if(token != null)
            {
                var useremail = jwtHelper.ValidateToken(token);
                if(useremail != null)
                {
                    context.Items["UserEmail"] = useremail;
                }
            }

            await _next(context);
        }
    }
}
