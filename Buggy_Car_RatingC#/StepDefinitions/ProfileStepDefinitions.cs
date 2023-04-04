using Buggy_Car_Rating.Drivers;
using Buggy_Car_Rating.Pages;
using NUnit.Framework;
using System;
using System.Globalization;
using System.Net.NetworkInformation;
using TechTalk.SpecFlow;

namespace Buggy_Car_Rating.StepDefinitions
{
    [Binding]
    public class ProfileStepDefinitions
    {
        private readonly ProfilePage profilePage;
        private readonly HomePage homePage;
        private readonly LoginPage loginPage;

        public ProfileStepDefinitions(HomePage homePage, ProfilePage profilePage, LoginPage loginPage)
        {
            
            this.homePage = new HomePage();
            this.profilePage = new ProfilePage();
            this.loginPage = new LoginPage();
           
        }
        [Given(@"a user is on Profile page")]
        public void GivenAUserIsOnProfilePage()
        {
            loginPage.PerformLogin(loginPage.UserName, loginPage.Password);
            homePage.ClickProfileButton();
        }

        [When(@"the user updates profile form")]
        public void WhenTheUserUpdatesProfileForm()
        {
            profilePage.UpdateProfileForm(profilePage.Password, profilePage.NewPassword);
        }

        [Then(@"the user should see success Message")]
        public void ThenTheUserShouldSeeSuccessMessage()
        {
            Assert.IsTrue(profilePage.IsSuccessMessageVisible(), "User can't see success message.");
        }

        [Then(@"the user should see profile data has changed")]
        public void ThenTheUserShouldSeeProfileDataHasChanged()
        {
            homePage.ClickLogOutButton();

            loginPage.PerformLogin(loginPage.UserName, loginPage.NewPassword);

            homePage.ClickProfileButton();

            Assert.IsTrue(profilePage.IsCurrentProfileUpdated(), "The profile has been not updated.");

            
        }
    }
}
