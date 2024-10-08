
using Blogger.Contexto;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            publicacao.DataAtualizacao = DateTime.MinValue;        
            publicacao.NomeAutor = publicacaoVM.NomeAutor;

            _contextoBlogger.Add(publicacao);
            await _contextoBlogger.SaveChangesAsync();

            return publicacao;
        }

        public async Task<List<Publicacao>> Listar()
        {
            var lista = await _contextoBlogger.Publicacao.ToListAsync();

            return lista;
        }

        public async Task<Publicacao> BuscarPorId(int id)
        {
            Publicacao publicacao = await _contextoBlogger.Publicacao.FirstOrDefaultAsync(x => x.Id == id);

            return publicacao;
        }

        public async Task Editar(Publicacao publicacao)
        {
            publicacao.DataAtualizacao = DateTime.Now;

            _contextoBlogger.Publicacao.Update(publicacao);
           await _contextoBlogger.SaveChangesAsync();

        }

        public async Task Deletar(int id)
        {
            var publicaco = await _contextoBlogger.Publicacao.FirstOrDefaultAsync(x => x.Id == id);
            _contextoBlogger.Publicacao.Remove(publicaco);
            await _contextoBlogger.SaveChangesAsync();

        }
    }
}
