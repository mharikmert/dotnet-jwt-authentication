using Microsoft.AspNetCore.Mvc;

namespace dotnet_jwt_authentication.Controllers
{
    public class UserController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}