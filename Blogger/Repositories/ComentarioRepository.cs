using Blogger.Contexto;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        public readonly ContextoBlogger _contextoBlogger;

        public ComentarioRepository(ContextoBlogger context)
        {

            _contextoBlogger = context;
        }

        [HttpPost]
        public async Task Criar(CadastrarComentarioViewModel comentarioVM)
        {
            var comentario = new Comentario
            {
                Autor = comentarioVM.Autor,
                Data = DateTime.Now,
                Descricao = comentarioVM.Descricao,
                PublicacaoId = comentarioVM.PublicacaoId,
            };

            _contextoBlogger.Comentario.Add(comentario);
            await _contextoBlogger.SaveChangesAsync();           
        }

        public Task<List<Comentario>> Listar(int publicacaoId)
        {
            throw new NotImplementedException();
        }
    }
}
