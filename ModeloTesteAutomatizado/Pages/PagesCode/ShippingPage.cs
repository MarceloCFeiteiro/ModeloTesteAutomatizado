using ModeloTesteAutomatizado.Pages.PagesMap;
using ModeloTesteAutomatizado.Paginas;
using ModeloTesteAutomatizado.SeleniumUtils;
using OpenQA.Selenium;

namespace ModeloTesteAutomatizado.Pages.PagesCode
{
    /// <summary>
    /// Classe responsável por armazenar os métodos da página ShippingPage.
    /// </summary>
    public class ShippingPage : BasePage
    {
        /// <summary>
        /// Atributo responsável por armazenar uma referência para a classe ShippingMap.
        /// </summary>
        private readonly ShippingMap shippingMap = new ShippingMap();

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="driver"></param>
        public ShippingPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Método responsável por continuar para o checkout
        /// </summary>
        /// <param name="webDriver"></param>
        public void ContinuarCheckout()
        {
            MarcarCheckboxTermosDeServico();
            SeleniumTools.Clicar(driver, shippingMap.ButtonProceedToCheckout);
        }

        /// <summary>
        /// Método resposável por marcar a checkbox de termos de licença
        /// </summary>
        /// <param name="webDriver"></param>
        private void MarcarCheckboxTermosDeServico()
        {
            SeleniumTools.MarcaCheckBox(driver, shippingMap.ChkTermsOfService);
        }
    }
}