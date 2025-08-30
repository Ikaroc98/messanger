using messanger.Data;
using messanger.Models;
using Microsoft.EntityFrameworkCore;

namespace messanger.Repositories
{
    public class MessageRepository
    {
        private readonly MessangerDbContext context;

        public MessageRepository(MessangerDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Message>?> GetMessagesAsync(int ChatId)
        {
            try
            {
                return await context.Messages.Where(m => m.ChatId == ChatId).OrderBy(m => m.Datetime).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<Boolean> NewMessagesAsync(Message message)
        {
            try
            {
                await context.Messages.AddAsync(message);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            
        }
    }
}
