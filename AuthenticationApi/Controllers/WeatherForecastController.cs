using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace AuthenticationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController(IConfiguration config) : ControllerBase
    {
        private static ConcurrentDictionary<string, string> UserData { get; set; } =
            new ConcurrentDictionary<string, string>();
       

        [HttpGet]
        public async Task<IActionResult> Login(string email, string password)
        {
            var getEmail = UserData!.Keys.Where(e => e.Equals(email)).FirstOrDefault();
            if (!string.IsNullOrEmpty(getEmail))
            {
                UserData.TryGetValue(getEmail, out string? dbPassword);
                if (!Equals(dbPassword, password))
                    return BadRequest("Invalidcreditional");
                string jwtToken = GenerateToken(getEmail);
                return Ok(jwtToken);
            }
            return NotFound("Email Not found");
        }

        private string GenerateToken(string getEmail)
        {
            var key = config.GetValue
        }
    }
}
