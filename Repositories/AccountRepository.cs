using messanger.Data;
using messanger.Models;
using Microsoft.EntityFrameworkCore;

namespace messanger.Repositories
{
    public class AccountRepository
    {
        private readonly MessangerDbContext context;

        public AccountRepository(MessangerDbContext _context)
        {
            context = _context;
        }

        public async Task<Account?> GetAuthAsync(string login, string password)
        {
            return await context.Account.FirstOrDefaultAsync(p => p.Login == login && p.Password == password);
        }

        public async Task<int?> NewAccountAsync(Account account)
        {
            try
            {
                context.Account.Add(account);
                await context.SaveChangesAsync();
                return account.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
