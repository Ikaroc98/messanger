using messanger.Services;
using Microsoft.AspNetCore.Mvc;

namespace messanger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountInfoController : ControllerBase
    {
        private readonly AccountInfoService accountInfoService;

        public AccountInfoController(AccountInfoService _accountInfoService)
        {
            accountInfoService = _accountInfoService;
        }

        [HttpPost]
        public async Task<IActionResult> AccountInfo([FromBody] RegistrationDataInfo accountsInfo)
        {
            Console.WriteLine(accountsInfo.Name+' '+accountsInfo.IdAccount.ToString()+' '+accountsInfo.Surname+' '+accountsInfo.Birth.ToString());
            return Ok(new { res = await accountInfoService.CrateAccountInfoAsync(accountsInfo.IdAccount, accountsInfo.Name, accountsInfo.Surname, accountsInfo.Birth) });
        }
    }
    public record RegistrationDataInfo(int IdAccount, string Name, string Surname, DateTime Birth);
}
