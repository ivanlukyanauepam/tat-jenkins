namespace SomeTest
{
    using ILuFramework.Services;

    using NUnit.Framework;

    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class LoginTests
    {
        private LoginService service;

        private static object[] LoginSourceCases =
        {
            new object[] { "incorrect", "SuperSecretPassword!", "username" },
            new object[] { "incorrect", "incorrect", "username" },
            new object[] { "tomsmith", "incorrect", "password" }
        };

        [Test]
        public void HeaderCheckTest_AfterPageIsLoaded()
        {
            StringAssert.AreEqualIgnoringCase("Login Page", this.service.GetHeaderPage().Text);
        }


        [Test, TestCaseSource("LoginSourceCases")]
        public void LoginTest_Negative(string username, string password, string alertMessage)
        {
            var loginResultElement = this.service.LoginAs(username, password);

            // we've got negative alert
            StringAssert.Contains($"Your {alertMessage} is invalid", loginResultElement.Text);
        }

        [TestCase("tomsmith", "SuperSecretPassword!", "You logged into a secure area")]
        public void LoginTest_Positive(string username, string password, string alertMessage)
        {
            var loginResultElement = this.service.LoginAs(username, password);

            //we've got successfully logged out
            StringAssert.Contains(alertMessage, loginResultElement.Text);
        }

        [SetUp]
        public void BeforeTest()
        {
            service = new LoginService(BrowserType.Chrome.ToString());
            service.OpenLoginPage();
            //_service = new LoginService(TestContext.Parameters["browser"]);

        }

        [OneTimeSetUp]
        public void BeforeFixture()
        {
            // run one time for a fixture
        }

        [TearDown]
        public void AfterTest()
        {
            //var status = TestContext.CurrentContext.Result.Outcome.Status;
            //var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            //        ? ""
            //        : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            //LogStatus logstatus;

            //switch (status)
            //{
            //    case TestStatus.Failed:
            //        logstatus = LogStatus.Fail;
            //        break;
            //    case TestStatus.Inconclusive:
            //        logstatus = LogStatus.Warning;
            //        break;
            //    case TestStatus.Skipped:
            //        logstatus = LogStatus.Skip;
            //        break;
            //    default:
            //        logstatus = LogStatus.Pass;
            //        break;
            //}

            //test.Log(logstatus, "Test ended with " + logstatus + stacktrace);

            //extent.EndTest(test);
            //extent.Flush();
            service.CloseLoginPage();
        }

    }
}
