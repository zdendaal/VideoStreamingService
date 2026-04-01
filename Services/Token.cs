using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace VideoStreamingService.Services
{
    public class Token
    {
        /// <summary>
        /// Generates jwt token for user with given ID
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GenerateJwtToken(string email, string userId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super_secret_key_12345"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, email)
            };

            var token = new JwtSecurityToken(
                issuer: BusinessSettings.s_name,
                audience: BusinessSettings.s_name,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(BusinessSettings.s_tokenExpiration.TotalHours),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
