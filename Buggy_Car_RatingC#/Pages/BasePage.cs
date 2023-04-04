using Buggy_Car_Rating.Drivers;
using Buggy_Car_Rating.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buggy_Car_Rating.Pages
{
    public class BasePage
    {
        public WaitHelpers waitHelper = new WaitHelpers();
       
        public string BuggyRatingLinkSelectorText = "//a[@class='navbar-brand'][text()='Buggy Rating']";
        public IWebElement BuggyRatingLink => Driver.driver.FindElement(By.XPath(BuggyRatingLinkSelectorText));

        public string UserName = "test@user.com";
        public string Password = "Password@111";
        public string WrongPassword = "Password!123";
        public string NewPassword = "Password@222";

    }
}
