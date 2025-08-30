using messanger.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace messanger.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    
    public class LoginController : ControllerBase
    {
        private readonly AccountService accountService;

        public LoginController(AccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Acc request)
        {
            var result = await accountService.GetAuthAsync(request.login, request.password);

            if (result is null) return Unauthorized();

            return Ok(new { access_token=result});
        }
    }
    
    public record Acc(string login, string password);
}
