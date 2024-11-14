using Blogger.Contexto;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blogger.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        public readonly ContextoBlogger _contextoBlogger;
        private readonly ClaimsPrincipal _userService;

        public ComentarioRepository(ContextoBlogger context, IHttpContextAccessor httpContextAccessor)
        {

            _contextoBlogger = context;
            _userService = httpContextAccessor.HttpContext.User;
        }

        [HttpPost]
        public async Task Criar(CadastrarComentarioViewModel comentarioVM)
        {
            var comentario = new Comentario
            {
                Autor = _userService.FindFirst(ClaimTypes.Name).Value,
                UsuarioId = int.Parse(_userService.FindFirst("UsuarioId").Value),
                Data = DateTime.Now,
                Descricao = comentarioVM.Descricao,
                PublicacaoId = comentarioVM.PublicacaoId,
            };

            _contextoBlogger.Comentario.Add(comentario);
            await _contextoBlogger.SaveChangesAsync();           
        }

        public Task<List<Comentario>> Listar(int publicacaoId)
        {
            throw new NotImplementedException();
        }
    }
}
