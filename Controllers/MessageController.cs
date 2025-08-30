using messanger.Models;
using messanger.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace messanger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly MessageService messageService;
        public MessageController(MessageService _messageService) => messageService = _messageService;

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetMessages(int ChatId)
        {
            var result= await messageService.GetMessagesAsync(ChatId);
            if (result is not null)
            {
                return Ok(result);
            }
            else
            {
                return Problem();
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> NewMessagew([FromBody] NewMessage message)
        {
            string? user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (user is not null && await messageService.NewMessagesAsync(message.ChatId, message.Text, int.Parse(user)))
                return Ok();
            else
                return Problem();
        }
    }
    
    public record NewMessage(int ChatId, string Text);

}
