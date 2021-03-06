﻿namespace ILuFramework.Helpers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

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

        public static ReadOnlyCollection<IWebElement> FindElementsByCss(this IWebDriver driver, string selector)
        {
            By cssSelector = By.CssSelector(selector);
            return driver.FindElements(cssSelector);
        }

        public static ReadOnlyCollection<IWebElement> FindElementsByCss(this IWebElement element, string selector)
        {
            By cssSelector = By.CssSelector(selector);
            return element.FindElements(cssSelector);
        }

        public static IWebElement FindByText(this IReadOnlyCollection<IWebElement> collection, string text)
        {
            foreach (var item in collection)
            {
                if (item.Text.Equals(text, System.StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }

            return null;
        }
    }
}
