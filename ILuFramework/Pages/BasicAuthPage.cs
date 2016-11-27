namespace ILuFramework.Pages
{
    using System;

    using ILuFramework.Helpers;

    using OpenQA.Selenium;

    public class BasicAuthPage : AbstractPage
    {
        private readonly string url;
        private readonly string headerLocator;
        private readonly string congratsLocator;

        public IWebElement GetHeaderPage()
        {
            return Browser.Driver.FindByCss(headerLocator);
        }

        public IWebElement GetCongratsParagraph()
        {
            return Browser.Driver.FindByCss(congratsLocator);
        }

        public BasicAuthPage() : base() { }

        public BasicAuthPage(BrowserType browser) : base(browser)
        {
            this.headerLocator = "div > h3";
            this.url = "http://the-internet.herokuapp.com/basic_auth";
            this.congratsLocator = "div > p";
        }

        public void Open(string username, string password)
        {

            Browser.GoTo($"http://{username}:{password}@the-internet.herokuapp.com/basic_auth");
        }
    }
}
