using OpenQA.Selenium;

namespace ModeloTesteAutomatizado.Pages.PagesMap
{
    /// <summary>
    /// Classe responsável por armazenar os elementos da página ShoppingCartSummaryMap.
    /// </summary>
    public class ShoppingCartSummaryMap
    {
        ///// <summary>Define o campo proceed to checkout.</summary>
        public readonly By ButtonProceedToCheckout = By.CssSelector("p>a[title='Proceed to checkout']>span");
    }
}