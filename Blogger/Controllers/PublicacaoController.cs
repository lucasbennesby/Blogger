using Blogger.Contexto;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Blogger.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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

            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarPublicacaoViewModel publicacaoVM)
        {
            await _publicacaoRepository.Criar(publicacaoVM);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var publicacao = await _publicacaoRepository.BuscarPorId(id);

            return View(publicacao);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Publicacao publicacao)
        {
            await _publicacaoRepository.Editar(publicacao);

            return RedirectToAction("Index");
        }
       



    }
}