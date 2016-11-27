namespace ILuFramework
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;

    public class BrowserInstance
    {
        public IWebDriver Driver;
        private static readonly TimeSpan PageLoadDefaultTimeoutSeconds = TimeSpan.FromSeconds(15);
        private static readonly TimeSpan CommandDefaultTimeoutSeconds = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan WaitElementTimeout = TimeSpan.FromSeconds(5);
        private static readonly int AjaxTimeoutSeconds = 5;
        private static BrowserInstance _instance = null;
        //private int _scrCounter = 0;
        //private Services.Logger Logger = new Logger();

        public BrowserInstance(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public static BrowserInstance Get(BrowserType browser = BrowserType.Chrome)
        {
            if (_instance != null)
            {
                return _instance;
            }
            return _instance = Init(browser);
        }

        private static BrowserInstance Init(BrowserType browser)
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
            return new BrowserInstance(driver);
        }

        public void Kill()
        {
            if (_instance != null)
            {
                try
                {
                    _instance.Driver.Quit();
                }
                catch (Exception e)
                {
                    //Logger.Error($"Cannot kill browser: {e.Message}");
                }
                finally
                {
                    _instance = null;
                }
            }
        }

        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }

    public enum BrowserType
    {
        Chrome = 1,
        Firefox,
        ChromeIncognito
    }
}
