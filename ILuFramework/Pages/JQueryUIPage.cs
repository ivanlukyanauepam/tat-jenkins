namespace ILuFramework.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using ILuFramework.Helpers;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class JQueryUIPage : AbstractPage
    {
        private readonly string menuLinkLocator;
        private readonly string menuEnabledItemLocator;

        protected override string Url
        {
            get
            {
                return $"{base.Url}/jqueryui";
            }
        }

        public JQueryUIPage(BrowserType browser) : base(browser)
        {
            this.menuLinkLocator = "div > ul > li";
            this.menuEnabledItemLocator = "ul#menu > li";
        }
        public void ClickOnMenu()
        {
            var menuLinks = (ICollection<IWebElement>)Browser.Driver.FindElementsByCss(menuLinkLocator);
            IWebElement menuLink = menuLinks.FirstOrDefault(x => x.Text.Equals("Menu", StringComparison.OrdinalIgnoreCase));
            menuLink.FindElement(By.TagName("a")).Click();
        }

        public IWebElement GetEnabledMenuItem()
        {
            return Browser.Driver.FindElementsByCss(menuEnabledItemLocator)[1];
        }

        public Actions MoveThenTo(Actions actions, IWebElement element)
        {
            actions.MoveToElement(element).Perform();
            Thread.Sleep(1000);
            return actions;
        }
        public Actions MoveOverEnabledMenuItem()
        {
            var element = this.GetEnabledMenuItem();

            Actions actions = new Actions(Browser.Driver);
            actions.MoveToElement(element).Perform();
            Thread.Sleep(1000);
            return actions;
        }

        public IWebElement GetDownloadMenuItem()
        {
            return this.GetEnabledMenuItem().FindElementsByCss("ul > li")[0];
        }

        public IWebElement GetDownloadExcelItem()
        {
            return this.GetDownloadMenuItem().FindElementsByCss("ul > li")[2];
        }
    }
}
