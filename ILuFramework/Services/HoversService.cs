namespace ILuFramework.Services
{
    using System;

    using ILuFramework.Pages;

    using OpenQA.Selenium;

    public class HoversService
    {
        private HoversPage page;

        public HoversService(string browser)
        {
            BrowserType type = BrowserType.Chrome;
            Enum.TryParse<BrowserType>(browser, out type);
            page = new HoversPage(type);
        }

        public IWebElement GetHeaderPage()
        {
            return page.GetHeaderPage();
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
