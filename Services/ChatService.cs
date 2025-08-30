using messanger.Repositories;
using messanger.Models;

namespace messanger.Services
{
    public class ChatService
    {
        private readonly ChatRepository repository;

        public ChatService(ChatRepository _repository)
        {
            repository = _repository;
        }

        public async Task<List<Chat>?> GetChatsAsync(int user)
        {
            var result = await repository.GetChatsAsync(user);
            return result;
        }
    }
}
