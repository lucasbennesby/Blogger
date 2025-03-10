using Microsoft.Build.Framework;

namespace Blogger.Repositories
{
    public interface ILikesRepository
    {
        Task<bool> VerificarSeLikeExiste(int idUsuario, int idPublicacao);

        Task AdicionarLike(int idUsuario, int idPublicacao);
        void RemoverLike(int idUsuario, int idPublicacao);
    }
}
