namespace ILuFramework.Services
{
    using System;

    using ILuFramework.Pages;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class HeversService
    {
        private HoversPage page;

        public HeversService(string browser)
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

        public IWebElement MoveOverElementAndReturnViewProfileLink(int index)
        {
            var figures = page.GetFigures();
            var figure = (IWebElement)figures[index];

            this.page.MoveOverElement(figure);
            return this.page.GetViewProfileResultElement(figure);
        }

    }
}
