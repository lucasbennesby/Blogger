using System.ComponentModel.DataAnnotations;

namespace Blogger.Models.ViewModels
{
    public class CadastrarPublicacaoViewModel
    {
        
        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }
        [StringLength(100)]
        public string SubtTitulo { get; set; }
        [Required]
        public string Conteudo { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeAutor { get; set; }
    }
}
