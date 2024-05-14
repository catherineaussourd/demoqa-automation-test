using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace PitangAutomation.TestClasses.Reports
{
    public class ReportGenerator
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        public static void SetupExtentReport(string reportName, string documentTitle)
        {
            var htmlReporter = new ExtentSparkReporter($"{reportName}.html");
            htmlReporter.Config.DocumentTitle = documentTitle;
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        public static void CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static void LogPass(string message)
        {
            _test.Pass(message);
        }

        public static void LogFail(string message)
        {
            _test.Fail(message);
        }

        public static void SaveReport()
        {
            _extent.Flush();
        }
    }
}
