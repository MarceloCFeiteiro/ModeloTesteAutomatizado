using ModeloTesteAutomatizado.Data;
using System;
using System.IO;

namespace ModeloTesteAutomatizado.Helpers
{
    public static class ManipularArquivoHelper
    {

        /// <summary>
        /// Representa o caminho para o arquivo;
        /// </summary>
        private static readonly string Caminho = CriaCaminho();

        /// <summary>
        /// Representa o nome do arquivo
        /// </summary>
        private static readonly string NomeArquivo = @"Usuario.json";

        /// <summary>
        /// Método responsável por salvar um registro no arquivo em formato json.
        /// </summary>
        /// <param name="obj">Entidade a ser salva</param>
        public static void SalvarNoArquivoEmFormatoJson(Usuario obj)
        {
            string texto = ConversorJsonHelper<Usuario>.EntidadeParaJson(obj);
            
            File.WriteAllText(string.Concat(Caminho, NomeArquivo), texto);
        }

        /// <summary>
        /// Métoro responsável por retornar um objeto dinâmico com os dados do arquivo.
        /// </summary>
        /// <returns>Retorna um tipo dinâmico com os valores de um json</returns>
        public static Usuario LerDeUmArquivoQueEstaNoFormatoJson()
        {
            string texto = File.ReadAllText(string.Concat(Caminho, NomeArquivo));

            return ConversorJsonHelper<Usuario>.JsonParaEntidade(texto);
        }

        private static string CriaCaminho()
        {
            var caminho = Environment.CurrentDirectory; ;

            var temp = caminho.Split('\\');

            var path = string.Empty;

            foreach (var item in temp)
            {
                if (item.Equals("bin"))
                {
                    path = path[1..];
                    break;
                }
                path = string.Concat(path, "\\", item);
            } 



            return path + @"\Data\Files\";
        }
    }
}