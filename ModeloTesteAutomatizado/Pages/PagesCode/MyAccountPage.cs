using ModeloTesteAutomatizado.Pages.PagesMap;
using ModeloTesteAutomatizado.Paginas;
using ModeloTesteAutomatizado.SeleniumUtils;
using OpenQA.Selenium;

namespace ModeloTesteAutomatizado.Pages.PagesCode
{
    /// <summary>
    /// Classe responsável por armazenar os métodos da pagina My account.
    /// </summary>
    public class MyAccountPage : BasePage
    {
        /// <summary>
        /// Atributo responsável por armazenar uma referência para a classe MyAccountMap.
        /// </summary>
        private readonly MyAccountMap myAccountMap = new MyAccountMap();

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Método responsável por retornar o texto da mensagem.
        /// </summary>
        /// <returns>Retorna a mensagem contida no alerta.</returns>
        public string RetornaTextoDaMensagem()
        {
            return SeleniumTools.RetornaTexto(driver, myAccountMap.TextMyAccount);
        }

        /// <summary>
        /// Método responsável por retornar o mome do usuário da conta que aparece na página.
        /// </summary>
        /// <returns>Retorna a mensagem contida na informação do user.</returns>
        public string RetornaNomeDoUsuarioDaPagina()
        {
            return SeleniumTools.RetornaTexto(driver, myAccountMap.TextUserName);
        }
    }
}