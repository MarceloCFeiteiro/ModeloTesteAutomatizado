using OpenQA.Selenium;

namespace ModeloTesteAutomatizado.Pages.PagesMap
{
    /// <summary>
    /// Classe responsável por armazenar os elementos da página de pagamento.
    /// </summary>
    public class PaymentMap
    {
        /// <summary>Define o campo ButtonConfirmOrder.</summary>
        public readonly By ButtonConfirmOrder = By.CssSelector("p.cart_navigation>button");

        /// <summary>Define o campo PayBybankWire.</summary>
        public readonly By PayBybankWire = By.ClassName("bankwire");

        /// <summary>Define o campo TxtConfirmationOrder.</summary>
        public readonly By TxtConfirmationOrder = By.CssSelector("#center_column>h1");
    }
}