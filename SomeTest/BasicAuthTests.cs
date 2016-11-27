namespace SomeTest
{
    using ILuFramework.Services;

    using NUnit.Framework;

    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class BasicAuthTests
    {
        private BasicAuthService service;

        [SetUp]
        public void BeforeTest()
        {
            service = new BasicAuthService(BrowserType.Chrome.ToString());

        }

        [Test]
        public void LoginAsAdminTest()
        {
            // arrange
            string username = "admin";
            string password = "admin";

            // act
            var successfullyAuthenticatdIndicator = service.LoginAs(username, password);

            // assert
            StringAssert.StartsWith("Congratulations", successfullyAuthenticatdIndicator.Text);
        }

        [TearDown]
        public void AfterTest()
        {
            service.ClosePage();
        }

    }


}
