namespace ILuFramework.Pages
{
    public abstract class AbstractPage
    {
        protected readonly BrowserInstance Browser;

        protected AbstractPage()
        {
            this.Browser = BrowserInstance.Get();
        }

        protected AbstractPage(BrowserType browser)
        {
            this.Browser = BrowserInstance.Get(browser);
        }

        public void Close()
        {
            Browser.Kill();
        }

    }
}
