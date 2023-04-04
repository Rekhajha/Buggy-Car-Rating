using Buggy_Car_Rating.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Buggy_Car_Rating.Support
{
    public class ScreenshotHelper
    {
        public static string SaveScreenshot(IWebDriver Driver,string featureTitle, string scenarioTitle)
        {

            var currentPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            var folderLocation = currentPath + @"TestReports\Screenshots\";
            if (!Directory.Exists(folderLocation))
            {
                Directory.CreateDirectory(folderLocation);
            }

            var screenShot = ((ITakesScreenshot)Driver).GetScreenshot();
            var fileName = new StringBuilder(folderLocation);
            
            fileName.Append(featureTitle.Replace(" ", "_") + "_" + scenarioTitle.Replace(" ", "_") + "_");
            fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
            fileName.Append(".png");
            screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Png);
                       
            return fileName.ToString();






            /*var screenshotPath = Path.Combine(folderLocation, "screenshot.png");
            screenShot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            Console.WriteLine($"Screenshot saved: {screenshotPath}"); // This is so a link to the screenshot appears in the report
            */
        }

    }
}

