namespace ILuFramework.Services
{
    using System;

    using ILuFramework.Helpers;
    using ILuFramework.Pages;

    using OpenQA.Selenium;

    public class MultipleWindowsService
    {
        private MultipleWindowsPage page;

        public MultipleWindowsService(string browserType)
        {
            BrowserType type = BrowserType.Chrome;
            Enum.TryParse<BrowserType>(browserType, out type);

            this.page = new MultipleWindowsPage(type);
        }
        public void OpenLoginPage()
        {
            this.page.Open();
        }
        public IWebElement GetHeaderPage()
        {
            return page.GetHeaderPage();
        }
        public IWebElement FindLinkWithText(string text)
        {
            return page.FindLinkWithText(text);
        }
        public IWebElement GoToNextPageThroughClick(string text)
        {
            // let's move on the next page and find the header again

            this.page.ClickOnTheLinkWithText(text);
            this.page.MoveToRecentlyOpenedTab();
            return this.page.GetHeaderPage();

        }
        public void CloseLoginPage()
        {
            this.page.Close();
        }
    }
}
