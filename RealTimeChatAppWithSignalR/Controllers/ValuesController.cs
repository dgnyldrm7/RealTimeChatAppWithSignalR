using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeChatAppWithSignalR.DatabaseContx;
using RealTimeChatAppWithSignalR.HubContent;


namespace RealTimeChatAppWithSignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //Dependency Injection!
        private readonly IHubContext<TypeSafeMessage> hubContext;
        private readonly DatabaseContext context;
        public ValuesController(DatabaseContext _context , IHubContext<TypeSafeMessage> _hubContext)
        {
            context = _context;
            hubContext = _hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string message)
        {
            await hubContext.Clients.All.SendAsync("ReceiveSendAllMessage", message);

            string yourMessage = message;

            return Ok(yourMessage);
        }

    }
}
