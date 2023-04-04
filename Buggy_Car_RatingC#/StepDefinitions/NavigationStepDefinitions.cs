using Buggy_Car_Rating.Drivers;
using Buggy_Car_Rating.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Buggy_Car_Rating.StepDefinitions
{
    [Binding]
    public class NavigationStepDefinitions
    {
        private readonly ModelPage modelPage;
        private readonly HomePage homePage;
        private readonly LoginPage loginPage;
       
        public NavigationStepDefinitions( HomePage homePage, ModelPage modelPage, LoginPage loginPage)
        {
            this.homePage = new HomePage();
            this.modelPage = new ModelPage();
            this.loginPage = new LoginPage();
            

        }
        [Given(@"a user is on Website Landing Page and logged in")]
        public void GivenAUserIsOnWebsiteLandingPageAndLoggedIn()
        {
            loginPage.PerformLogin("test@buggy.org","Password@111");

        }

        [Then(@"the user navigate to Popular Model then confirm model page and back to main page successfully")]
        public void ThenTheUserNavigateToPopularModelThenConfirmModelPageAndBackToMainPageSuccessfully()
        {
            string ModelName = homePage.GetPopularModelName();
            homePage.NavigateToPopularModelPage();
            Assert.IsTrue(ModelName.Contains(modelPage.GetModelName()),"Not Navigate to correct model page");

            modelPage.BuggyRatingLink.Click();
            Assert.AreEqual("https://buggy.justtestit.org/", Driver.driver.Url, "Not Navigate to the main page");


        }

        [Then(@"the user navigate to Overall Rating then confirm overall page and back to main page succesfully")]
        public void ThenTheUserNavigateToOverallRatingThenConfirmOverallPageAndBackToMainPageSuccesfully()
        {
            homePage.OverallLink.Click();
            Assert.AreEqual("https://buggy.justtestit.org/overall", Driver.driver.Url, "Not navigate to the overall page");

            homePage.BuggyRatingLink.Click();
            Assert.AreEqual("https://buggy.justtestit.org/", Driver.driver.Url, "Not navigate to the main page");

        }
    }
}
