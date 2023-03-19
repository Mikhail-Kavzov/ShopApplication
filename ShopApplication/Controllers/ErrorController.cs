using Microsoft.AspNetCore.Mvc;

namespace ShopApplication.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult PageNotFound() => View();
    }
}
