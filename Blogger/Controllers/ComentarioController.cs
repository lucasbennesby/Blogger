using Blogger.Models.ViewModels;
using Blogger.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioController(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Criar(CadastrarComentarioViewModel comentarioVM)
        {
            if(ModelState.IsValid)
                await _comentarioRepository.Criar(comentarioVM);

            return RedirectToAction("Detalhes", "Publicacao", new { id = comentarioVM.PublicacaoId });

        }
    }
}
