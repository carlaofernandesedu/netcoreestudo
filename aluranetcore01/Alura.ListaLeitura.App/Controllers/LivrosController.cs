using System.Linq;
using System;
using System.Threading.Tasks;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Alura.ListaLeitura.App.HTML;

namespace Alura.ListaLeitura.App.Controllers
{
    public class LivrosController
    {
        public static Task ExibeDetalhes(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(i=> i.Id == Convert.ToInt32(context.GetRouteValue("id")));
            return context.Response.WriteAsync(livro.Detalhes());
        }

        public static Task LivrosParaLer(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();
            var content = HtmlUtils.CarregaArquivoHTML("paraler");
            foreach (var item in repo.ParaLer.Livros)
            {
              content = content.Replace("#NOVOITEM",$"<li>{item.Titulo} - {item.Autor}</li>#NOVOITEM");
            }
            content = content.Replace("#NOVOITEM","");
            return context.Response.WriteAsync(content);
        }

        public static Task LivrosLidos(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repo.Lidos.ToString());
        }

        public static Task LivrosLendo(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repo.Lendo.ToString());
        }

        public string Teste()
        {
            return "Testes com as rota do MVC";
        }

    }
}
