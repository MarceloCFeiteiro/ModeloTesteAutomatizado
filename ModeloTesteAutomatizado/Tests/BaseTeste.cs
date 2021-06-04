using ModeloTesteAutomatizado.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

            System.Console.WriteLine("Antes de todos as classes de teste " + TestContext.CurrentContext.Test.FullName   );
        }

        [SetUp]
        public void Inicializar()
        {
            CriaRelatorioHelper.CriaTeste();
            System.Console.WriteLine("Antes  de teste " + TestContext.CurrentContext.Test.FullName);
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