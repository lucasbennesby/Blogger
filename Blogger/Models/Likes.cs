using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blogger.Models
{
    public class Likes
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId{ get; set; }

        [ForeignKey("PublicacaoId")]
        public int PublicacaoId { get; set; } 
    }
}
