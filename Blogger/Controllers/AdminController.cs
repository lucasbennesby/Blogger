using Blogger.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }


        [Authorize(Policy = "ADM")] 
        public async Task<IActionResult> AdminPage()
        {
            var usuarios = await _adminRepository.ListarUsuarios();

            return View(usuarios);
        }

        public IActionResult Denied()
        {         
            return View();
        }

    }
}
