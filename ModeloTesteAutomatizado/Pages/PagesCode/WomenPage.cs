using ModeloTesteAutomatizado.Pages.PagesMap;
using ModeloTesteAutomatizado.Paginas;
using ModeloTesteAutomatizado.SeleniumUtils;
using OpenQA.Selenium;
using System.Linq;

namespace ModeloTesteAutomatizado.Pages.PagesCode
{
    /// <summary>
    /// Classe responsável por armazenar os métodos da página women.
    /// </summary>
    public class WomenPage : BasePage
    {
        /// <summary>
        /// Atributo responsável por armazenar uma referência para a classe womenMap.
        /// </summary>
        private readonly WomenMap womenMap = new WomenMap();

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        public WomenPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Método responsável por navegar até a página women.
        /// </summary>
        public void NavegaParaAPaginaWomen()
        {
            SeleniumTools.Clicar(driver, womenMap.LinkWomen); ;
        }

        public void ColocarItemCarrinho()
        {
            var listaRoupas = SeleniumTools.CarregarListaElementos(driver, womenMap.ListClothes);

            SeleniumTools.MoverAteElemento(driver, listaRoupas.FirstOrDefault());
            var BotaoAddCart = SeleniumTools.PegarElemento(listaRoupas.FirstOrDefault(), womenMap.ButtonAddToCart);
            SeleniumTools.Clicar(BotaoAddCart);
            SeleniumTools.Clicar(driver, womenMap.ButtonProceedToCheckout);
        }
    }
}