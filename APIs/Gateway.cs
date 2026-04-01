using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Text;
using VideoStreamingService.Database;
using System.Reflection.Metadata.Ecma335;
using VideoStreamingService.Services;

namespace VideoStreamingService.APIs
{
    [ApiController]
    [Route("[controller]")]
    public class Gateway : ControllerBase    
    {
        public readonly BusinessData _businessData;
        public readonly Token _token;

        public Gateway([FromServices]BusinessData businessData, [FromServices]Token token)
        {
            _businessData = businessData;
            _token = token;
        }


        [AllowAnonymous]
        [HttpGet("/login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var hasher = new PasswordHasher<object>();
            string hashed = hasher.HashPassword(email, password);

            var result = _businessData.Users.Where(x => x.Email == email)
                .Select(x => new { hash = x.passwordHash, id = x.Id } )
                .SingleOrDefault();

            if (result == null) return Unauthorized("Bad email or password");

            string token = _token.GenerateJwtToken(email, result.id.ToString());
            return Ok(token);
        }
    }
}
