using Blogger.Contexto;
using System.Security.Claims;

namespace Blogger.Repositories
{
    public class LikesRepository : ILikesRepository
    {
        private readonly ContextoBlogger _contextoBlogger;
        private readonly string _sistema;
        private readonly ClaimsPrincipal _usuarioService;
        public LikesRepository(ContextoBlogger context, IHttpContextAccessor httpContextAccessor)
        {
            _contextoBlogger = context;
            _usuarioService = httpContextAccessor.HttpContext.User;
        }
        public async Task<bool> VerificarSeLikeExiste(int idUsuario, int idPublicacao)
        {
            var deuLike = _contextoBlogger.Likes.Any(l => l.UsuarioId == idUsuario && l.PublicacaoId == idPublicacao);
            return deuLike;
        }

        public async Task AdicionarLike(int idUsuario, int idPublicacao)
        {
            await _contextoBlogger.Likes.AddAsync(new Models.Likes()
            {
                PublicacaoId = idPublicacao,
                UsuarioId = idUsuario,
            });

            await _contextoBlogger.SaveChangesAsync();
        }

        public void RemoverLike(int idUsuario, int idPublicacao)
        {
            var like = _contextoBlogger.Likes.SingleOrDefault(l => l.UsuarioId == idUsuario && l.PublicacaoId == idPublicacao);

            if (like != null)
            {
                _contextoBlogger.Likes.Remove(like);
                _contextoBlogger.SaveChanges();
            }
        }
    }
}
