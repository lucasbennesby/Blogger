﻿using System.ComponentModel.DataAnnotations;

namespace Blogger.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Senha { get; set; }
    }
}
