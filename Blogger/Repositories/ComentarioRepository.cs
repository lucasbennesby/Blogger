using Blogger.Contexto;
using Blogger.Models;

namespace Blogger.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        public readonly ContextoBlogger _contextoBlogger;

        public ComentarioRepository(ContextoBlogger context)
        {

            _contextoBlogger = context;
        }

        public Task<List<Comentario>> Listar(int publicacaoId)
        {
            throw new NotImplementedException();
        }
    }
}
