using ModeloTesteAutomatizado.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ModeloTesteAutomatizado.Tests
{
    /// <summary>
    /// Classe base para todos os teste.
    /// </summary>
    public class BaseTeste
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void InicializaClasse()
        {
            CriaRelatorioHelper.CriaRelatorio(this.GetType().Name);

            driver = WebDriverFactory.CreateWebDriver(WebDriverEnum.HeadlessChrome);
        }

        [SetUp]
        public void Inicializar()
        {
            CriaRelatorioHelper.CriaTeste();
        }

        [TearDown]
        public void Finalizar()
        {
            CriaRelatorioHelper.FinalizaRelatorio(driver);
        }

        [OneTimeTearDown]
        public void FinalizaClasse()
        {
            CriaRelatorioHelper.GravaNoRelatorio();
            driver.Quit();
        }
    }
}