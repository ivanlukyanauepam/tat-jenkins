namespace ILuFramework.Pages
{
    using System.Collections.ObjectModel;

    using ILuFramework.Helpers;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class HorizontalSliderPage : AbstractPage
    {
        private readonly string sliderLocator;
        private readonly string sliderResultLocator;

        protected override string Url
        {
            get
            {
                return $"{base.Url}/horizontal_slider";
            }
        }

        public HorizontalSliderPage(BrowserType browser) : base(browser)
        {
            this.sliderLocator = "input[type=\"range\"]";
            this.sliderResultLocator = "range";
        }

        public IWebElement GetSliderResultElement()
        {
            return Browser.Driver.FindById(sliderResultLocator);
        }

        public IWebElement GetSliderElement()
        {
            return Browser.Driver.FindByCss(sliderLocator);
        }

        public Actions MoveToSliderElementAndClick()
        {
            var element = this.GetSliderElement();

            Actions builder = new Actions(Browser.Driver);
            // offset for x & y to set at the beginning of range input
            builder.MoveToElement(element, 1, 1).Perform();
            builder.Click().Perform(); // focused will be at the center of element position by default
            return builder;
        }
    }
}
