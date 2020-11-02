using OpenQA.Selenium;

namespace ModeloTesteAutomatizado.Pages.PagesMap
{
    /// <summary>
    /// Classe responsável por armazenar os elementos da página Index.
    /// </summary>
    public class IndexMap
    {
        /// <summary>Define o campo botão SignIn.</summary>
        public readonly By BtnSignIn = By.CssSelector("a[title = 'Log in to your customer account']");

        /// <summary>Define o campo botão SignOut.</summary>
        public readonly By BtnSignOut = By.CssSelector("a[title = 'Log me out']");
    }
}