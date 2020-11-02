using OpenQA.Selenium;

namespace ModeloTesteAutomatizado.Pages.PagesMap
{
    /// <summary>
    /// Classe responsável por armazenar os elementos da página My account.
    /// </summary>
    public class MyAccountMap
    {
        /// <summary>Define o campo cabeçalho My Account.</summary>
        public readonly By TextMyAccount = By.CssSelector("#center_column>h1");

        /// <summary>Define o campo Nome do usuário na página My Account.</summary>
        public readonly By TextUserName = By.CssSelector("div.header_user_info>a>span");
    }
}