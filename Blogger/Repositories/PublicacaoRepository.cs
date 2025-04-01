
using Blogger.Contexto;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Claims;


namespace Blogger.Repositories
{
    public class PublicacaoRepository : IPublicacaoRepository
    {
        private readonly ContextoBlogger _contextoBlogger;
        private readonly string _sistema;
        private readonly ClaimsPrincipal _usuarioService;
        private readonly ILikesRepository _Likes;

        public PublicacaoRepository(ContextoBlogger context, IWebHostEnvironment sistema, IHttpContextAccessor httpContextAccessor, ILikesRepository likes)
        {
            _contextoBlogger = context;
            _sistema = sistema.WebRootPath;
            _usuarioService = httpContextAccessor.HttpContext.User;
            _Likes = likes;
        }
        public async Task<Publicacao> Criar(CadastrarPublicacaoViewModel publicacaoVM, IFormFile imagem)
        {
            var caminhoDaImagem = GerarCaminhoDaImagemESalvarNaPasta(imagem);
            var publicacao = new Publicacao();

            publicacao.Titulo = publicacaoVM.Titulo;
            publicacao.SubtTitulo = publicacaoVM.SubtTitulo;
            publicacao.Conteudo = publicacaoVM.Conteudo;
            publicacao.Data = DateTime.Now;
            publicacao.DataAtualizacao = DateTime.MinValue;
            publicacao.Imagem = caminhoDaImagem;
            publicacao.UsuarioId = int.Parse(_usuarioService.FindFirst("UsuarioId").Value);
            publicacao.NomeAutor = _usuarioService.FindFirst(ClaimTypes.Name).Value;
            publicacao.Tags = "mock tag";

            _contextoBlogger.Add(publicacao);
            await _contextoBlogger.SaveChangesAsync();

            return publicacao;
        }

        private string GerarCaminhoDaImagemESalvarNaPasta(IFormFile imagem)
        {
            var codigoUnicoDaImagem = Guid.NewGuid().ToString();
            var nomeDaImagem = codigoUnicoDaImagem + imagem.FileName.Trim().Replace(" ", "").ToLower();
            var pastaDeImagens = _sistema + "\\imagens\\";

            if (!Directory.Exists(pastaDeImagens))
            {
                Directory.CreateDirectory(pastaDeImagens);
            }

            using (var stream = File.Create(pastaDeImagens + nomeDaImagem))
            {
                imagem.CopyToAsync(stream).Wait();
            }

            return nomeDaImagem;
        }

        public async Task<List<Publicacao>> Listar()
        {
            var lista = await _contextoBlogger.Publicacao
                .Include(p => p.Likes)
                .ToListAsync();

            return lista;
        }

        public async Task<Publicacao> BuscarPorId(int id)
        {
            Publicacao publicacao = await _contextoBlogger.Publicacao
                .Include(x => x.Comentarios)
                .FirstOrDefaultAsync(x => x.Id == id);

            return publicacao;
        }

        public async Task Editar(Publicacao publicacao, IFormFile imagem)
        {
            var pastaDeImagens = _sistema + "\\imagens\\";

            if (imagem == null)
            {
                publicacao.Imagem = publicacao.Imagem;
            }
            else
            {
                File.Delete(pastaDeImagens + publicacao.Imagem);
                var caminhoImagem = GerarCaminhoDaImagemESalvarNaPasta(imagem);
                publicacao.Imagem = caminhoImagem;
            }
            publicacao.DataAtualizacao = DateTime.Now;

            _contextoBlogger.Publicacao.Update(publicacao);
            await _contextoBlogger.SaveChangesAsync();
        }

        public async Task Deletar(int id)
        {
            var pastaDeImagens = _sistema + "\\imagens\\";
            var publicacao = await _contextoBlogger.Publicacao.FirstOrDefaultAsync(x => x.Id == id);

            File.Delete(pastaDeImagens + publicacao.Imagem);

            _contextoBlogger.Publicacao.Remove(publicacao);
            await _contextoBlogger.SaveChangesAsync();

        }

        public async Task Like( int idUsuario, int idPublicacao)
        {
            var deuLike = await _Likes.VerificarSeLikeExiste(idUsuario, idPublicacao);

            if (!deuLike)
                await _Likes.AdicionarLike(idUsuario, idPublicacao);
            else
                _Likes.RemoverLike(idUsuario, idPublicacao);
        }
    }
}
