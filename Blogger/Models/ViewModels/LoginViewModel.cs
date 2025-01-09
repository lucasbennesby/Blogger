using System.ComponentModel.DataAnnotations;

namespace Blogger.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Você deve digitar um email.")]
        [StringLength(30, ErrorMessage = "Limite maximo de 30 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Você deve digitar uma senha.")]
        [StringLength(20, ErrorMessage = "Limite maximo de 20 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
