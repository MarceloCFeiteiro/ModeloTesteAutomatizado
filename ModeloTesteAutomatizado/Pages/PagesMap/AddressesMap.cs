using OpenQA.Selenium;

namespace ModeloTesteAutomatizado.Pages.PagesMap
{
    /// <summary>
    /// Classe responsável por armazenar os elementos da página de login.
    /// </summary>
    public class AddressesMap
    {
        ///// <summary>Define o campo proceed to checkout.</summary>
        public readonly By ButtonProceedToCheckout = By.CssSelector("button[name='processAddress']");
    }
}