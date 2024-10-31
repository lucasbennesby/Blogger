using Blogger.Models.ViewModels;

namespace Blogger.Repositories
{
    public interface IUsuarioRepository
    {
        Task CadastrarUsuario(CadastrarUsuarioViewModel usuarioVM);
    }
}
    