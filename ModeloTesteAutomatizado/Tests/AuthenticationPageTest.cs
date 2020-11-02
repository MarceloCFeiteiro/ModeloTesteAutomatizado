using ModeloTesteAutomatizado.Helpers;
using ModeloTesteAutomatizado.Pages.PagesCode;
using NUnit.Framework;
using System.Collections.Generic;

namespace ModeloTesteAutomatizado.Tests
{
    public class AuthenticationTest : BaseTeste
    {
        [Test]
        [Retry(2)]
        public void LoginComUsuarioEPasswordCorretos()
        {
            #region Arranje

            IndexPage index = new IndexPage(driver);
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            AuthenticationPage login = new AuthenticationPage(driver);

            var User = ManipularArquivoHelper.LerDeUmArquivoQueEstaNoFormatoJson();

            #endregion Arranje

            #region Act

            index.NavegaParaPagina(Resources.Resource.UrlPrincipal);

            index.ClickBtnSign_in();
            login.PreencheCampoEmail(User.Email);
            login.PreencheCampoPassword(User.Password);
            login.ClickBtnSign_in();

            #endregion Act

            #region Assert

            Assert.AreEqual(myAccountPage.RetornaTextoDaMensagem(), "MY ACCOUNT");

            #endregion Assert

            #region Finalization

            index.ClickBtnSign_Out();

            #endregion Finalization
        }

        [Test]
        [Retry(2)]
        public void LoginComUsuarioEPasswordIncorretos()
        {
            #region Arranje

            AuthenticationPage login = new AuthenticationPage(driver);

            #endregion Arranje

            #region Act

            login.NavegaParaPagina(Resources.Resource.UrlAuthentication);
            login.PreencheCampoEmail("Email@Email.com.br");
            login.PreencheCampoPassword("SuperSecretPassword!");
            login.ClickBtnSign_in();

            #endregion Act

            #region Assert

            Assert.AreEqual(login.RetornaTextoDaMensagem(), "Authentication failed.");

            #endregion Assert
        }

        [Test]
        [Retry(1)]
        public void LoginComUsuarioEPasswordIncorretosFail()
        {
            #region Arranje

            AuthenticationPage login = new AuthenticationPage(driver);

            #endregion Arranje

            #region Act

            login.NavegaParaPagina(Resources.Resource.UrlAuthentication);
            login.PreencheCampoEmail("Email@Email.com.br");
            login.PreencheCampoPassword("SuperSecretPassword!");
            login.ClickBtnSign_in();

            #endregion Act

            #region Assert

            Assert.AreEqual(login.RetornaTextoDaMensagem(), "Authentication failed.", "Mensagem com erro para simular uma falha");

            #endregion Assert
        }

        [Test]
        [Retry(2)]
        public void ValidarMensagemNaoInformacaoDosCamposDeCadastro()
        {
            #region Arranje

            AuthenticationPage login = new AuthenticationPage(driver);
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

            login.NavegaParaPagina(Resources.Resource.UrlAuthentication);
            login.PreencheCampoEmailCreateAccount(usuario.Email);
            login.ClickBtnCreateAccount();
            login.ClickBtnRegisterAnAccount();

            #endregion Act

            #region Assert

            Assert.AreEqual(login.RetornaMensagemCampoRequerido(), "*Required field", "A mensagem esta diferente do esperado.");
            var listaErrosPagina = login.RetornaListadeErros();
            Assert.AreEqual(listaErros, listaErrosPagina);

            //for (int i = 0; i < listaErros.Count; i++)
            //{
            //    listaErros[i].Equals(listaErrosPagina[i]);
            //}

            #endregion Assert
        }

        [Test]
        [Retry(1)]
        public void ValidarCadastroDeUsuario()
        {
            #region Arranje

            AuthenticationPage login = new AuthenticationPage(driver);
            MyAccountPage myAccount = new MyAccountPage(driver);
            var usuario = GerarUsuarioHelper.GerarUsuario();

            #endregion Arranje

            #region Act

            login.NavegaParaPagina(Resources.Resource.UrlAuthentication);
            login.PreencheCampoEmailCreateAccount(usuario.Email);
            login.ClickBtnCreateAccount();
            login.PreecherDadosUsuario(usuario);
            login.ClickBtnRegisterAnAccount();

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