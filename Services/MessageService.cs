using messanger.Models;
using messanger.Repositories;

namespace messanger.Services
{
    public class MessageService
    {
        private readonly MessageRepository repository;

        public MessageService(MessageRepository _repository)
        {
            repository = _repository;
        }

        public async Task<List<Message>?> GetMessagesAsync(int ChatId)
        {
            return await repository.GetMessagesAsync(ChatId);
        }
        
        public async Task<Boolean> NewMessagesAsync(int ChatId, string Text, int user)
        {
            return await repository.NewMessagesAsync(new Message { ChatId = ChatId, AuthorId = user, Text = Text, Datetime = DateTime.UtcNow});
        }
    }
}
