using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(Rotear);
        }

        //public Task LivrosParaLer(HttpContext context)
        //{
        //    var repo = new LivroRepositorioCSV();
        //    return context.Response.WriteAsync(repo.ParaLer.ToString());
        //}

        

        public Task Rotear(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();

            var caminhosAtendidos = new Dictionary<string,string>
             {
                { "/Livros/ParaLer",repo.ParaLer.ToString()},
                { "/Livros/Lendo",repo.Lendo.ToString()},
                { "/Livros/Lidos",repo.Lidos.ToString()}
            };

            var retorno = "Caminho Inexistente";
            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                retorno = caminhosAtendidos[context.Request.Path];
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }

            return context.Response.WriteAsync(retorno);
        }
    }
}