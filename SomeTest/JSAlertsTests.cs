namespace SomeTest
{
    using ILuFramework.Services;

    using NUnit.Framework;

    //[Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class JSAlertsTests : BaseTest
    {
        private JSAlertsService service;

        [SetUp]
        public void BeforeTest()
        {
            service = new JSAlertsService(BrowserType.Chrome.ToString());
            service.OpenPage();

        }

        [Test]
        public void CheckTheHeaderPage()
        {
            StringAssert.AreEqualIgnoringCase("JavaScript Alerts", service.GetHeaderPage().Text);
        }

        [Test]
        public void CheckAlert()
        {
            service.ClickAlertAndAcceptButton();
            var result = service.GetResult();

            StringAssert.EndsWith("alert", result);
        }

        [Test]
        public void CheckConfirm_Cancel()
        {
            service.ClickConfirmButtonAndCancel();
            var result = service.GetResult();

            StringAssert.EndsWith("Cancel", result);
        }

        [Test]
        public void CheckConfirm_Ok()
        {
            service.ClickConfirmButtonAndOk();
            var result = service.GetResult();

            StringAssert.EndsWith("Ok", result);
        }

        [Test]
        public void CheckPrompt_TypeNothing_ClickCancel()
        {
            service.ClickPromptButtonAndCancel();
            var result = service.GetResult();

            StringAssert.EndsWith("null", result);
        }

        [Test]
        public void CheckPrompt_TypeNothing_ClickOk()
        {
            service.ClickPromptButtonAndOk();
            var result = service.GetResult();

            StringAssert.AreEqualIgnoringCase("You entered:", result);
        }

        [Test]
        public void CheckPrompt_TypeText_ClickOk()
        {
            service.FillInPromptFieldWithText("Hello!");
            var result = service.GetResult();

            StringAssert.AreEqualIgnoringCase("You entered: Hello!", result);
        }

        [TearDown]
        public void AfterTest()
        {
            service.ClosePage();
        }

    }
}
