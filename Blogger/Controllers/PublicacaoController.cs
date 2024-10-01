using Blogger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    public class PublicacaoController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}