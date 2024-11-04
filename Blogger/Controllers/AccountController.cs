using Blogger.Models.ViewModels;
using Blogger.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public AccountController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarUsuarioViewModel usuarioVM)
        {
            await _usuarioRepository.CadastrarUsuario(usuarioVM);

            return RedirectToAction("Index", "Publicacao");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if(ModelState.IsValid)
            {
                var logado = await _usuarioRepository.AutorizarUsuario(loginVM,HttpContext);
                
                if (logado)
                    return RedirectToAction("Index", "Publicacao");
            }
            return View();
        }
    }
}
