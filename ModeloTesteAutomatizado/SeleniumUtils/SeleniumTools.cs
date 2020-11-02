using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace ModeloTesteAutomatizado.SeleniumUtils
{
    /// <summary>
    /// Classe responsável por armazenar os métodos de comunicação com os elemenos da página.
    /// </summary>
    public static class SeleniumTools
    {
        private const int tempoDeEspera = 5;
        private static WebDriverWait espera = null;

        /// <summary>
        /// Método responsável por clicar em um elemento através de um action.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento a ser clicado.</param>
        public static void ClicarAction(IWebDriver webDriver, By referencia)
        {
            var action = CriarAction(webDriver);

            var elementoCarregado = EsperaElementoFicarClicavel(webDriver, referencia);

            action.Click(elementoCarregado);
        }

        /// <summary>
        /// Método responsável por clicar em um elemento.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento a ser clicado.</param>
        public static void Clicar(IWebDriver webDriver, By referencia)
        {
            var elementoCarregado = EsperaElementoFicarClicavel(webDriver, referencia);
            elementoCarregado.Click();
        }

        /// <summary>
        /// Método responsável por clicar em um elemento.
        /// </summary>
        /// <param name="referencia">Elemento a ser clicado.</param>
        public static void Clicar(IWebElement elemento)
        {
            elemento.Click();
        }

        /// <summary>
        /// Método responsável por retornar uma lista de elementos.
        /// </summary>
        /// <param name="webDriver">Driver atual</param>
        /// <param name="referencia">Referência dos elementos</param>
        public static IEnumerable<IWebElement> CarregarListaElementos(IWebDriver webDriver, By referencia)
        {
            EsperaElementoFicarClicavel(webDriver, referencia);

            return webDriver.FindElements(referencia);
        }

        /// <summary>
        /// Método responsável por enviar um texto para o elemento.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento para onde o texto será enviado.</param>
        /// <param name="texto">Texto a ser inserido.</param>
        public static void EnviarTexto(IWebDriver webDriver, By referencia, string texto)
        {
            var elementoCarregado = EsperaElementoFicarClicavel(webDriver, referencia);

            if (!string.IsNullOrEmpty(elementoCarregado.GetAttribute("value")))
                LimparAtributoValueCampoInput(elementoCarregado);

            elementoCarregado.SendKeys(texto);
        }

        /// <summary>
        /// Método responsável por enviar um texto para o elemento através de um action.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento para onde o texto será enviado.</param>
        /// <param name="texto">Texto a ser inserido.</param>
        public static void EnviarTextoAction(IWebDriver webDriver, By referencia, string texto)
        {
            var action = CriarAction(webDriver);
            var elementoCarregado = EsperaElementoFicarClicavel(webDriver, referencia);
            action.SendKeys(elementoCarregado, texto);
        }

        /// <summary>
        /// Método responsável por marcar uma checkbox.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento para onde o texto será enviado.</param>
        /// <param name="marcar">/////////////////</param>
        public static void MarcaCheckBox(IWebDriver webDriver, By referencia, bool marcar = true)
        {
            EsperaElementoChkBoxEstarMarcado(webDriver, referencia, false);

            var elementoCarregado = EsperaElementoExistir(webDriver, referencia);

            Clicar(elementoCarregado);

            EsperaElementoChkBoxEstarMarcado(webDriver, referencia, marcar);
        }

        /// <summary>
        /// Método responsável por mover o cursor até um elemento.
        /// </summary>
        /// <param name="webDriver">Driver</param>
        /// <param name="referencia">Referência do elemento para o qual se quer mover.</param>
        public static void MoverAteElemento(IWebDriver webDriver, By referencia)
        {
            var action = CriarAction(webDriver);
            var elementoCarregado = EsperaElementoFicarClicavel(webDriver, referencia);
            action.MoveToElement(elementoCarregado);
        }

        /// <summary>
        /// Método responsável por mover o cursor até um elemento.
        /// </summary>
        /// <param name="webDriver">Driver</param>
        /// <param name="elemento">Elemento para o qual se quer mover.</param>
        public static void MoverAteElemento(IWebDriver webDriver, IWebElement elemento)
        {
            var action = CriarAction(webDriver);
            action.MoveToElement(elemento).Perform();
        }

        /// <summary>
        /// Método responsável por pegar um elemento que esta dentro de outro elemento.
        /// </summary>
        /// <param name="elemento">Eelemento pai</param>
        /// <param name="referencia">Referência do elemento que se quer encontar.</param>
        /// <returns></returns>
        public static IWebElement PegarElemento(IWebElement elemento, By referencia)
        {
            var elementoEncontrado = elemento.FindElement(referencia);

            return elementoEncontrado;
        }

        /// <summary>
        /// Método responsável por retornar o texto de um elemento.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento</param>
        /// <returns>Retorna o texto contido no atributo Text do elemento.</returns>
        public static string RetornaTexto(IWebDriver webDriver, By referencia)
        {
            var elementoCarregado = EsperaElementoExistir(webDriver, referencia);
            return elementoCarregado.Text;
        }

        /// <summary>
        /// Método responsável por selecinar um valor na combo.
        /// </summary>
        /// <param name="webDriver">Driver atual</param>
        /// <param name="referencia">Referência do elemento</param>
        /// <param name="valor">Valor a ser selecionado</param>
        public static void SelecionarValorCombo(IWebDriver webDriver, By referencia, string valor)
        {
            var elementoCarregado = EsperaElementoFicarClicavel(webDriver, referencia);
            var seletor = new SelectElement(elementoCarregado);
            seletor.SelectByValue(valor);
        }

        /// <summary>
        /// Método responsável por selecinar um valor na combo com uma espera adicional.
        /// Usado quando o combo não estiver clicável ou estiver escondido.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento.</param>
        /// <param name="campoDeEspera">Valor a ser passado para uma espera de carregamento, passar um campo clicável que esteja perto da combo.</param>
        ///  /// <param name="valor">Valor a ser selecionado no campo baseado no campo value da combo.</param>
        public static void SelecionarValorCombo(IWebDriver webDriver, By referencia, By referenciaCampoDeEspera, string valor)
        {
            EsperaElementoFicarClicavel(webDriver, referenciaCampoDeEspera);
            var elementoCarregado = EsperaElementoExistir(webDriver, referencia);
            var seletor = new SelectElement(elementoCarregado);
            seletor.SelectByValue(valor);
        }

        /// <summary>
        /// Método responsável por selecinar um valor na combo com uma espera adicional.
        /// Usado quando o combo não estiver clicável ou estiver escondido.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento.</param>
        /// <param name="campoDeEspera">Valor a ser passado para uma espera de carregamento, passar um campo clicável que esteja perto da combo.</param>
        /// <param name="opcao">Valor a ser selecionado no campo baseado no campo value da combo.</param>
        public static void SelecionarOpcaoCombo(IWebDriver webDriver, By referencia, By referenciaCampoDeEspera, string opcao)
        {
            EsperaElementoFicarClicavel(webDriver, referenciaCampoDeEspera);
            var elementoCarregado = EsperaElementoExistir(webDriver, referencia);
            var seletor = new SelectElement(elementoCarregado);
            seletor.SelectByText(opcao);
        }

        #region Privados

        /// <summary>
        /// Método responsável por criar uma nova Action
        /// </summary>
        /// <param name="webDriver">Driver atual</param>
        /// <returns>Retorna uma nova Actions</returns>
        private static Actions CriarAction(IWebDriver webDriver)
        {
            return new Actions(webDriver);
        }

        /// <summary>
        /// Método responsávelpor esperar um elemento existir na página.
        /// </summary>
        /// <param name="webDriver">Diver atual.</param>
        /// <param name="referencia">Referência do elemento.</param>
        /// <returns>Retorna um elemento que já existe na página.</returns>
        private static IWebElement EsperaElementoExistir(IWebDriver webDriver, By referencia)
        {
            espera = new WebDriverWait(webDriver, TimeSpan.FromSeconds(tempoDeEspera));
            return espera.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(referencia));
        }

        /// <summary>
        /// Método responsável por esperar a checkBox estar marcada.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento.</param>
        /// <returns></returns>
        private static bool EsperaElementoChkBoxEstarMarcado(IWebDriver webDriver, By referencia, bool marcar = true)
        {
            espera = new WebDriverWait(webDriver, TimeSpan.FromSeconds(tempoDeEspera));
            EsperaElementoExistir(webDriver, referencia);
            return espera.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementSelectionStateToBe(referencia, marcar));
        }

        /// <summary>
        /// Método responsável por esperar elemento ficar clicável.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento.</param>
        /// <returns>Retorna um elemento que pode ser clicado.</returns>
        private static IWebElement EsperaElementoFicarClicavel(IWebDriver webDriver, By referencia)
        {
            espera = new WebDriverWait(webDriver, TimeSpan.FromSeconds(tempoDeEspera));
            return espera.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(referencia));
        }

        /// <summary>
        /// Método responsável por limpar o atributo value de um campo input.
        /// </summary>
        /// <param name="elementoCarregado"></param>
        private static void LimparAtributoValueCampoInput(IWebElement elementoCarregado)
        {
            elementoCarregado.Clear();
        }

        #endregion Privados
    }
}