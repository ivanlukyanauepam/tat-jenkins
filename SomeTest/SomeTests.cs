namespace SomeTest
{
    using System;
    using NUnit.Framework;

    //[TestFixture]
    public class SomeTests
    {
        public static object[] CaseSourceTestData =
        {
            new object[] { 1, 1.1m, "2.1" },
            new object[] { 2, 2.2m, "4.2" },
            new object[] { 3, 3.3m, "6.3" }
        };

        // just to test work with source
        //[Test, TestCaseSource("CaseSourceTestData")]
        public void CaseSourceTest(int a, decimal b, string c)
        {
            // Can also specify the class to which the property is found upon.
            Assert.That(a + b, Is.EqualTo(Decimal.Parse(c)));
        }



    }
}
