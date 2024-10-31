using Blogger.Contexto;
using Blogger.Models;
using Blogger.Models.ViewModels;
using System.Runtime.CompilerServices;

namespace Blogger.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContextoBlogger _usuarioContext;
        public UsuarioRepository(ContextoBlogger context)
        {
            _usuarioContext = context;
        }

        public async Task CadastrarUsuario(CadastrarUsuarioViewModel usuarioVM)
        {
            var usuario = new Usuario();
            usuario.Nome = usuarioVM.Nome;
            usuario.Email = usuarioVM.Email;
            usuario.Senha = usuarioVM.Senha;

            _usuarioContext.Add(usuario);
            await _usuarioContext.SaveChangesAsync();
        }
    }
}
