using Blogger.Models;
using Blogger.Models.ViewModels;

namespace Blogger.Repositories
{
    public interface IPublicacaoRepository
    {
        Task<Publicacao> Criar(CadastrarPublicacaoViewModel publicacaoVM);

    }
}
