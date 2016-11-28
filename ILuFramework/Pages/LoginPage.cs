namespace ILuFramework.Pages
{
    using ILuFramework.Helpers;

    using OpenQA.Selenium;

    public class LoginPage : AbstractPage
    {
        private readonly string usernameLocator;
        private readonly string passwordLocator;
        private readonly string loginButtonLocator;
        private readonly string authResultIndicator;

        protected override string Url
        {
            get
            {
                return $"{base.Url}/login";
            }
        }

        protected override string HeaderLocator
        {
            get
            {
                return "div > h2";
            }
        }

        public LoginPage() : base() { }

        public LoginPage(BrowserType browser) : base(browser)
        {
            this.loginButtonLocator = "button";
            this.passwordLocator = "password";
            this.usernameLocator = "username";
            this.authResultIndicator = "flash";
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
