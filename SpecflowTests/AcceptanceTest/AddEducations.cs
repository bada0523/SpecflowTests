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
//    public class AddEducations
//    {
//        public AddEducations()
//        {
//            PageFactory.InitElements(Driver.driver, this);
//        }

//        #region Initialize Web Elements
//        //Click Education Tab
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")]
//        private IWebElement eduTab { get; set; }
//        //Click Add New Button
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")]
//        private IWebElement addNewBtn { get; set; }
//        //CollegeName
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input")]
//        private IWebElement collegeName { get; set; }
//        //Click Country
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select")]
//        private IWebElement clickCountry { get; set; }
//        //Select Country
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select/option[101]")]
//        private IWebElement selectCountry { get; set; }
//        //Click Title
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select")]
//        private IWebElement clickTitle { get; set; }
//        //Select Title
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select/option[1]")]
//        private IWebElement selectTitle { get; set; }
//        //Degree
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input")]
//        private IWebElement addDegree { get; set; }
//        //Click Year
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select")]
//        private IWebElement clickYear { get; set; }
//        //Select Year
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select/option[1]")]
//        private IWebElement selectYear { get; set; }
//        //Click Add Button
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")]
//        private IWebElement clickAddBtn { get; set; }

//        #endregion

//        [Given(@"I clicked on the Educations tab under profile page")]
//        public void GivenIClickedOnTheEducationsTabUnderProfilePage()
//        {
//            //Wait
//            Thread.Sleep(1000);

//            // Click on Profile tab
//            eduTab.Click();
//        }

//        [When(@"I add new educations (.*) and (.*)")]
//        public void WhenIAddNewEducationsAnd(string education, string degree)
//        {
//            //Click on a Add new button
//            addNewBtn.Click();
//            //Add College/University name
//            collegeName.SendKeys(education);
//            //Click on Country of College/University
//            clickCountry.Click();
//            //Choose the Country
//            selectCountry.Click();
//            //Click on Title
//            clickTitle.Click();
//            //Choose the Title
//            selectTitle.Click();

//            //Add Degree
//            addDegree.SendKeys(degree);
//            //Choose Year of graduation
//            clickYear.Click();
//            selectYear.Click();
//            //Click on a Add button
//            clickAddBtn.Click();
//        }

//        [Then(@"those educations (.*) and (.*) should be displayed on my listings")]
//        public void ThenThoseEducationsAndShouldBeDisplayedOnMyListings(string education, string degree)
//        {
//            try
//            {
//                //Start the Reports
//                CommonMethods.ExtentReports();
//                Thread.Sleep(1000);
//                CommonMethods.test = CommonMethods.extent.StartTest("Add educations");

//                Thread.Sleep(1000);
//                for (int i = 1; i <= 100; i++)
//                {
//                    string ExpectedName = education;
//                    string ActualName = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]")).Text;
//                    Thread.Sleep(1000);
//                    if (ExpectedName == ActualName)
//                    {
//                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a educations Successfully");
//                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationsAdded");
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
