﻿using Blogger.Models;
using Blogger.Models.ViewModels;
using Blogger.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blogger.Controllers
{
    public class TimeLineController : Controller
    {
        private readonly IPublicacaoRepository _publicacaoRepository;
        private readonly ILikesRepository _likeRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public TimeLineController(IPublicacaoRepository publicacao, ILikesRepository likeRepository, IUsuarioRepository usuarioRepository)
        {
            _publicacaoRepository = publicacao;
            _likeRepository = likeRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _publicacaoRepository.Listar();
            ViewBag.UsuarioLogado = HttpContext.User.Identity?.IsAuthenticated;
            ViewBag.UsuarioId = HttpContext.User.FindFirstValue("UsuarioId");
            return View(lista);
        }

        public async Task<IActionResult> Index1()
        {
            var lista = await _publicacaoRepository.Listar();
            ViewBag.UsuarioLogado = HttpContext.User.Identity?.IsAuthenticated;
            ViewBag.UsuarioId = HttpContext.User.FindFirstValue("UsuarioId");
            return View(lista);
        }

        [Authorize(Roles = "ADM,UserPro,User")]
        [HttpPost]
        public async Task<IActionResult> LikeTimeLine([FromBody] TimeLineViewModel timeLine)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                //return RedirectToAction("Cadastrar", "Account");
                return Json(new { success = false });
            }
            await _publicacaoRepository.Like(timeLine.UsuarioIdVM, timeLine.PublicacaoIdVM);

            return Json(new { success = true });
        }
    }
}

