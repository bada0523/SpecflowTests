using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class LookIntoMyInfoBySearchingCategory
    {

        public LookIntoMyInfoBySearchingCategory()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region
        //Click MarsLogo
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/a")]
        private IWebElement marsLogo { get; set; }
        //Click Category Programming Tech
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/section[1]/div/div[2]/div/div[2]/div[2]/a/img")]
        private IWebElement mainCategory { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[11]")]
        private IWebElement subCategory { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[1]/div/button[1]")]
        private IWebElement resPerPage { get; set; }

        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion
        [Given(@"the categories should be displayed on the homepage")]
        public void GivenTheCategoriesShouldBeDisplayedOnTheHomepage()
        {
            Thread.Sleep(1000);
            //Click Mars Logo
            marsLogo.Click();
        }

        [When(@"people click Programming & Tech on the category")]
        public void WhenPeopleClickProgrammingTechOnTheCategory()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(mainCategory));
            mainCategory.Click();
        }

        [When(@"people click QA under the category of Programming & Tech")]
        public void WhenPeopleClickQAUnderTheCategoryOfProgrammingTech()
        {
            if (Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[11]")).Displayed)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[11]")));
                subCategory.Click();
            }
            else
            {
                Driver.driver.Navigate().Refresh();
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[11]")));
                subCategory.Click();
            }

        }

        [When(@"people click my info on a result of user's search")]
        public void WhenPeopleClickMyInfoOnAResultOfUserSSearch()
        {
            var rowCount = Driver.driver.FindElements(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div")).Count;
            bool exitOuterLoop = false;
            
            
            resPerPage.Click();
            
            for (int i = 3; i <= 100; i++)
            {
                for (int j = 1; j <= rowCount; j++)
                {
                    //Expected keyword for searching
                    string ExpectedName = "Harris Jung";
                    //Reading actual keyword each Info
                    string ActualName = Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + j + "]/div[1]/a[1]")).Text;
                    Thread.Sleep(500);
                    //Compare with actual and expected keyword
                    if (ExpectedName == ActualName)
                    {
                        //Click the keyword I am searching
                        Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + j + "]/a/img")).Click();
                        //Exit Outer Loop
                        exitOuterLoop = true;
                        break;
                    }
                    else
                    {
                    }
                }
                if (exitOuterLoop == false)
                {
                    //Move to Next page
                    Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[3]/div[2]/div/button[" + i + "]")).Click();
                }
                else
                {
                    break;
                }
            }
        }

        [Then(@"the details of my shared skilll should be displayed")]
        public void ThenTheDetailsOfMySharedSkilllShouldBeDisplayed()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Found the details of Harris Jung");

                Thread.Sleep(1000);
                string ExpectedValue = "Skills Trade";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[4]/div[2]/div/div/div[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Found the details of Harris Jung Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "ThedetailsFound");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
