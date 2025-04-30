using Blogger.Contexto;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blogger.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContextoBlogger _usuarioContext;

        public UsuarioRepository(ContextoBlogger context, IHttpContextAccessor httpContextAccessor)
        {
            _usuarioContext = context;
        }

        public async Task<bool> AutorizarUsuario(LoginViewModel usuarioVM, HttpContext context)
        {
            var usuario = await _usuarioContext.Usuario.FirstOrDefaultAsync(x => x.Email == usuarioVM.Email && x.Senha == usuarioVM.Senha);
            if (usuario != null)
            {
                var claims = new List<Claim>()
                {
                    new(ClaimTypes.Name, usuario.Nome),
                    new(ClaimTypes.Email, usuario.Email),
                    new("UsuarioId", usuario.Id.ToString()),
                };

                if (usuario.Perfil == "User")
                    claims.Add(new Claim(ClaimTypes.Role, "User"));
                else if (usuario.Perfil == "UserPro")
                    claims.Add(new Claim(ClaimTypes.Role, "UserPro"));
                else
                    claims.Add(new Claim(ClaimTypes.Role, "ADM"));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return true;
            }
            return false;
        }


        public async Task<Usuario> CadastrarUsuario(CadastrarUsuarioViewModel usuarioVM)
        {
            var usuario = new Usuario();
            usuario.Nome = usuarioVM.Nome;
            usuario.Email = usuarioVM.Email;
            usuario.Senha = usuarioVM.Senha;
            usuario.Perfil = "UserPro";
            usuario.ImagemDePerfil = "provisorio";

            _usuarioContext.Add(usuario);
            await _usuarioContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<bool> VerificarEmail(string email)
        {
            var emailJaExiste = await _usuarioContext.Usuario.AnyAsync(x => x.Email == email);
            return emailJaExiste;
        }
        public async Task<Usuario> ObterUsuario(int id)
        {
            var usuario = await _usuarioContext.Usuario.FirstOrDefaultAsync(x => x.Id == id);

            return usuario;
        }

        public async Task<Usuario> EditarUsuario(EditarPerfilViewModel usuarioVM, int id)
        {
            var usuario = await ObterUsuario(id);

            if (usuarioVM.Nome != null)
            {
                usuario.Nome = usuarioVM.Nome;
            }

            _usuarioContext.Update(usuario);
            _usuarioContext.SaveChanges();
            return usuario;
        }
    }
}
