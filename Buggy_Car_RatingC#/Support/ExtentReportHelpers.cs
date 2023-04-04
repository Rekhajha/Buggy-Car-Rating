using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using LivingDoc.SpecFlowPlugin;
using System.Reflection;

namespace Buggy_Car_Rating.Support
{
    public static class ExtentReportHelpers
    {
        private static ExtentReports extent;      
        public static ExtentReports StartReport(string reportPath)
        {
            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(reportPath);
            }
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AddSystemInfo("Project Name", "Buggy Car Rating");
            extent.AddSystemInfo("UserName", "Rekha Jha");
            extent.AttachReporter(htmlReporter);
            return extent;
        }
    }
}
