using ModeloTesteAutomatizado.Helpers;
using ModeloTesteAutomatizado.Pages.PagesCode;
using NUnit.Framework;

namespace ModeloTesteAutomatizado.Tests
{
    public class WomenPageTest : BaseTeste
    {
        //[SetUp]
        //public void Inicializar()
        //{
        //    CriaRelatorioHelper.CriaTeste();
        //}

        //[TearDown]
        //public void Finalizar()
        //{
        //    CriaRelatorioHelper.FinalizaRelatorio(driver);
        //}

        [Test]
        [Retry(2)]
        public void AdicionarItemNoCarrinho()
        {
            #region Arranje

            IndexPage index = new IndexPage(driver);
            AuthenticationPage login = new AuthenticationPage(driver);
            WomenPage womenPage = new WomenPage(driver);
            ShoppingCartSummaryPage shoppingCartSummaryPage = new ShoppingCartSummaryPage(driver);
            AddressesPage addressesPage = new AddressesPage(driver);
            ShippingPage shippingPage = new ShippingPage(driver);
            PaymentPage paymentPage = new PaymentPage(driver);

            var User = ManipularArquivoHelper.LerDeUmArquivoQueEstaNoFormatoJson();

            #endregion Arranje

            #region Act

            index.NavegaParaPagina(Resources.Resource.UrlPrincipal);
            index.ClickBtnSign_in();

            login.PreencheCampoEmail(User.Email);
            login.PreencheCampoPassword(User.Password);
            login.ClickBtnSign_in();

            womenPage.NavegaParaAPaginaWomen();
            womenPage.ColocarItemCarrinho();

            shoppingCartSummaryPage.ContinuarCheckout();

            addressesPage.ContinuarCheckout();

            shippingPage.ContinuarCheckout();

            paymentPage.EscolherTipoDePagamento();
            paymentPage.ConfirmarOrdem();

            #endregion Act

            #region Assert

            Assert.AreEqual(paymentPage.RetornaTextoDaMensagem(), "ORDER CONFIRMATION");

            #endregion Assert

            #region Finalization

            index.ClickBtnSign_Out();

            #endregion Finalization
        }
    }
}