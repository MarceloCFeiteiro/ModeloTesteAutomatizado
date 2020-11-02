using ModeloTesteAutomatizado.Data;
using ModeloTesteAutomatizado.Pages.PagesMap;
using ModeloTesteAutomatizado.Paginas;
using ModeloTesteAutomatizado.SeleniumUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace ModeloTesteAutomatizado.Pages.PagesCode
{
    /// <summary>
    /// Classe responsável por armazenar os métodos da pagina de login.
    /// </summary>
    public class AuthenticationPage : BasePage
    {
        /// <summary>
        /// Atributo responsável por armazenar uma referência para a classe AuthenticationMap.
        /// </summary>
        private readonly AuthenticationMap authenticationMap = new AuthenticationMap();

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        public AuthenticationPage(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Método responsável por preencher o campo email.
        /// </summary>
        /// <param name="email">Email a ser preenchido</param>
        public void PreencheCampoEmail(string email)
        {
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtEmail, email);
        }

        /// <summary>
        /// Método responsável por preencher o campo email create account.
        /// </summary>
        /// <param name="nome">Nome a ser preenchido</param>
        public void PreencheCampoEmailCreateAccount(string nome)
        {
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtEmailCreateAccount, nome);
        }

        /// <summary>
        /// Método responsável por preencher o Password
        /// </summary>
        /// <param name="password">Senha a ser preenchida.</param>
        public void PreencheCampoPassword(string password)
        {
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtPassword, password);
        }

        /// <summary>
        /// Método responsável por clicar no botão de signin.
        /// </summary>
        public void ClickBtnSign_in()
        {
            SeleniumTools.Clicar(driver, authenticationMap.BtnSignIn);
        }

        /// <summary>
        /// Método responsável por clicar no botão de Create an account.
        /// </summary>
        public void ClickBtnCreateAccount()
        {
            SeleniumTools.Clicar(driver, authenticationMap.BtnCreateAnAccount);
        }

        /// <summary>
        /// Método responsável por clicar no botão de register an account.
        /// </summary>
        public void ClickBtnRegisterAnAccount()
        {
            SeleniumTools.Clicar(driver, authenticationMap.BtnRegister);
        }

        /// <summary>
        /// Método responsável por retornar texto da mensagem.
        /// </summary>
        /// <returns>Retorna a mensagem contida no alerta.</returns>
        public string RetornaTextoDaMensagem()
        {
            return SeleniumTools.RetornaTexto(driver, authenticationMap.Alert);
        }

        /// <summary>
        /// Método responsável por retornar mesagem de campo requirido.
        /// </summary>
        /// <returns>Retorna a mensagem de campo requerido.</returns>
        public string RetornaMensagemCampoRequerido()
        {
            return SeleniumTools.RetornaTexto(driver, authenticationMap.MsnRequiredFild);
        }

        /// <summary>
        /// Método responsável por retornar toda a lista de erros.
        /// </summary>
        /// <returns>Retorna a lista de erros</returns>
        public IList<string> RetornaListadeErros()
        {
            IList<string> listaErros = new List<string>();

            var listaElementos = SeleniumTools.CarregarListaElementos(driver, authenticationMap.Alert);
            foreach (var elemento in listaElementos)
            {
                listaErros.Add(elemento.Text);
            }

            return listaErros;
        }

        /// <summary>
        /// Método responsável por prencher os dados de um cadastro de usuário
        /// </summary>
        public void PreecherDadosUsuario(Usuario usuario)
        {
            PreencherInformacaoPessoal(usuario);
            PreencherEndereco(usuario);
        }

        /// <summary>
        /// Método responsável por preencher as informações referentes ao endereço e contato
        /// </summary>
        /// <param name="usuario"></param>
        private void PreencherEndereco(Usuario usuario)
        {
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtCompanyName, usuario.Empresa);
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtAddress1, usuario.EmpresaEndereco);
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtAddress2, usuario.NomeCompleto);
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtCityAddress, usuario.NomeCompleto);
            SeleniumTools.SelecionarOpcaoCombo(driver, authenticationMap.CmbStateAddress, authenticationMap.TxtPostCodeAddress, usuario.Estado);
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtPostCodeAddress, usuario.Cep);
            SeleniumTools.SelecionarOpcaoCombo(driver, authenticationMap.CmbCountryAddress, authenticationMap.TxtAdditionalInformationAddress, usuario.Pais);
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtAdditionalInformationAddress, usuario.InformacaoAdicional);
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtHomePhoneAddress, usuario.TelefoneComDDD);
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtMobilePhoneAddress, usuario.CelularComDDD);
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtAddressFutureReference, usuario.EnderecoAlternativo);
        }

        /// <summary>
        /// Método responsável por preencher os dados pessoais
        /// </summary>
        /// <param name="usuario">Usuário criado para o cadastro</param>
        private void PreencherInformacaoPessoal(Usuario usuario)
        {
            if (usuario.Sexo.Equals('F'))
                SeleniumTools.Clicar(driver, authenticationMap.RadioMrsCreate);
            else
                SeleniumTools.Clicar(driver, authenticationMap.RadioMrCreate);

            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtFirstNameCreate, usuario.PrimeiroNome);
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtLastNameCreate, usuario.UltimoNome);
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtPassword, usuario.Password);
            PreencherAniversario(usuario.DataAniversario);
        }

        /// <summary>
        /// Método responsável por preencher os campos de data de nascimento
        /// </summary>
        /// <param name="aniversario"></param>
        private void PreencherAniversario(DateTime data)
        {
            SeleniumTools.SelecionarValorCombo(driver, authenticationMap.CmbDayBirthCreate, authenticationMap.TxtCompanyName, data.Day.ToString());
            SeleniumTools.SelecionarValorCombo(driver, authenticationMap.CmbMonthBirthCreate, authenticationMap.TxtCompanyName, data.Month.ToString());
            SeleniumTools.SelecionarValorCombo(driver, authenticationMap.CmbYearBirthCreate, authenticationMap.TxtCompanyName, data.Year.ToString());
        }
    }
}