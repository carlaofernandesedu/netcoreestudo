using System.Linq;
using System;
using System.Threading.Tasks;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Alura.ListaLeitura.App.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Controllers
{
    public class LivrosController : Controller 
    {
        public static Task ExibeDetalhes(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(i=> i.Id == Convert.ToInt32(context.GetRouteValue("id")));
            return context.Response.WriteAsync(livro.Detalhes());
        }

        public IActionResult LivrosParaLer()
        {
            var repo = new LivroRepositorioCSV();
            ViewBag.Livros = repo.ParaLer.Livros;
            return View("lista");
        }

        public IActionResult LivrosLidos()
        {
            var repo = new LivroRepositorioCSV();
            ViewBag.Livros = repo.Lidos.Livros;
            return View("lista");

        }

        public IActionResult LivrosLendo()
        {
            var repo = new LivroRepositorioCSV();
            ViewBag.Livros = repo.Lendo.Livros;
            return View("lista");

        }

        public string Teste()
        {
            return "Testes com as rota do MVC";
        }

    }
}
