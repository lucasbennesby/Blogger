using Blogger.Contexto;
using Blogger.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Blogger.Repositories
{
    public class AdminRepository : IAdminRepository
    {

        private readonly ContextoBlogger _contextoBlogger;
        private readonly ClaimsPrincipal _userService;

        public AdminRepository(ContextoBlogger contextoBlogger, IHttpContextAccessor httpContextAccessor)
        {
            _contextoBlogger = contextoBlogger;
            _userService = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<Usuario>> ListarUsuarios()
        {
            var usuarios = new List<Usuario>();

            usuarios = await _contextoBlogger.Usuario.ToListAsync();

            return usuarios;

           
        }
    }
}
