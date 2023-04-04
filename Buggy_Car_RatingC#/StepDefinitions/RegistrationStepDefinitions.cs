using Buggy_Car_Rating.Drivers;
using Buggy_Car_Rating.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Buggy_Car_Rating.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
       
        private readonly RegisterPage registerPage;
        private readonly HomePage homePage;

        public RegistrationStepDefinitions( HomePage homePage, RegisterPage registerPage)
        {
           
            this.homePage = new HomePage();
            this.registerPage = new RegisterPage();
        }
        [Given(@"a user is on Register Page")]
        public void GivenAUserIsOnRegisterPage()
        {
            homePage.ClickRegisterButton();
        }

        [When(@"a user enter all details on Registration form")]
        public void WhenAUserEnterAllDetailsOnRegistrationForm()
        {
            registerPage.CreateNewUser();
        }

        [Then(@"verify registration is a success")]
        public void ThenVerifyRegistrationIsASuccess()
        {
            Assert.IsTrue(registerPage.IsSuccessMessageVisible(), "Registeration was not successful.");
        }

        [Then(@"use should log in successfully")]
        public void ThenUseShouldLogInSuccessfully()
        {
            registerPage.LogInAfterRegisteration();
            Assert.IsTrue(homePage.IsUserNameExists(), "Login was not successful.");
        }
    }
}
