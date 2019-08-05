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
//    public class AddLanguages
//    {

//        public AddLanguages()
//        {
//            PageFactory.InitElements(Driver.driver, this);
//        }

//        #region Initialize Web Elements
//        //Click Language Tab
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/a[2]")]
//        private IWebElement languageTab { get; set; }
//        //Click AddNew Button
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")]
//        private IWebElement addNewBtn { get; set; }
//        //Add Language
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")]
//        private IWebElement addLanguage { get; set; }
//        //Click Language Level
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")]
//        private IWebElement clickLanguageLv { get; set; }
//        //Click Language Tab
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[1]")]
//        private IWebElement selectLanguageLv { get; set; }
//        //Click Language Tab
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")]
//        private IWebElement addBtn { get; set; }

//        #endregion

//        [Given(@"I clicked on the Langauge tab under Profile page")]
//        public void GivenIClickedOnTheLangaugeTabUnderProfilePage()
//        {
//            //Wait
//            Thread.Sleep(1000);

//            // Click on Profile tab
//            languageTab.Click();
//        }

//        [When(@"I add new languages (.*)")]
//        public void WhenIAddNewLanguages(string language)
//        {
//            //Click on Add New button
//            addNewBtn.Click();

//            //Add Language
//            addLanguage.SendKeys(language);

//            //Click on Language Level
//            clickLanguageLv.Click();

//            //Choose the language level
//            selectLanguageLv.Click();

//            //Click on Add button
//            addBtn.Click();
//        }

//        [Then(@"those languages (.*) should be displayed on my listings")]
//        public void ThenThoseLanguagesShouldBeDisplayedOnMyListings(string language)
//        {
//            try
//            {
//                //Start the Reports
//                CommonMethods.ExtentReports();
//                Thread.Sleep(1000);
//                CommonMethods.test = CommonMethods.extent.StartTest("Add languages");

//                Thread.Sleep(1000);
//                for (int i = 1; i <= 100; i++)
//                {
//                    string ExpectedName = language;
//                    string ActualName = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
//                    Thread.Sleep(1000);
//                    if (ExpectedName == ActualName)
//                    {
//                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added languages Successfully");
//                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguagesAdded");
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
