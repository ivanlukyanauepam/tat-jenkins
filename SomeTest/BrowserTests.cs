namespace SomeTest
{
    using System;

    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    using RelevantCodes.ExtentReports;

    public class BrowserTests
    {
        protected IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;


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

        [OneTimeSetUp]
        public void StartReport()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\MyOwnReport.html";

            extent = new ExtentReports(reportPath, true);
            extent
            .AddSystemInfo("Host Name", "Ivan.Lukyanau")
            .AddSystemInfo("Environment", "QA")
            .AddSystemInfo("User Name", "Ivan Lukyanau");
            extent.LoadConfig(projectPath + "extent-config.xml");
        }

        [Test]
        public void BasicAuthTest()
        {
            test = extent.StartTest("BasicAuthTest");
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
            test.Log(LogStatus.Pass, "Auth was successfully passed.");
        }

        [TearDown]
        protected void Clear()
        {
            driver.Quit();
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            extent.EndTest(test);
            extent.Flush();
            extent.Close();
        }
    }
}
