using AventStack.ExtentReports.Gherkin.Model;
using Buggy_Car_Rating.Drivers;
using NUnit.Framework.Internal.Commands;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V109.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buggy_Car_Rating.Pages
{
    public class ModelPage : BasePage
    {
        public IWebElement CommentField => Driver.driver.FindElement(By.Id("comment"));
        public string VoteNumberSelectorText => "div:nth-child(1) > h4 > strong";
        public IWebElement VoteNumber => Driver.driver.FindElement(By.CssSelector(VoteNumberSelectorText));
        public string VoteButtonSelectorText => "//button[@class='btn btn-success'][text()='Vote!']";
        public IWebElement VoteButton => Driver.driver.FindElement(By.XPath(VoteButtonSelectorText));
        public string VoteMessageSelectorText => "//p[@class='card-text']";
        public IWebElement VoteMessage => Driver.driver.FindElement(By.XPath(VoteMessageSelectorText));
       
        public string ModelNameSelectorText = "//h3[contains(text(),'Guilia Quadrifoglio')]";
        public IWebElement ModelName => Driver.driver.FindElement(By.XPath(ModelNameSelectorText));

        public int TotalBeforeVote;
        private bool check ;

        public void ClickVoteButton ()
        {
            TotalBeforeVote = int.Parse(VoteNumber.Text);

            if (VoteMessage.Displayed)
            {
                Console.WriteLine("Already Voted");
                check = false;
            }
            else
            {
                waitHelper.WaitForElementVisible(By.CssSelector(VoteButtonSelectorText));
                VoteButton.Click();
                check = true;
            }           
        }

        public void WriteComment()
        {
            if (VoteMessage.Displayed)
            {
                Console.WriteLine("Already Voted");
                check = false;
            }
            else
            {
                waitHelper.WaitForElementVisible(By.Id("comment"));
                check = true;
                CommentField.SendKeys("Voted");

            }
        }

        public bool IsVoteCounted()
        {
          
            bool Counted = false;
            
            if (check)
            {                
                int TotalAfterVote = int.Parse(VoteNumber.Text);
                if (TotalAfterVote == TotalBeforeVote + 1)
                    Counted = true;
                return Counted;
            }
            else
            {
                Counted = true;
                return Counted;
            }
        }     

        public bool IsCommentBoxAndVoteButtonVisible()
        {
            if(VoteMessage.Displayed)
            {
                return false;
            }
            else
            {
                waitHelper.WaitForElementVisible(By.Id("comment"));
                return true;
            }
        }
        
        public string GetMessage()
        {
            waitHelper.WaitForElementVisible(By.XPath(VoteMessageSelectorText));
            return VoteMessage.Text;
        }

        public string GetModelName()
        {
            waitHelper.WaitForElementVisible(By.XPath(ModelNameSelectorText));
            return ModelName.Text;
        }
        public void NavigateToBasePage()
        {
            waitHelper.WaitForElementVisible(By.XPath(BuggyRatingLinkSelectorText));
            BuggyRatingLink.Click();
        }


    }
}
