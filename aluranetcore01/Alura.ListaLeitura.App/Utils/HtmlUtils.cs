using System.IO;

namespace Alura.ListaLeitura.App.Utils
{
    public static class HtmlUtils
    {
       public static string CarregaArquivoHTML(string nomeArquivo)
        {
            nomeArquivo = nomeArquivo + ".html";
            var caminhoArquivo = Path.Combine("html",nomeArquivo);
            using( var arquivo = File.OpenText(caminhoArquivo))
            {
                    return arquivo.ReadToEnd();
            };
        }

    }
}