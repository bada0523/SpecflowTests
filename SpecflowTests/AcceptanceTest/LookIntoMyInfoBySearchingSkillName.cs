//using OpenQA.Selenium;
//using RelevantCodes.ExtentReports;
//using SpecflowPages;
//using System;
//using System.Threading;
//using TechTalk.SpecFlow;
//using static SpecflowPages.CommonMethods;

//namespace SpecflowTests.AcceptanceTest
//{
//    [Binding]
//    //Please add : Utils.Start behind of class name like that public class LookIntoMyInfoBySearchingSkillName : Utils.Start before running
//    public class LookIntoMyInfoBySearchingSkillName
//    {

//        [Given(@"people type skill name on the search bar for 'Test Analyst'")]
//        public void GivenPeopleTypeSkillNameOnTheSearchBarFor()
//        {
//            Thread.Sleep(1000);
//            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/a")).Click();
//            Thread.Sleep(1000);
//            Driver.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[3]/div/input")).SendKeys("Test Analyst");
//            Driver.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[3]/div/button")).Click();
//        }

//        [When(@"people click my Info on a result of user's search")]
//        public void WhenPeopleClickMyInfoOnAResultOfUserSSearch()
//        {
//            for (int i = 1; i <= 100; i++)
//            {
//                string ExpectedName = "Harris Jung";
//                string ActualName = Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/div[1]/a[1]")).Text;
//                Thread.Sleep(500);
//                if(ExpectedName == ActualName)
//                {
//                    Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/a/img")).Click();
//                    break;
//                }
//                else
//                {

//                }
//            }
//        }

//        [Then(@"the details of my shared skill should be displayed")]
//        public void ThenTheDetailsOfMySharedSkillShouldBeDisplayed()
//        {
//            try
//            {
//                //Start the Reports
//                CommonMethods.ExtentReports();
//                Thread.Sleep(1000);
//                CommonMethods.test = CommonMethods.extent.StartTest("Found the details of Harris Jung");

//                Thread.Sleep(1000);
//                string ExpectedValue = "Skills Trade";
//                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[4]/div[2]/div/div/div[1]")).Text;
//                Thread.Sleep(500);
//                if (ExpectedValue == ActualValue)
//                {
//                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Found the details of Harris Jung Successfully");
//                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "ThedetailsFound");
//                }

//                else
//                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

//            }
//            catch (Exception e)
//            {
//                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
//            }
//        }
//    }
//}
