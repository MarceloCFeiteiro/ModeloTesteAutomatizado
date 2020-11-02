using ModeloTesteAutomatizado.Pages.PagesMap;
using ModeloTesteAutomatizado.Paginas;
using ModeloTesteAutomatizado.SeleniumUtils;
using OpenQA.Selenium;

namespace ModeloTesteAutomatizado.Pages.PagesCode
{
    /// <summary>
    /// Classe responsável por armazenar os métodos da página de pagamento.
    /// </summary>
    public class PaymentPage : BasePage
    {
        private readonly PaymentMap paymentMap = new PaymentMap();

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        public PaymentPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Método responsável por confirmar a ordem de pagamento.
        /// </summary>
        public void ConfirmarOrdem()
        {
            SeleniumTools.Clicar(driver, paymentMap.ButtonConfirmOrder);
        }

        /// <summary>
        /// Método responsável por escolher o tipo de pagamento.
        /// </summary>
        public void EscolherTipoDePagamento()
        {
            SeleniumTools.Clicar(driver, paymentMap.PayBybankWire);
        }

        /// <summary>
        /// Método responsável por retornar o texto da mensagem.
        /// </summary>
        /// <returns>Retorna a mensagem contida no elemento.</returns>
        public string RetornaTextoDaMensagem()
        {
            return SeleniumTools.RetornaTexto(driver, paymentMap.TxtConfirmationOrder);
        }
    }
}