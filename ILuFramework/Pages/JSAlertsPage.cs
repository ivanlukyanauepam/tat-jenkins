namespace ILuFramework.Pages
{
    using ILuFramework.Helpers;

    using OpenQA.Selenium;

    public class JSAlertsPage : AbstractPage
    {
        private readonly string url;
        private readonly string pageButtonsLocator;
        private readonly string resultElementLocator;

        public IWebElement GetHeaderPage()
        {
            return Browser.Driver.FindByCss("div > h3");
        }

        public IWebElement GetResult()
        {
            return Browser.Driver.FindById(resultElementLocator);
        }

        public JSAlertsPage(BrowserType browser) : base(browser)
        {
            this.url = "http://the-internet.herokuapp.com/javascript_alerts";

            this.pageButtonsLocator = "div > ul > li > button";
            this.resultElementLocator = "result";
        }

        public void ClickOnAlert()
        {
            Browser.Driver.FindElementsByCss(pageButtonsLocator).FindByText("Click for JS Alert").Click();
        }

        public void ClickOnConfirm()
        {
            Browser.Driver.FindElementsByCss(pageButtonsLocator).FindByText("Click for JS Confirm").Click();

        }

        public void ClickOnPrompt()
        {
            Browser.Driver.FindElementsByCss(pageButtonsLocator).FindByText("Click for JS Prompt").Click();

        }

        public void Open()
        {
            Browser.GoTo(url);
        }

        public void SwithToAlertAndAccept()
        {
            Browser.Driver.SwitchTo().Alert().Accept();
        }

        public void SwithToAlertAndCancel()
        {
            Browser.Driver.SwitchTo().Alert().Dismiss();
        }

        public IAlert SwithToAlert()
        {
            return Browser.Driver.SwitchTo().Alert();
        }
    }
}
