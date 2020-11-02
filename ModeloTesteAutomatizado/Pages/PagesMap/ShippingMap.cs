using OpenQA.Selenium;

namespace ModeloTesteAutomatizado.Pages.PagesMap
{
    /// <summary>
    /// Classe responsável por armazenar os elementos da página de Shipping.
    /// </summary>
    public class ShippingMap
    {
        ///// <summary>Define o campo proceed to checkout.</summary>
        public readonly By ButtonProceedToCheckout = By.CssSelector("button[name='processCarrier']");

        ///// <summary>Define o campo Terms of service.</summary>
        public readonly By ChkTermsOfService = By.Id("cgv");
    }
}