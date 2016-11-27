namespace ILuFramework.Pages
{
    using ILuFramework.Helpers;

    using OpenQA.Selenium;

    public class LoginPage : AbstractPage
    {
        private readonly string url;
        private readonly string usernameLocator;
        private readonly string passwordLocator;
        private readonly string loginButtonLocator;
        private readonly string authResultIndicator;

        public IWebElement GetHeaderPage()
        {
            return Browser.Driver.FindByCss("div > h2");
        }

        public LoginPage() : base() { }

        public LoginPage(BrowserType browser) : base(browser)
        {
            this.url = "http://the-internet.herokuapp.com/login";
            this.loginButtonLocator = "button";
            this.passwordLocator = "password";
            this.usernameLocator = "username";
            this.authResultIndicator = "flash";
        }

        public void Open()
        {
            Browser.GoTo(url);
        }

        public void TypeUsername(string username)
        {
            Browser.Driver.FindById(usernameLocator).SendKeys(username);
        }

        public void TypePassword(string password)
        {
            Browser.Driver.FindById(passwordLocator).SendKeys(password);
        }

        /// <summary>
        /// /// Returns alerts that indicates whether we are successfully logged in or not.
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement SubmitLogin()
        {
            Browser.Driver.FindByTag(loginButtonLocator).Submit();
            return Browser.Driver.FindById(authResultIndicator);
        }

    }
}
