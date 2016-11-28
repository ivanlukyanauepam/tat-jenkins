namespace ILuFramework.Pages
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using ILuFramework.Helpers;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class HoversPage : AbstractPage
    {
        private readonly string classOfFiguresLocator;
        private readonly string viewProfileLocator;

        protected override string Url
        {
            get
            {
                return $"{base.Url}/hovers";
            }
        }

        public HoversPage(BrowserType browser) : base(browser)
        {
            this.classOfFiguresLocator = "figure";
            this.viewProfileLocator = "div > a";
        }

        public ReadOnlyCollection<IWebElement> GetFigures()
        {
            return this.Browser.Driver.FindElements(By.ClassName(classOfFiguresLocator));
        }
        public IWebElement GetViewProfileResultElement(IWebElement element)
        {
            return element.FindElement(By.CssSelector(viewProfileLocator));
        }

        public void MoveOverElement(IWebElement element)
        {
            Actions builder = new Actions(Browser.Driver);
            builder.MoveToElement(element).Perform();
        }

    }
}
