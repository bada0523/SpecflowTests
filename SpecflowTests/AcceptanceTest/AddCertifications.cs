//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
//using RelevantCodes.ExtentReports;
//using SpecflowPages;
//using System;
//using System.Threading;
//using TechTalk.SpecFlow;
//using static SpecflowPages.CommonMethods;

//namespace SpecflowTests.AcceptanceTest
//{
//    [Binding]
//    //Please add : Utils.Start behind of class name like that public class AddSharedSkill : Utils.Start before running
//    public class AddCertifications
//    {
       
//        public AddCertifications()
//        {
//            PageFactory.InitElements(Driver.driver, this);
//        }

//        #region  Initialize Web Elements
//        //Certification Tab
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")]
//        private IWebElement certTab { get; set; }
//        //Add new Button
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")]
//        private IWebElement certAddNewBtn { get; set; }
//        //Certificate or Award field
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input")]
//        private IWebElement addCertName { get; set; }
//        //Certificated From field
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input")]
//        private IWebElement addCertFrom { get; set; }
//        //Click Year dropdown
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select")]
//        private IWebElement clickCertYear { get; set; }
//        //Choose Year dropdown
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select/option[3]")]
//        private IWebElement selectCertYear { get; set; }
//        //Click Add Button
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")]
//        private IWebElement addBtn { get; set; }


//        #endregion


//        [Given(@"I clicked on the Certifications tab under profile page")]
//        public void GivenIClickedOnTheCertificationsTabUnderProfilePage()
//        {
//            //Wait 
//            Thread.Sleep(1000);
//            // Click on Profile tab
//            certTab.Click();
//        }

//        [When(@"I add new certification (.*) and (.*)")]
//        public void WhenIAddNewCertificationAnd(string certification, string from)
//        {
//            //Click on a Add new button
//            certAddNewBtn.Click();
//            //Add Certificate or Award
//            addCertName.SendKeys(certification);
//            //Add Certificated From
//            addCertFrom.SendKeys(from);
//            //Click on Year
//            clickCertYear.Click();
//            //Choose the Year
//            selectCertYear.Click();
//            //Click on a Add button
//            addBtn.Click();
//        }

//        [Then(@"those certifications (.*) and (.*) should be displayed on my listings")]
//        public void ThenThoseCertificationsAndShouldBeDisplayedOnMyListings(string certificaion, string from)
//        {
//            try
//            {
//                //Start the Reports
//                CommonMethods.ExtentReports();
//                Thread.Sleep(1000);
//                CommonMethods.test = CommonMethods.extent.StartTest("Add certifications");

//                Thread.Sleep(1000);
//                for (int i = 1; i <= 100; i++)
//                {
//                    string ExpectedName = certificaion;
//                    string ActualName = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
//                    Thread.Sleep(1000);
//                    if (ExpectedName == ActualName)
//                    {
//                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added certifications Successfully");
//                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "certificationsAdded");
//                        break;
//                    }
//                    else
//                    {

//                    }
//                }

//            }
//            catch (Exception e)
//            {
//                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
//            }
//        }
//    }
//}
