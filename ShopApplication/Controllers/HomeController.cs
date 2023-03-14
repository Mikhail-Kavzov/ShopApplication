using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ShopApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}