﻿namespace ILuFramework.Pages
{
    using ILuFramework.Helpers;

    using OpenQA.Selenium;

    public abstract class AbstractPage
    {
        protected readonly BrowserInstance Browser;

        protected virtual string Url
        {
            get
            {
                return "http://the-internet.herokuapp.com/";
            }
        }

        protected virtual string HeaderLocator
        {
            get
            {
                return "div > h3";
            }
        }

        //protected string HeaderSelector { get; set; }

        protected AbstractPage()
        {
            this.Browser = BrowserInstance.Get();
        }

        protected AbstractPage(BrowserType browser)
        {
            this.Browser = BrowserInstance.Get(browser);
        }

        public IWebElement GetHeaderPage()
        {
            return Browser.Driver.FindByCss("div > h3");
        }

        public void Open()
        {
            Browser.GoTo(Url);
        }

        public void Close()
        {
            Browser.Kill();
        }

    }
}
