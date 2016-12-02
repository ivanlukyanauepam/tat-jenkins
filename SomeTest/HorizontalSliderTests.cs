namespace SomeTest
{
    using ILuFramework.Services;

    using NUnit.Framework;

    //[Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class HorizontalSliderTests : BaseTest
    {
        private HorizontalSliderService service;

        [SetUp]
        public void BeforeTest()
        {
            service = new HorizontalSliderService(BrowserType.Chrome.ToString());
            service.OpenPage();

        }

        [Test]
        public void CheckTheHeaderPage()
        {
            StringAssert.AreEqualIgnoringCase("Horizontal Slider", service.GetHeaderPage().Text);
        }

        public static object[] CaseSourceShiftSlider =
        {
            new object[] { 1 , "0.5"},
            new object[] { 2, "1" }
        };


        [Test, TestCaseSource("CaseSourceShiftSlider")]
        public void MoveOverFirstFigureAndCheckViewProfileLink(int shiftToRight, string indicator)
        {
            service.SwitchToSliderAndMoveRight(shiftToRight);

            var sliderResult = service.GetSliderResult();
            StringAssert.AreEqualIgnoringCase(indicator, sliderResult.Text);
        }

        [TearDown]
        public void AfterTest()
        {
            service.ClosePage();
        }
    }
}
