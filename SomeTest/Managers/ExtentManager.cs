namespace SomeTest.Managers
{
    using System;

    using RelevantCodes.ExtentReports;

    internal class ExtentManager
    {
        private static string reportPath = GetTargetReportPath();
        private static string projectPath = GetCurrentProjectPath();
        private static readonly ExtentReports _instance =
        new ExtentReports(reportPath, true)
            .AddSystemInfo("Host Name", "Ivan.Lukyanau")
            .AddSystemInfo("Environment", "QA")
            .AddSystemInfo("User Name", "Ivan Lukyanau")
            .LoadConfig(projectPath + "extent-config.xml");

        static ExtentManager() { }

        private ExtentManager() { }

        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }

        private static string GetTargetReportPath()
        {
            return ExtentManager.GetCurrentProjectPath() + "Reports\\MyOwnReport.html";
        }

        private static string GetCurrentProjectPath()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            return new Uri(actualPath).LocalPath;
        }

    }
}
