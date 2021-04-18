using ModeloTesteAutomatizado.Helpers;
using ModeloTesteAutomatizado.Pages.PagesCode;
using ModeloTesteAutomatizado.Resources;
using NUnit.Framework;
using System.Collections.Generic;

namespace ModeloTesteAutomatizado.Tests
{
    public class AuthenticationTest : BaseTeste
    {
        private AuthenticationPage authenticationPage;
        private IndexPage index;

        [SetUp]
        public void Setup()
        {
            authenticationPage = new AuthenticationPage(driver);
            index = new IndexPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (!TestContext.CurrentContext.Test.Name.Contains("Incorretos")
                && !TestContext.CurrentContext.Test.Name.Contains("Mensagem"))
            {
                index.NavegaParaPagina(Resource.UrlPrincipal);
                index.ClickBtnSign_Out();
            }
        }

        [Test]
        [Retry(2)]
        public void AuthenticationPageComUsuarioEPasswordCorretos()
        {
            #region Arranje

            MyAccountPage myAccountPage = new MyAccountPage(driver);

            var User = ManipularArquivoHelper.LerDeUmArquivoQueEstaNoFormatoJson();

            #endregion Arranje

            #region Act

            index.NavegaParaPagina(Resources.Resource.UrlPrincipal);

            index.ClickBtnSign_in();
            authenticationPage.PreencheCampoEmail(User.Email);
            authenticationPage.PreencheCampoPassword(User.Password);
            authenticationPage.ClickBtnSign_in();

            #endregion Act

            #region Assert

            Assert.AreEqual(myAccountPage.RetornaTextoDaMensagem(), "MY ACCOUNT");

            #endregion Assert
        }

        [Test]
        [Retry(2)]
        public void AuthenticationPageComUsuarioEPasswordIncorretos()
        {
            #region Act

            authenticationPage.NavegaParaPagina(Resources.Resource.UrlAuthentication);
            authenticationPage.PreencheCampoEmail("Email@Email.com.br");
            authenticationPage.PreencheCampoPassword("SuperSecretPassword!");
            authenticationPage.ClickBtnSign_in();

            #endregion Act

            #region Assert

            Assert.AreEqual(authenticationPage.RetornaTextoDaMensagem(), "Authentication failed.");

            #endregion Assert
        }

        [Test]
        [Retry(1)]
        public void AuthenticationPageComUsuarioEPasswordIncorretosFail()
        {
            #region Act

            authenticationPage.NavegaParaPagina(Resources.Resource.UrlAuthentication);
            authenticationPage.PreencheCampoEmail("Email@Email.com.br");
            authenticationPage.PreencheCampoPassword("SuperSecretPassword!");
            authenticationPage.ClickBtnSign_in();

            #endregion Act

            #region Assert

            Assert.AreEqual(authenticationPage.RetornaTextoDaMensagem(), "Authentication failed.", "Mensagem com erro para simular uma falha");

            #endregion Assert
        }

        [Test]
        [Retry(2)]
        public void ValidarMensagemNaoInformacaoDosCamposDeCadastro()
        {
            #region Arranje

            var usuario = GerarUsuarioHelper.GerarUsuario();
            var listaErros = new List<string> { "You must register at least one phone number.",
                                                "lastname is required.",
                                                "firstname is required.",
                                                "passwd is required.",
                                                "address1 is required.",
                                                "city is required.",
                                                "The Zip/Postal code you've entered is invalid. It must follow this format: 00000",
                                                "This country requires you to choose a State."};

            #endregion Arranje

            #region Act

            authenticationPage.NavegaParaPagina(Resources.Resource.UrlAuthentication);
            authenticationPage.PreencheCampoEmailCreateAccount(usuario.Email);
            authenticationPage.ClickBtnCreateAccount();
            authenticationPage.ClickBtnRegisterAnAccount();

            #endregion Act

            #region Assert

            Assert.AreEqual(authenticationPage.RetornaMensagemCampoRequerido(), "*Required field", "A mensagem esta diferente do esperado.");
            var listaErrosPagina = authenticationPage.RetornaListadeErros();
            Assert.AreEqual(listaErros, listaErrosPagina);

            #endregion Assert
        }

        [Test]
        [Retry(1)]
        [Order(1)]
        public void ValidarCadastroDeUsuario()
        {
            #region Arranje

            MyAccountPage myAccount = new MyAccountPage(driver);
            var usuario = GerarUsuarioHelper.GerarUsuario();

            #endregion Arranje

            #region Act

            authenticationPage.NavegaParaPagina(Resources.Resource.UrlAuthentication);
            authenticationPage.PreencheCampoEmailCreateAccount(usuario.Email);
            authenticationPage.ClickBtnCreateAccount();
            authenticationPage.PreecherDadosUsuario(usuario);
            authenticationPage.ClickBtnRegisterAnAccount();

            #endregion Act

            #region Assert

            Assert.AreEqual(myAccount.RetornaTextoDaMensagem(), "MY ACCOUNT", "Não foi encontrado o texto referente a pagina My account");
            Assert.AreEqual(myAccount.RetornaNomeDoUsuarioDaPagina(), usuario.NomeCompleto, "O nome do usuário esta diferente do esperado");

            #endregion Assert

            #region Finalization

            ManipularArquivoHelper.SalvarNoArquivoEmFormatoJson(usuario);

            #endregion Finalization
        }
    }
}