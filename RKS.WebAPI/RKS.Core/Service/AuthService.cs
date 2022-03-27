using Microsoft.IdentityModel.Tokens;
using RKS.Core.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RKS.Core.Service
{
    public class AuthService: IAuthService
    {
        IAppSettings _appSettings;

        public AuthService(
            IAppSettings appSettings            
        )
        {
            _appSettings = appSettings;           
        }

        public async Task<string> ValidateUser()
        {  
            // Db call to check Valid user 

            var tokenIssuer = _appSettings.GetValue("Token:Issuer");
            var tokenAudience = _appSettings.GetValue("Token:Audience");
            var tokenKey = _appSettings.GetValue("Token:Key");
            var tokenDuration = int.Parse(_appSettings.GetValue("Token:Duration"));

            // CLaim to be filled by Db user
            var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.Name, "Event Manager"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, "Admin"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, "admin123@gmail.com"),
                new Claim(ClaimTypes.Role,"1" )
            };

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(tokenKey));

            var signingCredentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                tokenIssuer,
                tokenAudience,
                claims,
                DateTime.Now.AddMinutes(-1),
                DateTime.Now.AddMinutes(tokenDuration),
                signingCredentials);

            var tokenData = new JwtSecurityTokenHandler().WriteToken(token);
            return await Task.FromResult(tokenData);
        }

    }
}
