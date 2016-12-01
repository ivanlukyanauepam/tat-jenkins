namespace ILuFramework.Services
{
    using System;

    using ILuFramework.Pages;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class HorizontalSliderService
    {
        private HorizontalSliderPage page;

        public HorizontalSliderService(string browser)
        {
            BrowserType type = BrowserType.Chrome;
            Enum.TryParse<BrowserType>(browser, out type);
            page = new HorizontalSliderPage(type);
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

        public IWebElement GetSliderResult()
        {
            return page.GetSliderResultElement();
        }

        public void SwitchToSliderAndMoveRight(int step)
        {
            var actions = this.page.MoveToSliderElementAndClick();

            this.DoStepRight(actions, step);
        }

        private void DoStepRight(Actions sliderActions, int count)
        {
            do
            {
                sliderActions.SendKeys(Keys.Right).Perform();
                count--;
            }
            while (count != 0);
        }
    }
}
