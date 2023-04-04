using Buggy_Car_Rating.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buggy_Car_Rating.Pages
{
    public class HomePage:BasePage
    {
        public string HiUserNameSelectorText => "//span[contains(text(),'Hi')]";
        public IWebElement HiUserName => Driver.driver.FindElement(By.XPath(HiUserNameSelectorText));

        public string RegisterButtonSelectorText = "//a[@class='btn btn-success-outline'][text()='Register']";
        public IWebElement RegisterButton => Driver.driver.FindElement(By.XPath(RegisterButtonSelectorText));

        public string LogoutButtonSelectorText = "//a[@class='nav-link'][text()='Logout']";
        public IWebElement LogoutButton => Driver.driver.FindElement(By.XPath(LogoutButtonSelectorText));

        public string ProfileButtonSelectorText = "//a[@class='nav-link'][text()='Profile']";
        public IWebElement ProfileButton => Driver.driver.FindElement(By.XPath(ProfileButtonSelectorText));

        public string PopularModelLinkSelectorText = "//a[contains(@href,'/model/')]";
        public IWebElement PopularModelLink => Driver.driver.FindElement(By.XPath(PopularModelLinkSelectorText));
        public string PopularModelNameSelectorText => "//body/my-app[1]/div[1]/main[1]/my-home[1]/div[1]/div[2]/div[1]/div[1]/h3[1]";
        public IWebElement PopularModelName => Driver.driver.FindElement(By.XPath(PopularModelNameSelectorText));
        
        public IWebElement PopularMakeLink => Driver.driver.FindElement(By.XPath("//a[contains(@href,'/make/')]"));
        public IWebElement OverallLink => Driver.driver.FindElement(By.XPath("//a[contains(@href,'/overall')]"));

        public bool IsUserNameExists()
        {            
            try
            {
                waitHelper.WaitForElementVisible(By.XPath(HiUserNameSelectorText));

                return HiUserName.Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void ClickLogOutButton()
        {
            waitHelper.WaitForElementVisible(By.XPath(LogoutButtonSelectorText));
            LogoutButton.Click();
        }

        public void ClickRegisterButton()
        {
            waitHelper.WaitForElementVisible(By.XPath(RegisterButtonSelectorText));
            RegisterButton.Click();
        }
        public void ClickProfileButton()
        {
            waitHelper.WaitForElementVisible(By.XPath(ProfileButtonSelectorText));
            ProfileButton.Click();
        }
        public void NavigateToPopularModelPage()
        {
            waitHelper.WaitForElementVisible(By.XPath(PopularModelLinkSelectorText));
            PopularModelLink.Click();
        }

        public string GetPopularModelName()
        {
            waitHelper.WaitForElementVisible(By.XPath(PopularModelNameSelectorText));
            return PopularModelName.Text;
        }

    }
}
