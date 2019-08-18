using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        private const string CAMINHO_INEXISTENTE = "Caminho Inexistente";
        private const string LIVRO_CADASTRADO_COM_SUCESSO = "Livro Cadastrado com Sucesso";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        public void Configure(IApplicationBuilder app)
        {
            //Mapeamento ASP.NET CORE
            var roteamento = new RouteBuilder(app);
            roteamento.MapRoute("Livros/ParaLer",LivrosParaLer);
            roteamento.MapRoute("Livros/Lidos",LivrosLidos);
            roteamento.MapRoute("Livros/Lendo",LivrosLendo);
            roteamento.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroNovoLivro);
            roteamento.MapRoute("Livros/Detalhes/{id:int}", ExibeDetalhes);
            roteamento.MapRoute("Cadastro/NovoLivro",ExibeNovoFormulario);
            roteamento.MapRoute("Cadastro/Incluir", ProcessaFormulario);
            var rotas = roteamento.Build();
            app.UseRouter(rotas);

            //app.Run(RotearManual);
        }

        private Task ExibeDetalhes(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(i=> i.Id == Convert.ToInt32(context.GetRouteValue("id")));
            return context.Response.WriteAsync(livro.Detalhes());
        }

        private Task CadastroNovoLivro(HttpContext context)
        {
            var livro = new Livro()
            {
                Autor = context.GetRouteValue("autor").ToString(),
                Titulo = context.GetRouteValue("nome").ToString()
            };
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return context.Response.WriteAsync(LIVRO_CADASTRADO_COM_SUCESSO);
        }

        private Task ExibeNovoFormulario(HttpContext context)
        {
            var html = @"<html>
                <form action='/Cadastro/Incluir'>
                    <label>titulo</label>
                    <input name='titulo' />
                    <label>autor</label>
                    <input name='autor' >
                    <button>Gravar</button>
                </form>
            </html>";
            return context.Response.WriteAsync(html);
        }
        private Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.Request.Query["titulo"].First(),
                Autor = context.Request.Query["autor"].First()
            };
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return context.Response.WriteAsync(LIVRO_CADASTRADO_COM_SUCESSO);
        }

        private string CarregaArquivoHTML(string nomeArquivo)
        {
            var caminhoArquivo = Path.Combine("html",nomeArquivo);
            return File.OpenText(caminhoArquivo).ReadToEnd();
        }
        public Task LivrosParaLer(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repo.ParaLer.ToString());
        }

        public Task LivrosLidos(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repo.Lidos.ToString());
        }

        public Task LivrosLendo(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repo.Lendo.ToString());
        }

        

        public Task RotearManual(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();

            var caminhosAtendidos = new Dictionary<string,RequestDelegate>
             {
                { "/Livros/ParaLer",LivrosParaLer},
                { "/Livros/Lendo",LivrosLendo},
                { "/Livros/Lidos",LivrosLidos}
            };

            
            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return context.Response.WriteAsync(CAMINHO_INEXISTENTE);
            }

            
        }
    }
}