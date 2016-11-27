namespace ILuFramework.Services
{
    using System;

    using ILuFramework.Pages;

    using OpenQA.Selenium;

    public class LoginService
    {
        private LoginPage loginPage;

        public LoginService(string browserType)
        {
            BrowserType type = BrowserType.Chrome;
            Enum.TryParse<BrowserType>(browserType, out type);

            this.loginPage = new LoginPage(type);
        }

        public void OpenLoginPage()
        {
            loginPage.Open();
        }

        public IWebElement LoginAs(string username, string password)
        {
            loginPage.TypeUsername(username);
            loginPage.TypePassword(password);
            return loginPage.SubmitLogin();
        }

        public IWebElement GetHeaderPage()
        {
            return loginPage.GetHeaderPage();
        }

        public void CloseLoginPage()
        {
            loginPage.Close();
        }

    }
}
