using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace MotorDocApi.Attributes
{
    public static class Security
    {
        public static int GetUserId(string authHeader)
        {
            int id = -1;
            try
            {
                var handler = new JwtSecurityTokenHandler();
                authHeader = authHeader.Replace("Bearer ", "");
                var jsonToken = handler.ReadToken(authHeader);
                var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

                id = Convert.ToInt32(tokenS.Claims.First(claim => claim.Type == "user_id").Value);
            }
            catch
            {
                id = -1;
            }
            return id;

        }
        public static bool ValidateToken(string token, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            TokenValidationParameters validationParams = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.FromMinutes(5),
                ValidateAudience = false,
                ValidAudience = "",
                ValidateIssuer = false,
                ValidIssuer = "",
                RequireExpirationTime = true,
                ValidateLifetime = false, 			
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
            };

            SecurityToken validatedToken;
            try
            {
                tokenHandler.ValidateToken(token, validationParams, out validatedToken);
            }
            catch (Exception)
            {
                return false;
            }

            return validatedToken != null;
        }
    }
}
