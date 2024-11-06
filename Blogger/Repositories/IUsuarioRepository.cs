using Blogger.Models.ViewModels;

namespace Blogger.Repositories
{
    public interface IUsuarioRepository
    {
        Task CadastrarUsuario(CadastrarUsuarioViewModel usuarioVM);

        Task<bool> AutorizarUsuario(LoginViewModel usuarioVM, HttpContext context);
    }
}
    