using Blogger.Models;

namespace Blogger.Repositories
{
    public interface IAdminRepository
    {
        Task<List<Usuario>> ListarUsuarios();
    }
}
