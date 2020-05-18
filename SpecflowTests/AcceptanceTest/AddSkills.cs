using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddSkills
    {
        public AddSkills()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click SkillTab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")]
        private IWebElement skillTab { get; set; }
        //Click AddNew Button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement addNewBtn { get; set; }
        //Add Skill
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")]
        private IWebElement addSkill { get; set; }
        //Click SKill Level
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select")]
        private IWebElement clickSkillLv { get; set; }
        //Select Skill Level
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[2]")]
        private IWebElement selectSkillLv { get; set; }
        //Click Add Button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")]
        private IWebElement addBtn { get; set; }
        #endregion

        [Given(@"I clicked on the Skills tab under profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {
            // Click on Profile tab
            Thread.Sleep(1500);
            skillTab.Click();
        }

        [When(@"I add new skills (.*)")]
        public void WhenIAddNewSkills(string skill)
        {
            //Click on a Add new button
            addNewBtn.Click();
            //Add Skill
            addSkill.SendKeys(skill);
            //Click on Skill level
            Thread.Sleep(1000);
            clickSkillLv.Click();
            //Select the skill level
            Thread.Sleep(1000);
            selectSkillLv.Click();
            //Click on a Add button
            addBtn.Click();
        }

        [Then(@"those skills (.*) should be displayed on my listings")]
        public void ThenThoseSkillsShouldBeDisplayedOnMyListings(string skill)
        {
            int rowCount = Driver.driver.FindElements(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div > div.twelve.wide.column.scrollTable > div > table > thead > tr")).Count;

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add skills");

                Thread.Sleep(1000);
                for (int i = 1; i <= rowCount; i++)
                {
                    string ExpectedName = skill;
                    string ActualName = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(1000);
                    if (ExpectedName == ActualName)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Skills Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillsAdded");
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
