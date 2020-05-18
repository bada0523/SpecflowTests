using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class ReceivedRequests
    {

        public ReceivedRequests()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[1]")]
        private IWebElement manageRequestTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]")]
        private IWebElement receivedRequest { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='received-request-section']/div[2]/h2")]
        private IWebElement checkReceivedRe { get; set; }
        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"I clicked Received Requests under manage requests Tab")]
        public void GivenIClickedReceivedRequestsUnderManageRequestsTab()
        {

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]")));
            manageRequestTab.Click();

        }

        [When(@"I click a request post I have received")]
        public void WhenIClickARequestPostIHaveReceived()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]")));
            receivedRequest.Click();
        }

        [Then(@"the request should be displayed")]
        public void ThenTheRequestShouldBeDisplayed()
        {

            string expectedResult = checkReceivedRe.Text;
            string actualResult = "Received Requests";

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Open Received Requests");

                if (actualResult == expectedResult)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Received Requests works successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "ReceivedRequestsWorked");
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
