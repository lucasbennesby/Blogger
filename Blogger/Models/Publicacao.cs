﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Blogger.Models
{
    public class Publicacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }
        [StringLength(100)]
        public string SubtTitulo { get; set; }
        [Required]
        public string Conteudo { get; set; }
        public DateTime? Date { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeAutor { get; set; }
    }
}