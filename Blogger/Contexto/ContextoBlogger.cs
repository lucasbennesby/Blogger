using Blogger.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Contexto
{
    public class ContextoBlogger : DbContext
    {
        public ContextoBlogger(DbContextOptions<ContextoBlogger> options) : base(options)
        {

        }
        public DbSet<Publicacao> Publicacao { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
