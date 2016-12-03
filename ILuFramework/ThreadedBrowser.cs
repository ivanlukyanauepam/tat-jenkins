namespace ILuFramework
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;

    public class ThreadedBrowser
    {
        private static readonly TimeSpan PageLoadDefaultTimeoutSeconds = TimeSpan.FromSeconds(15);
        private static readonly TimeSpan CommandDefaultTimeoutSeconds = TimeSpan.FromSeconds(1);

        public IWebDriver Driver;

        [ThreadStatic]
        private static ThreadedBrowser instance;

        //private ThreadedBrowser()
        //{
        //    Console.WriteLine("Creating instance in thread " + Thread.CurrentThread.Name);
        //}

        private ThreadedBrowser(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public static ThreadedBrowser Instance(BrowserType browser = BrowserType.Chrome)
        {
            if (instance == null)
            {
                instance = Init(browser);
                //instance = new ThreadedBrowser();
            }
            return instance;

        }

        private static ThreadedBrowser Init(BrowserType browser)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.ChromeIncognito:
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("--incognito");
                        driver = new ChromeDriver(options);
                    }
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            driver.Manage().Timeouts().ImplicitlyWait(CommandDefaultTimeoutSeconds);
            driver.Manage().Timeouts().SetPageLoadTimeout(PageLoadDefaultTimeoutSeconds);
            driver.Manage().Window.Maximize();
            //driver = new EventHandlerLogger(driver);
            return new ThreadedBrowser(driver);
        }

        public void Kill()
        {
            if (instance != null)
            {
                try
                {
                    instance.Driver.Quit();
                }
                catch (Exception e)
                {
                    //Logger.Error($"Cannot kill browser: {e.Message}");
                }
                finally
                {
                    instance = null;
                }
            }
        }

        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}