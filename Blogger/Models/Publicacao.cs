﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public DateTime? Data { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeAutor { get; set; }
        [MaybeNull]
        public DateTime DataAtualizacao { get; set; }
        public string Imagem { get; set; }

        public List<Comentario> Comentarios { get; set; }

        [ForeignKey("UsuarioId")]

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Tags { get; set; }

        public string HoraAteAgora(DateTime? data)
        {
            DateTime dataAtual = DateTime.Now;
            TimeSpan diferenca = (TimeSpan)(dataAtual - data);

            var diferencaDeTempoMinutos = (int)diferenca.TotalMinutes;
            var diferencaDeTempoHoras = (int)diferenca.TotalHours;

            string sResult = diferencaDeTempoMinutos.ToString() + "m";

            if (diferencaDeTempoMinutos > 60)
            {
                int result = (int)diferenca.TotalHours;
                sResult = result.ToString() + "h";
            }
            else if(diferencaDeTempoHoras > 24)
            {
                int result = (int)diferenca.TotalDays;
                sResult = result.ToString() + "d";
            }

            return sResult.ToString();
                      
        }
    }
    
}
