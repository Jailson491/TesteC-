using Microsoft.IdentityModel.Tokens;
using Santader.UserControl.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Santader.UserControl.Services
{
    public static class TokenServices
    {
        public static JsonWebToken GenarateToken(User users)
        {
            var TokenHandle = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.UserName.ToString()),
                    new Claim(ClaimTypes.Role, users.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
        };
            var Token = TokenHandle.CreateToken(TokenDescriptor);

            return new JsonWebToken
            {
                AccessToken = ((JwtSecurityToken)Token).RawData,
                authenticated = true,
                ExpiresIn = (long)TimeSpan.FromMinutes(120).TotalSeconds,
            };
        }
    }
}
