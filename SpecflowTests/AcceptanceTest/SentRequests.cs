using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class SentRequests : Utils.Start
    {
        

        [Given(@"I clicked Sent Requests under manage requests Tab")]
        public void GivenIClickedSentRequestsUnderManageRequestsTab()
        {
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]")));
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]")).Click();
        }

        [When(@"I click a request post I have sent")]
        public void WhenIClickARequestPostIHaveSent()
        {
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[2]")));
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[2]")).Click();
        }

        [Then(@"this request should be displayed")]
        public void ThenThisRequestShouldBeDisplayed()
        {
            IWebElement checkReceivedRe = Driver.driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/h2"));
            string expectedResult = checkReceivedRe.Text;
            string actualResult = "Sent Requests";

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Open Sent Requests");

                if (actualResult == expectedResult)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Sent Requests works successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SentRequestsWorked");
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
