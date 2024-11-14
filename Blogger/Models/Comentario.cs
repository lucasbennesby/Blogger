using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blogger.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }      
        [Required(ErrorMessage ="Comentário não pode ser vazio")]
        [StringLength(500)]
        public string Descricao { get; set; }
        [Required]
        [StringLength(50)]
        public string Autor { get; set; }
        public DateTime Data { get; set; }

        [ForeignKey("PublicacaoId")]
        public int PublicacaoId { get; set; }
        public Publicacao Publicacao { get; set; }

        public Usuario Usuario { get; set; }
        [ForeignKey("UsuarioId")]

        public int? UsuarioId { get; set; }

    }
}
