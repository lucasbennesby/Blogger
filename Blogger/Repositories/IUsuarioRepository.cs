using Blogger.Models;
using Blogger.Models.ViewModels;

namespace Blogger.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> CadastrarUsuario(CadastrarUsuarioViewModel usuarioVM);

        Task<bool> AutorizarUsuario(LoginViewModel usuarioVM, HttpContext context);
        Task<bool> VerificarEmail(string email);
    }
}
    