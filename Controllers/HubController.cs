using messanger.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace messanger.Controllers
{
    public class HubController : ControllerBase
    {
        private readonly IHubContext<ChatHub> context;

        public HubController(IHubContext<ChatHub> _context)
        {
            context = _context;
        }

        [Authorize]
        [HttpPost]

        public ActionResult<string> NewMessage(string message)
        {
            context.Clients.All.SendAsync("Message", message);
            return message;
        }
    }
}
