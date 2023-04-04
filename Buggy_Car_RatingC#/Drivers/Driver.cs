using MongoDB.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Buggy_Car_Rating.Drivers
{
    public class Driver
    {
        //Initialize the browser
        public static IWebDriver driver { get; set; }

        public void Initialize()
        {
            //Defining the browser
            var currentPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            var chromePath = currentPath + @"\Drivers\chromedriver.exe";
            driver = new ChromeDriver(chromePath);
            
            TurnOnWait();

            //Maximise the window
            driver.Manage().Window.Maximize();
        }

       
        //Implicit Wait
        public static void TurnOnWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl("https://buggy.justtestit.org/");
        }

        //Close the browser
        public static void Close()
        {
            driver.Quit();
        }

    }

}
