using Blogger.Contexto;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Blogger.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Blogger.Controllers
{
    public class PublicacaoController : Controller
    {
        private readonly IPublicacaoRepository _publicacaoRepository;

        public PublicacaoController(IPublicacaoRepository publicacao)
        {
            _publicacaoRepository = publicacao;
        }

        public IActionResult Index()
        {
            return View();
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


    }
}