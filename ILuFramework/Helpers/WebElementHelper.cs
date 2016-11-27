namespace ILuFramework.Helpers
{
    using System.Collections.Generic;

    using OpenQA.Selenium;

    public static class WebElementHelper
    {
        public static IWebElement FindByCss(this IWebDriver driver, string selector)
        {
            By cssSelector = By.CssSelector(selector);
            return driver.FindElement(cssSelector);
        }

        public static IWebElement FindById(this IWebDriver driver, string selector)
        {
            By idSelector = By.Id(selector);
            return driver.FindElement(idSelector);
        }

        public static IWebElement FindByTag(this IWebDriver driver, string selector)
        {
            By tagSelector = By.TagName(selector);
            return driver.FindElement(tagSelector);
        }

        public static IEnumerable<IWebElement> FindElementsByCss(this IWebDriver driver, string selector)
        {
            By cssSelector = By.CssSelector(selector);
            return driver.FindElements(cssSelector);
        }
    }
}
