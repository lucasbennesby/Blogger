using System.ComponentModel.DataAnnotations;

namespace Blogger.Models.ViewModels
{
    public class CadastrarUsuarioViewModel
    {
        [Required(ErrorMessage ="campo obrigatorio")]
        [StringLength(50, ErrorMessage ="Limite maximo de 50 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "campo obrigatorio")]
        [StringLength(30, ErrorMessage = "Limite maximo de 30 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "campo obrigatorio")]
        [StringLength(20, ErrorMessage = "Limite maximo de 20 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required(ErrorMessage = "campo obrigatorio")]
        [StringLength(20, ErrorMessage = "Limite maximo de 20 caracteres")]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        public string ConfirmarSenha { get; set; }

        public string Perfil {  get; set; }
    }
}
