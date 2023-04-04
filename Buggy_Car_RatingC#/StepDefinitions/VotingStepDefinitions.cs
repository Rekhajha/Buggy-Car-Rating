using Buggy_Car_Rating.Drivers;
using Buggy_Car_Rating.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Buggy_Car_Rating.StepDefinitions
{
    [Binding]
    public class VotingStepDefinitions
    {
        private readonly ModelPage modelPage;
        private readonly HomePage homePage;
        private readonly LoginPage loginPage;

        public VotingStepDefinitions( HomePage homePage, ModelPage modelPage, LoginPage loginPage)
        {
            this.homePage = new HomePage();
            this.modelPage = new ModelPage();
            this.loginPage = new LoginPage();
        }

        [Given(@"a user is log in and navigate to most popular page")]
        public void GivenAUserIsLogInAndNavigateToMostPopularPage()
        {
            loginPage.PerformLogin(loginPage.UserName,loginPage.Password);
            homePage.NavigateToPopularModelPage();

        }

        [When(@"the user made a comment")]
        public void WhenTheUserMadeAComment()
        {
            modelPage.WriteComment();
        }

        [When(@"click on vote button")]
        public void WhenClickOnVoteButton()
        {
            modelPage.ClickVoteButton();
        }


        [Then(@"vote should count and comment textbox should not visible")]
        public void ThenVoteShouldCountAndCommentTextboxShouldNotVisible()
        {
            Assert.IsTrue(modelPage.IsVoteCounted(), "Vote hasn't counted");
            Assert.IsFalse(modelPage.IsCommentBoxAndVoteButtonVisible(), "Comment box and vote button is visible");
        }

        [Given(@"a user navigate to most popular page without log in")]
        public void GivenAUserNavigateToMostPopularPageWithoutLogIn()
        {
            homePage.NavigateToPopularModelPage();

        }        

        [Then(@"the user should see message to login in for vote")]
        public void ThenTheUserShouldSeeMessageToLoginInForVote()
        {
            Assert.AreEqual("You need to be logged in to vote.", modelPage.GetMessage(),"User can see the message");
        }
    }
}
