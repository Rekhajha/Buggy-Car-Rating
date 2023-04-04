using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buggy_Car_Rating.Drivers;
using System.Globalization;

namespace Buggy_Car_Rating.Support
{
    public class WaitHelpers
    {
        
        WebDriverWait webDriverWait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(30));
        public void WaitForElementVisible(By locator)
        {
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        
        public bool WaitForElementToBeInvisible(By locator, string text)
        {
            return webDriverWait.Until(ExpectedConditions.InvisibilityOfElementWithText(locator,text));
        }

        public void WaitForElementClickable( By locator)
        {
            webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        public void WaitForElementClickable(IWebElement element)
        {
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

    }
}
