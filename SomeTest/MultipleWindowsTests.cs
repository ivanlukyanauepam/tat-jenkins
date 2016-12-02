namespace SomeTest
{
    using ILuFramework.Services;

    using NUnit.Framework;

    //[Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class MultipleWindowsTests
    {
        private MultipleWindowsService service;

        [Test]
        public void HeaderCheckTest_AfterPageIsLoaded()
        {
            StringAssert.AreEqualIgnoringCase("Opening a new window", this.service.GetHeaderPage().Text);
        }

        [Test]
        public void FindLinkOnNewPage()
        {
            var link = service.FindLinkWithText("Click Here");

            // assert
            Assert.IsNotNull(link);
        }

        [Test]
        public void GoToNewPageThroughClick()
        {
            var nextPageHeader = service.GoToNextPageThroughClick("Click Here");

            // assert
            Assert.IsNotNull(nextPageHeader);
            StringAssert.AreEqualIgnoringCase("New Window", nextPageHeader.Text);
        }

        [SetUp]
        public void BeforeTest()
        {
            service = new MultipleWindowsService(BrowserType.Chrome.ToString());
            service.OpenLoginPage();

        }

        [TearDown]
        public void AfterTest()
        {
            service.CloseLoginPage();
        }
    }
}
