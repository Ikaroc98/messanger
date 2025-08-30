using messanger.Models;
using messanger.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace messanger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private ChatService chatService;
        
        public ChatController(ChatService _chatService)
        {
            chatService = _chatService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            string? user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;//"1";
            if (user is not null)
            {
                var result = await chatService.GetChatsAsync(int.Parse(user));
                return Ok(result);
            }
            else
                return Problem();
        }

    }
}
