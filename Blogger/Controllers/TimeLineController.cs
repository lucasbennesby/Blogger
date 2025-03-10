using Blogger.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blogger.Controllers
{
    public class TimeLineController : Controller
    {
        private readonly IPublicacaoRepository _publicacaoRepository;
        private readonly ILikesRepository _likeRepository;

        public TimeLineController(IPublicacaoRepository publicacao, ILikesRepository likeRepository)
        {
            _publicacaoRepository = publicacao;
            _likeRepository = likeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _publicacaoRepository.Listar();
            ViewBag.UsuarioLogado = HttpContext.User.Identity?.IsAuthenticated;
            ViewBag.UsuarioId = HttpContext.User.FindFirstValue("UsuarioId");
            return View(lista);
        }

        public async Task<IActionResult> LikeTimeLine(int idUsuario,int idPublicacao)
        {
            await _publicacaoRepository.Like(idUsuario, idPublicacao);

            return RedirectToAction("Index", "TimeLine");
        }
    }
}

