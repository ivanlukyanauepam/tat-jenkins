namespace SomeTest
{
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;

    using RelevantCodes.ExtentReports;

    using SomeTest.Managers;

    [TestFixture]
    public class BaseTest
    {
        protected ExtentReports extentReport;
        protected ExtentTest testInfo;

        [OneTimeSetUp]
        public void FixtureInit()
        {
            this.extentReport = ExtentManager.Instance;


        }

        [SetUp]
        public void Setup()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            testInfo = extentReport.StartTest(testName);
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            this.testInfo.Log(logstatus, "Test ended with " + logstatus + stacktrace);

            this.extentReport.EndTest(this.testInfo);
            this.extentReport.Flush();
        }

        //[OneTimeTearDown]
        //public void EndReport()
        //{
        //    extent.EndTest(test);
        //    extent.Flush();
        //    extent.Close();
        //}
    }
}
