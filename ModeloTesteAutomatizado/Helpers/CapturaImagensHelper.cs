using OpenQA.Selenium;
using System;
using System.IO;

namespace ModeloTesteAutomatizado.Helpers
{
    /// <summary>
    /// Classe estática responsável por manipular eventos de captura de prints.
    /// </summary>
    public static class CapturaImagensHelper
    {
        private static readonly string dir = "C:";
        private static readonly string nomePasta = "\\Imagens_capturadas\\";

        /// <summary>
        /// Método responsável por captturar um print da tela atual.
        /// </summary>
        /// <param name="driver">Driver atual</param>
        /// <param name="screenShotName">Nome do screenshot</param>
        /// <returns>Retorna uma string com o caminho da pasta onde sera salva a captura</returns>
        public static string CapturaPrintTela(IWebDriver driver, string screenShotName)
        {
            string localpath;
            try
            {
                Screenshot screenshot = Captura(driver);
                DirectoryInfo di = Directory.CreateDirectory(dir + nomePasta + DateTime.Now.ToString("MM-yy"));
                string finalpth = di.FullName + "\\" + screenShotName + DateTime.Now.ToString("hh-mm-ss") + ".png";
                localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível salvar a imagem" + e.Message);
            }
            return localpath;
        }

        /// <summary>
        /// Método que captura a tela.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns>Retorna uma instancia da captura da tela</returns>
        private static Screenshot Captura(IWebDriver driver)
        {
            ITakesScreenshot ts = driver as ITakesScreenshot;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot;
        }
    }
}