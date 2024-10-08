using Blogger.Models;
using Blogger.Models.ViewModels;

namespace Blogger.Repositories
{
    public interface IPublicacaoRepository
    {
        Task<Publicacao> Criar(CadastrarPublicacaoViewModel publicacaoVM);
        Task<List<Publicacao>> Listar();

        Task<Publicacao> BuscarPorId(int id);

        Task Editar(Publicacao publicacao);

        Task Deletar(int id);

    }
}
