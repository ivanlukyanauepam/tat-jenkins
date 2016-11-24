namespace SomeTest
{
    using System;

    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class BrowserTests
    {
        protected IWebDriver driver;

        [SetUp]
        protected void Init()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");

            // run the incognito mode to check auth
            driver = new ChromeDriver(options); // launches
            driver.Manage().Window.Maximize(); // maximize browser
            // setup locator timeout to be 10 seconds at max
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [Test]
        public void BasicAuthTest()
        {
            // arrange
            string username = "admin";
            string password = "admin";

            // act
            driver.Navigate().GoToUrl($"http://{username}:{password}@the-internet.herokuapp.com/basic_auth");

            string authPassedIndicator = driver.FindElement(By.CssSelector("div >h3")).Text;
            string congratsString = driver.FindElement(By.CssSelector("div > p")).Text;

            // assert
            StringAssert.AreEqualIgnoringCase("Basic Auth", authPassedIndicator);
            StringAssert.StartsWith("Congratulations", congratsString);
        }

        [TearDown]
        protected void Clear()
        {
            driver.Quit();
        }
    }
}
