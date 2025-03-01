﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class LookIntoMyInfoBySearchingSkillName
    {

        [Given(@"people type skill name on the search bar for 'Test Analyst'")]
        public void GivenPeopleTypeSkillNameOnTheSearchBarFor()
        {
            Thread.Sleep(1000);
            //Click Mars Logo
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/a")).Click();
            Thread.Sleep(1000);
            //Enter keyword
            Driver.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[3]/div/input")).SendKeys("Test Analyst");
            //Click search button
            Driver.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[3]/div/button")).Click();
        }

        [When(@"people click my Info on a result of user's search")]
        public void WhenPeopleClickMyInfoOnAResultOfUserSSearch()
        {
            var rowCount = Driver.driver.FindElements(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div")).Count;
            bool exitOuterLoop = false;
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

        [Then(@"the details of my shared skill should be displayed")]
        public void ThenTheDetailsOfMySharedSkillShouldBeDisplayed()
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
