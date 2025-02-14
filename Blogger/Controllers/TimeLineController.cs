using Blogger.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blogger.Controllers
{
    public class TimeLineController : Controller
    {
        private readonly IPublicacaoRepository _publicacaoRepository;

        public TimeLineController(IPublicacaoRepository publicacao)
        {
            _publicacaoRepository = publicacao;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _publicacaoRepository.Listar();
            ViewBag.UsuarioLogado = HttpContext.User.Identity?.IsAuthenticated;
            ViewBag.UsuarioId = HttpContext.User.FindFirstValue("UsuarioId");
            return View(lista);
        }
    }
}
