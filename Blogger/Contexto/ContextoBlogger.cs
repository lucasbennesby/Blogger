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
    }
}
