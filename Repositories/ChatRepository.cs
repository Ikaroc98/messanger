using messanger.Data;
using messanger.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace messanger.Repositories
{
    public class ChatRepository
    {
        private readonly MessangerDbContext context;

        public ChatRepository(MessangerDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Chat>?> GetChatsAsync(int user)
        {
            try
            {
                return await context.Chats.Where(m => m.FirstUserId == user || m.SecondUserId == user).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
