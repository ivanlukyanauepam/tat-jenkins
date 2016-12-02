namespace SomeTest
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;

    using ILuFramework.Services;

    using NUnit.Framework;

    //[Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class JQueryUITests
    {
        private JQueryUIService service;

        [SetUp]
        public void BeforeTest()
        {
            service = new JQueryUIService(BrowserType.Chrome.ToString());
            service.OpenPage();

        }

        [Test]
        [Order(1)]
        public void CheckTheHeaderPage()
        {
            StringAssert.AreEqualIgnoringCase("jQuery ui", service.GetHeaderPage().Text);
        }

        [Test]
        [Order(2)]
        public void ClickOnMenuAndCheckHeaderPageAgain()
        {
            service.ClickOnMenuLink();
            StringAssert.AreEqualIgnoringCase("JQueryUI - Menu", service.GetHeaderPage().Text);
        }

        [Test]
        [Order(3)]
        public void GoToExcelDocDownloadMenu()
        {
            service.ClickOnMenuLink();
            //Thread.Sleep(1000);
            service.MoveToDownloadExcelMenuItem_Click();

        }

        [Test]
        [Order(4)]
        public void IsExcelDocumentDownloadSuccessfully()
        {
            // userprofile path
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(path, "Downloads");

            DirectoryInfo dinfo = new DirectoryInfo(pathDownload);
            FileInfo[] xlsFiles = dinfo.GetFiles("*.xls");

            // let's find downloaded document
            var fileFound = xlsFiles.FirstOrDefault(x => x.Name.StartsWith("menu"));

            Assert.IsNotNull(fileFound);
        }

        [TearDown]
        public void AfterTest()
        {
            service.ClosePage();
        }
    }
}
