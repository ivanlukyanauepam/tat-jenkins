namespace ILuFramework
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public sealed class Browser
    {
        private static readonly Lazy<IWebDriver> webDriver =
            new Lazy<IWebDriver>(() => new ChromeDriver(InitChromeOptions(new string[] { "--incognito" })));

        private Browser()
        {
        }
        //InternetExplorerOptions  options = new InternetExplorerOptions(); 
        //static IWebDriver webDriver = new InternetExplorerDriver(@"C:\Program Files\Selenium\");

        public static void GoTo(string url)
        {
            webDriver.Value.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            webDriver.Value.Url = url;
        }
        public static void Teardown()
        {
            webDriver.Value.Quit();
        }
        public static void MaximizeWindow()
        {
            webDriver.Value.Manage().Window.Maximize();
        }
        public static IWebDriver Driver
        {
            get { return webDriver.Value; }
        }
        private static ChromeOptions InitChromeOptions(string[] arguments)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(arguments);
            return options;
        }
    }
}
