using Blogger.Contexto;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blogger.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContextoBlogger _usuarioContext;
        public UsuarioRepository(ContextoBlogger context)
        {
            _usuarioContext = context;
        }

        public async Task<bool> AutorizarUsuario(LoginViewModel usuarioVM,HttpContext context)
        {
            var usuario = await _usuarioContext.Usuario.FirstOrDefaultAsync(x => x.Email == usuarioVM.Email && x.Senha == usuarioVM.Senha);
            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,usuario.Nome),
                    new Claim(ClaimTypes.Role,"Membro")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return true;
            }
            return false;
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
