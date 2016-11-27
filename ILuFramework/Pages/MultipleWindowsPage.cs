namespace ILuFramework.Pages
{
    using System;
    using System.Collections.Generic;

    using ILuFramework.Helpers;

    using OpenQA.Selenium;

    public class MultipleWindowsPage : AbstractPage
    {
        private readonly string url;
        private readonly string headerLocator;
        private readonly string newPageLinkLocator;

        public IWebElement GetHeaderPage()
        {
            return Browser.Driver.FindByCss(headerLocator);
        }

        public MultipleWindowsPage() : base() { }

        public MultipleWindowsPage(BrowserType browser) : base(browser)
        {
            this.newPageLinkLocator = "div > a";
            this.headerLocator = "div > h3";
            this.url = "http://the-internet.herokuapp.com/windows";
        }


        // potentially could be included into the driver's actions through the extension mechanism
        public IWebElement FindLinkWithText(string text)
        {
            var links = Browser.Driver.FindElementsByCss(newPageLinkLocator);

            foreach (var link in links)
            {
                if (link.Text.Equals(text, StringComparison.OrdinalIgnoreCase))
                {
                    return link;
                }
            }

            return null;
        }

        public void ClickOnTheLinkWithText(string text)
        {
            this.FindLinkWithText(text).Click();
        }

        public void MoveToRecentlyOpenedTab()
        {
            Browser.Driver.SwitchTo().Window(Browser.Driver.WindowHandles[Browser.Driver.WindowHandles.Count - 1]);
        }

        public void Open()
        {
            Browser.GoTo(this.url);
        }

    }
}
