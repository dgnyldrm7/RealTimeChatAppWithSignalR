using System.Diagnostics;
using ClientChatApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientChatApp.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
