using messanger.Data;
using messanger.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace messanger.Repositories
{
    public class AccountInfoRepository
    {
        private readonly MessangerDbContext context;
        public AccountInfoRepository(MessangerDbContext _context)
        {
            context = _context;
        }

        public async Task<Boolean> CrateAccountInfoAsync(AccountInfo accountInfo)
        {
            try
            {
                context.AccountsInfo.Add(accountInfo);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<AccountInfo> GetAccountInfo(int user)
        {
            return await context.AccountsInfo.FirstAsync(m => m.Accountid == user);
        }
    }
}
