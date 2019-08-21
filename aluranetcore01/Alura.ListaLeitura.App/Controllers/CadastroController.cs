using System.Linq;
using System;
using System.Threading.Tasks;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Alura.ListaLeitura.App.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Controllers
{
    public class CadastroController
    {
        private const string LIVRO_CADASTRADO_COM_SUCESSO = "Livro Cadastrado com Sucesso";

        public static Task CadastroNovoLivro(HttpContext context)
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


        public IActionResult ExibeNovoFormulario()
        {
            //var html = HtmlUtils.CarregaArquivoHTML("incluir");
            //return context.Response.WriteAsync(html);
            var html = new ViewResult { ViewName = "incluir"} ;
            return html;
        }
        public static Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Livro();
            if (context.Request.Method.ToUpper() == "POST")
            {
                livro.Titulo = context.Request.Form["titulo"];
                livro.Autor = context.Request.Form["autor"];
            }
            else 
            {
                livro.Titulo = context.Request.Query["titulo"].First();
                livro.Autor = context.Request.Query["autor"].First();
            }
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return context.Response.WriteAsync(LIVRO_CADASTRADO_COM_SUCESSO);
        }

    }
}