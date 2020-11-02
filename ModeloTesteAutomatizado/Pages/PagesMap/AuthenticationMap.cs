using OpenQA.Selenium;

namespace ModeloTesteAutomatizado.Pages.PagesMap
{
    /// <summary>
    /// Classe responsável por armazenar os elementos da página de login.
    /// </summary>
    public class AuthenticationMap
    {
        #region AUTHENTICATION

        #region ALREADY REGISTERED?

        /// <summary>Define o campo Email.</summary>
        public readonly By TxtEmail = By.Id("email");

        /// <summary>Define o campo Password.</summary>
        public readonly By TxtPassword = By.Id("passwd");

        /// <summary>Define o botão Sign in.</summary>
        public readonly By BtnSignIn = By.Id("SubmitLogin");

        /// <summary>Define o campo de recuperação de senha.</summary>
        public readonly By LinkForgotPassword = By.LinkText("Recover your forgotten password");

        #endregion ALREADY REGISTERED?

        #region CREATE AN ACCOUNT

        /// <summary>Define o campo de Alerta.</summary>
        public readonly By Alert = By.CssSelector(".alert > ol > li");

        /// <summary>Define o campo email da create account.</summary>
        public readonly By TxtEmailCreateAccount = By.Id("email_create");

        /// <summary>Define o botão create an account.</summary>
        public readonly By BtnCreateAnAccount = By.Id("SubmitCreate");

        #endregion CREATE AN ACCOUNT

        #endregion AUTHENTICATION

        #region AUTHENTICATION CREATE AN ACCOUNT.

        #region YOUR PERSONAL INFORMATION

        /// <summary>Define o campo genero masculino na criação.</summary>
        public By RadioMrCreate = By.Id("id_gender1");

        /// <summary>Define o campo genero feminino criação.</summary>
        public By RadioMrsCreate = By.Id("id_gender2");

        /// <summary>Define o campo FirstName criação.</summary>
        public readonly By TxtFirstNameCreate = By.Id("customer_firstname");

        /// <summary>Define o campo LastName criação.</summary>
        public readonly By TxtLastNameCreate = By.Id("customer_lastname");

        /// <summary>Define o campo Password criação.</summary>
        public readonly By TxtPasswordCreate = By.Id("passwd");

        /// <summary>Define o campo de clicagem uniform-days.</summary>
        public readonly By FieldDayBirth = By.Id("uniform-days");

        /// <summary>Define o campo dia do nascimento criação.</summary>
        public readonly By CmbDayBirthCreate = By.Id("days");

        /// <summary>Define o campo de clicagem uniform-month.</summary>
        public readonly By FieldMonthBirth = By.Id("uniform-month");

        /// <summary>Define o campo mês nascimento criação.</summary>
        public readonly By CmbMonthBirthCreate = By.Id("months");

        /// <summary>Define o campo de clicagem uniform-year.</summary>
        public readonly By FieldYearBirth = By.Id("uniform-year");

        /// <summary>Define o campo ano nascimento criação.</summary>
        public readonly By CmbYearBirthCreate = By.Id("years");

        #endregion YOUR PERSONAL INFORMATION

        #region YOUR ADDRESS

        /// <summary>Define o campo firstName do endereço.</summary>
        public readonly By TxtFirstNameAddress = By.Id("firstname");

        /// <summary>Define o campo lastName do endereço.</summary>
        public readonly By TxtLastNameAddress = By.Id("lastname");

        /// <summary>Define o campo company do endereço.</summary>
        public readonly By TxtCompanyName = By.Id("company");

        /// <summary>Define o campo address1 do endereço.</summary>
        public readonly By TxtAddress1 = By.Id("address1");

        /// <summary>Define o campo address2 do endereço.</summary>
        public readonly By TxtAddress2 = By.Id("address2");

        /// <summary>Define o campo city do endereço.</summary>
        public readonly By TxtCityAddress = By.Id("city");

        /// <summary>Define o campo State do endereço.</summary>
        public readonly By CmbStateAddress = By.Id("id_state");

        /// <summary>Define o campo postCode do endereço.</summary>
        public readonly By TxtPostCodeAddress = By.Id("postcode");

        /// <summary>Define o campo Country do endereço.</summary>
        public readonly By CmbCountryAddress = By.Id("id_country");

        /// <summary>Define o campo additionalInfomation do endereço.</summary>
        public readonly By TxtAdditionalInformationAddress = By.Id("other");

        /// <summary>Define o campo homePhone do endereço.</summary>
        public readonly By TxtHomePhoneAddress = By.Id("phone");

        /// <summary>Define o campo mobilePhone do endereço.</summary>
        public readonly By TxtMobilePhoneAddress = By.Id("phone_mobile");

        /// <summary>Define o campo addressFutureReference do endereço.</summary>
        public readonly By TxtAddressFutureReference = By.Id("alias");

        #endregion YOUR ADDRESS

        /// <summary>Define o botão register.</summary>
        public readonly By BtnRegister = By.Id("submitAccount");

        /// <summary>Define o a mesagem de campo requirido.</summary>
        public readonly By MsnRequiredFild = By.ClassName("pull-right");

        #endregion AUTHENTICATION CREATE AN ACCOUNT.
    }
}