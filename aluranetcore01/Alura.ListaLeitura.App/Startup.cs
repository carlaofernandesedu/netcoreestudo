using Alura.ListaLeitura.App.Logica;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        public void Configure(IApplicationBuilder app)
        {
            //Mapeamento ASP.NET CORE
            var roteamento = new RouteBuilder(app);
            roteamento.MapRoute("Livros/ParaLer",LivrosLogica.LivrosParaLer);
            roteamento.MapRoute("Livros/Lidos",LivrosLogica.LivrosLidos);
            roteamento.MapRoute("Livros/Lendo",LivrosLogica.LivrosLendo);
            roteamento.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.ExibeDetalhes);
            roteamento.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.CadastroNovoLivro);
            roteamento.MapRoute("Cadastro/NovoLivro",CadastroLogica.ExibeNovoFormulario);
            roteamento.MapRoute("Cadastro/Incluir", CadastroLogica.ProcessaFormulario);
            var rotas = roteamento.Build();
            app.UseRouter(rotas);

            //app.Run(RotearManual);
        }

   
        //private const string CAMINHO_INEXISTENTE = "Caminho Inexistente";

 
        // public Task RotearManual(HttpContext context)
        // {
        //     var repo = new LivroRepositorioCSV();

        //     var caminhosAtendidos = new Dictionary<string,RequestDelegate>
        //      {
        //         { "/Livros/ParaLer",LivrosParaLer},
        //         { "/Livros/Lendo",LivrosLendo},
        //         { "/Livros/Lidos",LivrosLidos}
        //     };

            
        //     if (caminhosAtendidos.ContainsKey(context.Request.Path))
        //     {
        //         var metodo = caminhosAtendidos[context.Request.Path];
        //         return metodo.Invoke(context);
        //     }
        //     else
        //     {
        //         context.Response.StatusCode = StatusCodes.Status404NotFound;
        //         return context.Response.WriteAsync(CAMINHO_INEXISTENTE);
        //     }
        // }
    }
}