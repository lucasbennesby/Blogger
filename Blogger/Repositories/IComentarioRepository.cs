using Blogger.Models;
using Blogger.Models.ViewModels;

namespace Blogger.Repositories
{
    public interface IComentarioRepository
    {
        Task<List<Comentario>> Listar(int publicacaoId);

        Task Criar(CadastrarComentarioViewModel comentarioVM);
    }
}
