using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    public class ComentarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
