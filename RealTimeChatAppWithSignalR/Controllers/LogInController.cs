using Microsoft.AspNetCore.Mvc;
using RealTimeChatAppWithSignalR.DatabaseContx;

namespace RealTimeChatAppWithSignalR.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LogInController : ControllerBase
    {
        private readonly DatabaseContext context;
        public LogInController(DatabaseContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Login(string userName , string Password)
        {
            
            return Ok();
        }



    }
}
