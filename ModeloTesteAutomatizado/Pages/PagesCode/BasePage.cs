using OpenQA.Selenium;
using System;

namespace ModeloTesteAutomatizado.Paginas
{
    /// <summary>
    /// Classe base para todas as páginas
    /// </summary>
    public class BasePage
    {
        public IWebDriver driver;
        private const int tempoDeEspera = 30;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Método responsável por maximizar a tela e navegar para a url especificada.
        /// </summary>
        /// <param name="url">URL que será aberta</param>
        public void NavegaParaPagina(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(tempoDeEspera);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(tempoDeEspera);
        }
    }
}