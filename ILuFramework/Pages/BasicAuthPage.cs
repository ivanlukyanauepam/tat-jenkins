namespace ILuFramework.Pages
{
    using System;

    using ILuFramework.Helpers;

    using OpenQA.Selenium;

    public class BasicAuthPage : AbstractPage
    {
        private readonly string congratsLocator;

        protected override string Url
        {
            get
            {
                return $"{base.Url}/basic_auth";
            }
        }

        public IWebElement GetCongratsParagraph()
        {
            return Browser.Driver.FindByCss(congratsLocator);
        }

        public BasicAuthPage() : base() { }

        public BasicAuthPage(BrowserType browser) : base(browser)
        {
            this.congratsLocator = "div > p";
        }

        public void Open(string username, string password)
        {
            //Browser.GoTo($"http://{username}:{password}@the-internet.herokuapp.com/basic_auth");
            Browser.GoTo(string.Format("http://{0}:{1}@the-internet.herokuapp.com/basic_auth", username, password));
        }
    }
}
