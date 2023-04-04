using Buggy_Car_Rating.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buggy_Car_Rating.Pages
{
    public class LoginPage:BasePage
    {
        public string UsernameFieldSelectorText = "login";
        public IWebElement UsernameField => Driver.driver.FindElement(By.Name(UsernameFieldSelectorText));
        public string PasswordFieldSelectorText = "password";
        public IWebElement PasswordField => Driver.driver.FindElement(By.Name(PasswordFieldSelectorText));
        public IWebElement SubmitButton => Driver.driver.FindElement(By.XPath("//button[@type='submit'][text()='Login']"));
        public string LoginErrorMessageSelectorText => "//span[contains(text(), 'Invalid username/password')]";
        public IWebElement LoginErrorMessage => Driver.driver.FindElement(By.XPath(LoginErrorMessageSelectorText));

      
        public void PerformLogin(string UserName,string Password)
        {
            waitHelper.WaitForElementVisible(By.Name(UsernameFieldSelectorText));
            UsernameField.SendKeys(UserName);

          
            waitHelper.WaitForElementVisible(By.Name(PasswordFieldSelectorText));
            PasswordField.SendKeys(Password);

            SubmitButton.Click();
        }
        public bool IsErrorMessageVisible()
        {
            waitHelper.WaitForElementVisible(By.XPath(LoginErrorMessageSelectorText));
            return LoginErrorMessage.Displayed;

        }
        public bool IsUserNameFieldVisibile()
        {
            waitHelper.WaitForElementVisible(By.Name(UsernameFieldSelectorText));
            return UsernameField.Displayed;

        }
        public bool IsPasswordFieldVisible()
        {
            waitHelper.WaitForElementVisible(By.Name(PasswordFieldSelectorText));
            return PasswordField.Displayed;

        }

    }
}
