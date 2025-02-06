using Blogger.Models;
using Blogger.Models.ViewModels;
using Blogger.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using System.Security.Claims;

namespace Blogger.Controllers
{
    public class PublicacaoController : Controller
    {
        private readonly IPublicacaoRepository _publicacaoRepository;

        public PublicacaoController(IPublicacaoRepository publicacao)
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

        [HttpGet]
        [Authorize(Roles = "ADM,UserPro")]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarPublicacaoViewModel publicacaoVM, IFormFile imagem)
        {
            await _publicacaoRepository.Criar(publicacaoVM, imagem);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {   

            var publicacao = await _publicacaoRepository.BuscarPorId(id);
            return View(publicacao);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Publicacao publicacao, IFormFile imagem)
        {
            await _publicacaoRepository.Editar(publicacao, imagem);

            return RedirectToAction("Index");
        }


        public async Task<JsonResult> Deletar(int id)
        {
            await _publicacaoRepository.Deletar(id);

            var publicacao = await _publicacaoRepository.BuscarPorId(id);

            if (publicacao == null)
            {
                return Json(new { mensagem = "Apagado com sucesso!" });
            }

            return Json(new { mensagem = "Erro ao apagar publicação" });
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            ViewBag.UsuarioLogado = HttpContext.User.Identity?.IsAuthenticated;
            ViewBag.UsuarioId = HttpContext.User.FindFirstValue("UsuarioId");
            var publicacao = await _publicacaoRepository.BuscarPorId(id);

            ViewBag.UsuarioLogado = HttpContext.User.Identity?.IsAuthenticated;

            return View(publicacao);
        }
    }
}