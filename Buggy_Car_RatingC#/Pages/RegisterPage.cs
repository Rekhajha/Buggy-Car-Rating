using Buggy_Car_Rating.Drivers;
using Buggy_Car_Rating.Support;
using Faker;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace Buggy_Car_Rating.Pages
{
    public class RegisterPage:BasePage
    {
        public string LoginFieldSelectorText = "username";
        public IWebElement LoginField => Driver.driver.FindElement(By.Id(LoginFieldSelectorText));
        public IWebElement FirstNameField => Driver.driver.FindElement(By.Id("firstName"));
        public IWebElement LastNameField => Driver.driver.FindElement(By.Id("lastName"));
        public IWebElement PasswordField => Driver.driver.FindElement(By.Id("password"));
        public IWebElement ConfirmPasswordField => Driver.driver.FindElement(By.Id("confirmPassword"));
        public By Register => By.XPath("//button[@type='submit'][text()='Register']");
        public IWebElement RegisterButton => Driver.driver.FindElement(Register);

        public string RegisterSuccessMessageSelectorText = "//div[contains(text(),'Registration is successful')]";
        public IWebElement RegisterSuccessMessage => Driver.driver.FindElement(By.XPath(RegisterSuccessMessageSelectorText));

        public string FirstName = " ", LastName = " ", Password = " ",Username = " ";
       
        public void CreateNewUser()
        {
            waitHelper.WaitForElementVisible(By.Id(LoginFieldSelectorText));
            Username = Internet.Email();
            LoginField.SendKeys(Username);

            FirstName = Name.First();
            FirstNameField.SendKeys(FirstName);

            LastName = Name.Last();
            LastNameField.SendKeys(LastName);

            Password = FirstName + '@' + LastName + '1';
            PasswordField.SendKeys(Password);
            ConfirmPasswordField.SendKeys(Password);

            waitHelper.WaitForElementClickable(Register);
            RegisterButton.Click();

            Console.WriteLine("Create"+Username + "   "+  Password);
        }

        public void LogInAfterRegisteration()
        {
            LoginPage loginPage = new LoginPage();
            Console.WriteLine("Afetr" + Username + "   " + Password);
            loginPage.PerformLogin(Username,Password);
        }

        public bool IsSuccessMessageVisible()
        {
            waitHelper.WaitForElementVisible(By.XPath(RegisterSuccessMessageSelectorText));
            return RegisterSuccessMessage.Displayed;
        }
    }
}


