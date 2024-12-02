﻿using Blogger.Models;
using Blogger.Models.ViewModels;
using Blogger.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            if(await _usuarioRepository.VerificarEmail(usuarioVM.Email))
            {
                ModelState.AddModelError("Email", "Este endereço de email ja está cadastrado no sistema");

                return View(usuarioVM);
            }
            
            var usuarioCriado = await _usuarioRepository.CadastrarUsuario(usuarioVM);
            if(usuarioCriado != null)
            {
                return await Login(new LoginViewModel { Email = usuarioCriado.Email, Senha = usuarioCriado.Senha });
            }

            return View(usuarioVM);
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

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Publicacao");
        }
    }
}
