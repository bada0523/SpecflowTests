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
//    public class AddSharedSkill
//    {
//        public AddSharedSkill()
//        {
//            PageFactory.InitElements(Driver.driver, this);
//        }

//        #region Initialize Web Elements
//        //Click ShareSkill Button
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[2]/a")]
//        private IWebElement shareSkillBtn { get; set; }
//        //Add Title
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input")]
//        private IWebElement addTitle { get; set; }
//        //Add Description
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea")]
//        private IWebElement addDescription { get; set; }
//        //Select Category
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[6]")]
//        private IWebElement clickCategory { get; set; }
//        //Select Sub Category
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[4]")]
//        private IWebElement clickCategory2 { get; set; }
//        //Add Tag
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
//        private IWebElement addTag { get; set; }
//        //Press Enter key on Add Tag field
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
//        private IWebElement enterKeyTag { get; set; }
//        //Select Service Type
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
//        private IWebElement serviceType { get; set; }
//        //Select Location Type
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
//        private IWebElement locationType { get; set; }
//        //Select Available Days - Start Date
//        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(1) > div:nth-child(2) > input[type='date']")]
//        private IWebElement startDate { get; set; }
//        //Select Available Days - End Date
//        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(1) > div:nth-child(4) > input[type='date']")]
//        private IWebElement endDate { get; set; }
//        //Click Credit Button on Skill Trade
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
//        private IWebElement skillTrade { get; set; }
//        //Add Skill-Exchange
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
//        private IWebElement skillExchange { get; set; }
//        //Press Enter Key on Skill-Exchange field
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
//        private IWebElement enterKeySK { get; set; }
//        //Click work Sample Button
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
//        private IWebElement workSampleBtn { get; set; }
//        //Select Active
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
//        private IWebElement activeBtn { get; set; }
//        //Click Save Button
//        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")]
//        private IWebElement saveBtn { get; set; }

//        #endregion


//        [Given(@"I clicked on the button Share Skill under Profile page")]
//        public void GivenIClickedOnTheButtonShareSkillUnderProfilePage()
//        {
//            //Wait
//            Thread.Sleep(1000);

//            // Click the button Share Skill
//            shareSkillBtn.Click();
//        }

//        [When(@"I add a new shared skill")]
//        public void WhenIAddANewSharedSkill()
//        {
//            //Add Title
//            addTitle.SendKeys("Test Analyst");
//            //Enter Description
//            addDescription.SendKeys("I want to skill trade");
//            //Click on Category
//            clickCategory.Click();
//            clickCategory2.Click();
//            //Add Tag
//            addTag.SendKeys("#Selenium");
//            enterKeyTag.SendKeys(Keys.Enter);

//            //Choose Service Type
//            serviceType.Click();
//            //Choose Location Type
//            locationType.Click();
//            //Choose Available Days - Start date
//            startDate.SendKeys("2019-05-30");
//            //Choose Available Days - End date
//            endDate.SendKeys("2019-08-13");

//            //Choose Available Time - 10:00am to 16:00pm on Mon - Thu
//            for (int i = 3; i < 7; i++)
//            {
//                Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + i + "]/div[1]/div/input")).Click();
//                Driver.driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(" + i + ") > div:nth-child(2) > input[type='time']")).SendKeys(Keys.ArrowUp);
//                Driver.driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(" + i + ") > div:nth-child(2) > input[type='time']")).SendKeys(Keys.Tab);
//                Driver.driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(" + i + ") > div:nth-child(2) > input[type='time']")).SendKeys("1000");
//                Driver.driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(" + i + ") > div:nth-child(3) > input[type='time']")).SendKeys(Keys.ArrowDown);
//                Driver.driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(" + i + ") > div:nth-child(3) > input[type='time']")).SendKeys(Keys.Tab);
//                Driver.driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(" + i + ") > div:nth-child(3) > input[type='time']")).SendKeys("0400");
//            }
//            //Click on Skill trade
//            skillTrade.Click();
//            //Add Skill-Exchange
//            skillExchange.SendKeys("#JIRA");
//            enterKeySK.SendKeys(Keys.Enter);
//            //Upload Work Samples
//            workSampleBtn.Click();
//            Thread.Sleep(1000);
//            //Please, make a txt file and change the path for you 
//            System.Windows.Forms.SendKeys.SendWait(@"C:\Users\HarrisVicky\Desktop\fortesting.txt");
//            System.Windows.Forms.SendKeys.SendWait("{Enter}");
//            //Choose Active
//            activeBtn.Click();
//            //Click the button Save
//            saveBtn.Click();



//        }

//        [Then(@"the lists of shared skill you have been posting should be displayed on my listings")]
//        public void ThenTheListsOfSharedSkillYouHaveBeenPostingShouldBeDisplayedOnMyListings()
//        {
//            Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/section[1]/div/a[3]")).Click();
//            Thread.Sleep(1000);
//            try
//            {
//                //Start the Reports
//                CommonMethods.ExtentReports();
//                Thread.Sleep(1000);
//                CommonMethods.test = CommonMethods.extent.StartTest("Add a shared skill");

//                Thread.Sleep(1000);
//                string ExpectedValue = "Test Analyst";
//                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr/td[3]")).Text;
//                Thread.Sleep(1000);
//                if (ExpectedValue == ActualValue)
//                {
//                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a shared skill Successfully");
//                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SharedSkillAdded");
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
