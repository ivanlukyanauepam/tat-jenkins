namespace ILuFramework.Services
{
    using System;

    using ILuFramework.Pages;

    using OpenQA.Selenium;

    public class BasicAuthService
    {
        private BasicAuthPage page;

        public BasicAuthService(string browserType)
        {
            BrowserType type = BrowserType.ChromeIncognito;
            Enum.TryParse<BrowserType>(browserType, out type);

            this.page = new BasicAuthPage(type);
        }

        public IWebElement LoginAs(string username, string password)
        {
            page.Open(username, password);
            return page.GetCongratsParagraph();
        }

        public IWebElement GetHeaderPage()
        {
            return this.page.GetHeaderPage();
        }

        public void ClosePage()
        {
            this.page.Close();
        }
    }
}
