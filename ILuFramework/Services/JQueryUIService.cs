namespace ILuFramework.Services
{
    using System;
    using System.Threading;

    using ILuFramework.Pages;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class JQueryUIService
    {
        private JQueryUIPage page;

        public JQueryUIService(string browser)
        {
            BrowserType type = BrowserType.Chrome;
            Enum.TryParse<BrowserType>(browser, out type);
            page = new JQueryUIPage(type);
        }

        public IWebElement GetHeaderPage()
        {
            return page.GetHeaderPage();
        }

        public void MoveToDownloadExcelMenuItem_Click()
        {
            var downloadMenuItem = this.page.GetDownloadMenuItem();
            var downloadExcelItem = this.page.GetDownloadExcelItem();

            var actions = this.page.MoveOverEnabledMenuItem(); // move to Enabled, then
            actions.MoveToElement(downloadMenuItem).Perform(); // let's move to download menu item, then

            Thread.Sleep(2000);

            actions.MoveToElement(downloadExcelItem).Perform(); // move to Excel menu item
            actions.Click().Build().Perform();

            Thread.Sleep(5000); // let time to browser for saving the document
        }

        public void ClickOnMenuLink()
        {
            page.ClickOnMenu();
        }
        public void OpenPage()
        {
            this.page.Open();
        }

        public void ClosePage()
        {
            this.page.Close();
        }
    }
}
