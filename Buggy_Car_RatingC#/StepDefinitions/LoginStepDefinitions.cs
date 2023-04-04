using Buggy_Car_Rating.Drivers;
using Buggy_Car_Rating.Pages;
using FluentAssertions;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Buggy_Car_Rating.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
       
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;
        public LoginStepDefinitions(HomePage homePage, LoginPage loginPage) 
        {
            
            this.homePage = new HomePage();
            this.loginPage = new LoginPage();
        }
        [Given(@"a user is on Website Landing Page")]
        public void GivenAUserIsOnWebsiteLandingPage()
        {
          
        }

        [When(@"the user logs in to the application with valid Credentials")]
        public void WhenTheUserLogsInToTheApplicationWithValidCredentials()
        {
            loginPage.PerformLogin(loginPage.UserName,loginPage.Password);
        }

        [Then(@"the user should be succesfully logged in")]
        public void ThenTheUserShouldBeSuccesfullyLoggedIn()
        {
            Assert.IsTrue(homePage.IsUserNameExists(), "Login was not successful.");
           
        }

       
        [When(@"the user logs in to the application with invalid credential")]
        public void WhenTheUserLogsInToTheApplicationWithInvalidCredential()
        {
            loginPage.PerformLogin(loginPage.UserName, loginPage.WrongPassword);
        }

        [Then(@"the user should be not be able to login successfully")]
        public void ThenTheUserShouldBeNotBeAbleToLoginSuccessfully()
        {

            Assert.IsTrue(loginPage.IsErrorMessageVisible(), "Login error message is not displayed");
        }

        [Given(@"a user logged in")]
        public void GivenAUserLoggedIn()
        {          
            loginPage.PerformLogin(loginPage.UserName, loginPage.Password);
        }

        [When(@"the user click the log out link")]
        public void WhenTheUserClickTheLogOutLink()
        {
            homePage.ClickLogOutButton();
        }

        [Then(@"the user should be log out")]
        public void ThenTheUserShouldBeLogOut()
        {
            Assert.IsTrue(loginPage.IsUserNameFieldVisibile(), "login:usename field is still visible");
            Assert.IsTrue(loginPage.IsPasswordFieldVisible(), "login:password field is still visible");
        }
    }
}
