using Blogger.Models;

namespace Blogger.Repositories
{
    public interface IComentarioRepository
    {
        Task<List<Comentario>> Listar(int publicacaoId);
    }
}
