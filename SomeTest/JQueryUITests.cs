namespace SomeTest
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;

    using ILuFramework.Services;

    using NUnit.Framework;

    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class JQueryUITests : BaseTest
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
        [Ignore("Cannot reach correct folder.")]
        public void IsExcelDocumentDownloadSuccessfully()
        {
            // exception on Jenkins looks like 'MESSAGE:
            // System.IO.DirectoryNotFoundException : Could not find a part of the path 'C:\WINDOWS\system32\config\systemprofile\Downloads'.
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
