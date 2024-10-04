
using Blogger.Contexto;
using Blogger.Models;
using Blogger.Models.ViewModels;

namespace Blogger.Repositories
{
    public class PublicacaoRepository : IPublicacaoRepository
    {  
        private readonly ContextoBlogger _contextoBlogger;
        public PublicacaoRepository(ContextoBlogger context) 
        {
            _contextoBlogger = context;
        }
        public async Task<Publicacao> Criar(CadastrarPublicacaoViewModel publicacaoVM)
        {
            var publicacao = new Publicacao();
            publicacao.Titulo = publicacaoVM.Titulo;
            publicacao.SubtTitulo = publicacaoVM.SubtTitulo;
            publicacao.Conteudo = publicacaoVM.Conteudo;
            publicacao.Data = DateTime.Now;
            publicacao.NomeAutor = publicacaoVM.NomeAutor;

            _contextoBlogger.Add(publicacao);
            await _contextoBlogger.SaveChangesAsync();

            return publicacao;

            
        }
    }
}
