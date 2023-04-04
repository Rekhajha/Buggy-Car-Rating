using AventStack.ExtentReports;
using BoDi;
using Buggy_Car_Rating.Drivers;
using Buggy_Car_Rating.Support;
using Gherkin.CucumberMessages.Types;
using LivingDoc.Dtos;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Buggy_Car_Rating.Hooks
{
    [Binding]
    public sealed class Hooks:Driver
    {
        public static ExtentReports extent;
        public static ExtentTest test;

        [BeforeTestRun]
        public static void BeforeTestRun() 
        {           
            var currentPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            var reportPath = currentPath + @"\TestReports\Reports\" + (DateTime.Now.ToString("_dd-mm-yyyy_mss")) + "\\" ;

            extent = ExtentReportHelpers.StartReport(reportPath );
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {          
            test = extent.CreateTest(scenarioContext.ScenarioInfo.Title);
            Initialize();
            TurnOnWait();
            NavigateUrl();
        }
       
        [AfterScenario]
        public void AfterScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            
            var status = scenarioContext.TestError;
            var screenshotPath = ScreenshotHelper.SaveScreenshot(Driver.driver, featureContext.FeatureInfo.Title, scenarioContext.ScenarioInfo.Title);

            if (status != null)
            {
                var errorMessage = scenarioContext.TestError.Message;
                test.Log(Status.Fail, scenarioContext.ScenarioInfo.Title + " " + status + " " + errorMessage );           
            }
            else 
            {
               test.Log(Status.Pass, scenarioContext.ScenarioInfo.Title + " " + "test is passed");
            }
                       
            Close();          
        }

        [AfterTestRun]  
        public static void AfterTestRun() 
        {
            extent.Flush();

            extent.RemoveTest(test);
            
        }

    }
}