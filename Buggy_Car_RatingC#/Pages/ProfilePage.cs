using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buggy_Car_Rating.Drivers;
using Faker;
using System.Globalization;

namespace Buggy_Car_Rating.Pages
{
    public class ProfilePage:BasePage
    {
        public string ProfileFormSelectorText = "//div[@class='container'][@role='main']" ;
        public IWebElement ProfileForm => Driver.driver.FindElement(By.XPath(ProfileFormSelectorText));
        public IWebElement FirstNameField => Driver.driver.FindElement(By.Id("firstName"));
        public IWebElement LastNameField => Driver.driver.FindElement(By.Id("lastName"));
        public IWebElement GenderField => Driver.driver.FindElement(By.Id("gender"));
        public IWebElement AgeField => Driver.driver.FindElement(By.Id("age"));
        public IWebElement AddressField => Driver.driver.FindElement(By.Id("address"));
        public IWebElement PhoneField => Driver.driver.FindElement(By.Id("phone"));
        public IWebElement HobbyDropdownField => Driver.driver.FindElement(By.Id("hobby"));
        public IWebElement CurrentPasswordField => Driver.driver.FindElement(By.Id("currentPassword"));
        public IWebElement NewPasswordField => Driver.driver.FindElement(By.Id("newPassword"));
        public IWebElement ConfirmPasswordField => Driver.driver.FindElement(By.Id("newPasswordConfirmation"));
        public IWebElement SaveButton => Driver.driver.FindElement(By.XPath("//button[@type='submit'][text()='Save']"));

        public string ProfileSuccessMessageSelectorText = "//div[contains(text(),'The profile has been saved successful')]";
        public IWebElement ProfileSaveSuccessMessage => Driver.driver.FindElement(By.XPath(ProfileSuccessMessageSelectorText));

        string address = " ";
        bool IsPasswordUpadate= false;

        public void SelectHobby(string hobby)
        {
            var drpdownField = new SelectElement(HobbyDropdownField);
            drpdownField.SelectByText(hobby);
        }

        public void SelectGender(string gender)
        {
            GenderField.Clear();
            GenderField.SendKeys(gender);
            GenderField.SendKeys(Keys.Tab);
        }

        public void UpdateProfileForm(string password, string newPassword)
        {
            waitHelper.WaitForElementVisible(By.Id("firstName"));
            address = Faker.Address.SecondaryAddress();
            
             
            SelectGender("Female");
            AgeField.SendKeys("21");

            AddressField.Clear();
            AddressField.SendKeys(address);

            SelectHobby("Movies");
            UpdatePassword(password, newPassword);

            SaveButton.Click();

            IsPasswordUpadate = true;
           
        }

        public bool IsCurrentProfileUpdated()
        {
            bool IsUpadte = true;
            if (IsPasswordUpadate)
            {
                UpdatePassword(NewPassword, Password);
                SaveButton.Click();
                IsPasswordUpadate=false;
            }

            waitHelper.WaitForElementVisible(By.Id("firstName"));

            Console.WriteLine("Gender " + GenderField.GetAttribute("value"));
            Console.WriteLine("AgeField " + AgeField.GetAttribute("value"));
            Console.WriteLine("AddressField " + AddressField.GetAttribute("value"));
            
            Console.WriteLine("HobbyDropdownField " + HobbyDropdownField.GetAttribute("value"));
            string num;

            if (GenderField.GetAttribute("value") != "Female")
            {
                IsUpadte = false; num = "Female";
                Console.WriteLine(num);
            }
            if (AgeField.GetAttribute("value") != "21")
            {
            
            IsUpadte = false; num = "AgeField"; Console.WriteLine(num);
            }
            if (AddressField.GetAttribute("value") != address)
            {
                IsUpadte = false; num = "Address"; Console.WriteLine(num);
            }
             if (HobbyDropdownField.GetAttribute("value") != "Movies")
            {
                IsUpadte = false; num = "Hobby"; Console.WriteLine(num);
            }

            return IsUpadte;
        }

        public void UpdatePassword(string password, string newPassword)
        {
            CurrentPasswordField.SendKeys(password);

            NewPasswordField.SendKeys(newPassword);
            ConfirmPasswordField.SendKeys(newPassword);

        }
        public bool IsSuccessMessageVisible()
        {
            waitHelper.WaitForElementVisible(By.XPath(ProfileSuccessMessageSelectorText));
            return ProfileSaveSuccessMessage.Displayed;
        }
    }
}
