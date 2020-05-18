using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
    public class AddLanguages
    {

        public AddLanguages()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click Language Tab
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Languages')]")]
        private IWebElement languageTab { get; set; }
        //Click AddNew Button
        [FindsBy(How = How.XPath, Using = "(//div[contains(.,'Add New')])[11]")]
        private IWebElement addNewBtn { get; set; }
        //Add Language
        [FindsBy(How = How.XPath, Using = "//input[@name='name']")]
        private IWebElement addLanguage { get; set; }
        //Click Language Level
        [FindsBy(How = How.XPath, Using = "//select[@name='level']")]
        private IWebElement clickLanguageLv { get; set; }
        //Click Language Tab
        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'Basic')]")]
        private IWebElement selectLanguageLv { get; set; }
        //Click Language Tab
        [FindsBy(How = How.XPath, Using = "(//input[@type='button'])[1]")]
        private IWebElement addBtn { get; set; }
        #endregion

        [Given(@"I clicked on the Langauge tab under Profile page")]
        public void GivenIClickedOnTheLangaugeTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1000);

            // Click on Profile tab
            languageTab.Click();
        }

        [When(@"I add new languages (.*)")]
        public void WhenIAddNewLanguages(string language)
        {
            //Click on Add New button
            addNewBtn.Click();

            //Add Language
            addLanguage.SendKeys(language);

            //Click on Language Level
            clickLanguageLv.Click();
            Thread.Sleep(1000);
            //Choose the language level
            selectLanguageLv.Click();
            Thread.Sleep(1000);
            //Click on Add button
            addBtn.Click();
            Thread.Sleep(1000);
        }

        [Then(@"those languages (.*) should be displayed on my listings")]
        public void ThenThoseLanguagesShouldBeDisplayedOnMyListings(string language)
        {
            int rowCount = Driver.driver.FindElements(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.active.tooltip-target > div > div.twelve.wide.column.scrollTable > div > table > thead > tr")).Count;

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add languages");

                Thread.Sleep(1000);
                for (int i = 1; i <= rowCount; i++)
                {
                    string ExpectedName = language;
                    string ActualName = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(1000);
                    if (ExpectedName == ActualName)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added languages Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguagesAdded");
                        break;
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
