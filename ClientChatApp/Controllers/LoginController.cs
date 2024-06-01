using Microsoft.AspNetCore.Mvc;

namespace ClientChatApp.Controllers
{
    public class LoginController : Controller
    {

        [Route("/login")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
