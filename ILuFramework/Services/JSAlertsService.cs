namespace ILuFramework.Services
{
    using System;

    using ILuFramework.Pages;

    using OpenQA.Selenium;

    public class JSAlertsService
    {
        private JSAlertsPage page;

        public JSAlertsService(string browser)
        {
            BrowserType type = BrowserType.Chrome;
            Enum.TryParse<BrowserType>(browser, out type);
            page = new JSAlertsPage(type);
        }

        public IWebElement GetHeaderPage()
        {
            return page.GetHeaderPage();
        }

        public string GetResult()
        {
            return page.GetResult().Text;
        }

        public void OpenPage()
        {
            this.page.Open();
        }

        public void ClosePage()
        {
            this.page.Close();
        }

        public void ClickAlertAndAcceptButton()
        {
            this.page.ClickOnAlert();
            this.page.SwithToAlertAndAccept();

        }

        public void ClickConfirmButtonAndCancel()
        {
            this.page.ClickOnConfirm();
            this.page.SwithToAlertAndCancel();

        }

        public void ClickConfirmButtonAndOk()
        {
            this.page.ClickOnConfirm();
            this.page.SwithToAlertAndAccept();
        }

        public void ClickPromptButtonAndCancel()
        {
            this.page.ClickOnPrompt();
            this.page.SwithToAlertAndCancel();
        }

        public void ClickPromptButtonAndOk()
        {
            this.page.ClickOnPrompt();
            this.page.SwithToAlertAndAccept();
        }

        public void FillInPromptFieldWithText(string text)
        {
            this.page.ClickOnPrompt();
            var alert = this.page.SwithToAlert();
            alert.SendKeys(text);
            alert.Accept();
        }
    }
}
