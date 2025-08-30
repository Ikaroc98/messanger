using messanger.Models;
using Microsoft.EntityFrameworkCore;

namespace messanger.Data
{
    public class MessangerDbContext : DbContext
    {
        public MessangerDbContext(DbContextOptions<MessangerDbContext> options) : base(options) { }

        public DbSet<Account> Account { get;set;}
        public DbSet<AccountInfo> AccountsInfo { get;set;}
        public DbSet<Message> Messages { get;set;}
        public DbSet<Chat> Chats { get;set;}
    }
}
