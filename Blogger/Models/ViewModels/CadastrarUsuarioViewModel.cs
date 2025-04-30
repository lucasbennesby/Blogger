using System.ComponentModel.DataAnnotations;

namespace Blogger.Models.ViewModels
{
    public class CadastrarUsuarioViewModel
    {
        [Required(ErrorMessage ="É necessario inserir um nome")]
        [StringLength(50, ErrorMessage ="Limite maximo de 50 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessario inserir um Email")]
        [StringLength(30, ErrorMessage = "Limite maximo de 30 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "É necessario inserir uma senha")]
        [StringLength(20, ErrorMessage = "Limite maximo de 20 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required(ErrorMessage = "É necessario inserir a confirmação de senha")]
        [StringLength(20, ErrorMessage = "Limite maximo de 20 caracteres")]
        [DataType(DataType.Password)]
        [Compare("Senha",ErrorMessage ="As senhas não são iguais")]
        public string ConfirmarSenha { get; set; }
        public string Perfil {  get; set; }
        public string FotoDePerfil { get; set; }
    }
}
