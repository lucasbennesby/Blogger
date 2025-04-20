using System.ComponentModel.DataAnnotations;

namespace Blogger.Models.ViewModels
{
    public class EditarPerfilViewModel
    {
        [Required(ErrorMessage = "É necessario inserir um nome")]
        [StringLength(50, ErrorMessage = "Limite maximo de 50 caracteres")]
        public string Nome { get; set; }

    }
}
