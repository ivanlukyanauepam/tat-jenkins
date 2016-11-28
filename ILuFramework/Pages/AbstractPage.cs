namespace ILuFramework.Pages
{
    using ILuFramework.Helpers;

    using OpenQA.Selenium;

    public abstract class AbstractPage
    {
        protected readonly BrowserInstance Browser;

        //protected string HeaderSelector { get; set; }

        protected AbstractPage()
        {
            this.Browser = BrowserInstance.Get();
        }

        protected AbstractPage(BrowserType browser)
        {
            this.Browser = BrowserInstance.Get(browser);
        }

        //protected virtual IWebElement GetPageHeader()
        //{
        //    return Browser.Driver.FindByCss(HeaderSelector);
        //}

        public void Close()
        {
            Browser.Kill();
        }

    }
}
