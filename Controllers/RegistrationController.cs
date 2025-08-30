using messanger.Models;
using messanger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace messanger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly AccountService accountService;
        public RegistrationController(AccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] RegistrationData account)
        {
            return Ok(new { res = await accountService.NewAccountAsync(account.Login, account.Password) });
        }
    }

    public record RegistrationData(string Login, string Password);
}