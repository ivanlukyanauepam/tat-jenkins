namespace SomeTest
{
    using ILuFramework.Services;

    using NUnit.Framework;

    [Parallelizable(ParallelScope.Fixtures)]
    public class HoversTest
    {
        private HeversService service;

        [SetUp]
        public void BeforeTest()
        {
            service = new HeversService(BrowserType.Chrome.ToString());
            service.OpenPage();

        }

        [Test]
        public void CheckTheHeaderPage()
        {
            StringAssert.AreEqualIgnoringCase("Hovers", service.GetHeaderPage().Text);
        }

        [Test]
        public void MoveOverFirstFigureAndCheckViewProfileLink([Values(0, 1, 2)]int userId)
        {
            var profileLink = service.MoveOverElementAndReturnViewProfileLink(userId);

            string href = profileLink.GetAttribute("href");
            StringAssert.EndsWith($"users/{++userId}", href);
        }

        [TearDown]
        public void AfterTest()
        {
            service.ClosePage();
        }
    }
}
