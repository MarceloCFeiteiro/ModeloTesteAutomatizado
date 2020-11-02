using ModeloTesteAutomatizado.Pages.PagesMap;
using ModeloTesteAutomatizado.Paginas;
using ModeloTesteAutomatizado.SeleniumUtils;
using OpenQA.Selenium;

namespace ModeloTesteAutomatizado.Pages.PagesCode
{
    /// <summary>
    /// Classe responsável por armazenar os métodos da pagina Index.
    /// </summary>
    public class IndexPage : BasePage
    {
        /// <summary>
        /// Atributo responsável por armazenar uma referência para a classe IndexMap.
        /// </summary>
        private readonly IndexMap indexMap = new IndexMap();

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        public IndexPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Método responsável por clicar no botão de signin.
        /// </summary>
        public void ClickBtnSign_in()
        {
            SeleniumTools.Clicar(driver, indexMap.BtnSignIn);
        }

        /// <summary>
        /// Método responsável por clicar no botão de signout.
        /// </summary>
        public void ClickBtnSign_Out()
        {
            SeleniumTools.Clicar(driver, indexMap.BtnSignOut);
        }
    }
}