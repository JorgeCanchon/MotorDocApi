using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorDocApi.Attributes
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (!context.Request.Headers.Keys.Contains("Authorization"))
                {
                    Unauthorized(context);
                    return;
                }
                string token = context.Request.Headers["Authorization"].FirstOrDefault().Split("Bearer ").Last();

                bool isValid = Security.ValidateToken(token, "$SolidSigningKey$");
                if(!isValid)
                    Unauthorized(context);
            }
            catch(Exception)
            {
                Unauthorized(context); 
                return;
            }

            await _next.Invoke(context);
        }
        private void Unauthorized(HttpContext context) =>
            context.Response.StatusCode = 401;//Unauthorized
    }
}
