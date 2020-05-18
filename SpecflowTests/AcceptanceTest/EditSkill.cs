using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class EditSkill
    {
        public EditSkill()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click Availability edit icon
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'ui top')]//a)[2]")]
        private IWebElement skillTab { get; set; }
        //Edit Skill name
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Skill']")]
        private IWebElement editSkill { get; set; }
        //Click on Language, Skill Level
        [FindsBy(How = How.Name, Using = "level")]
        private IWebElement editLevel { get; set; }
        //Click on Update Button
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        private IWebElement updateBtn { get; set; }
        //actual name for comparison
        string actualName { get; set; }
        //expected name for comparison
        string expectedName { get; set; }

        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion


        [Given(@"The skill have added should be displayed on skill list")]
        public void GivenTheSkillHaveAddedShouldBeDisplayedOnSkillList()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//div[contains(@class,'ui top')]//a)[2]")));
            skillTab.Click();
        }
        
        [When(@"I edit a skill")]
        public void WhenIEditASkill()
        {
            IWebElement tableElement = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));
            IList<IWebElement> rowTD;
            Boolean result = false;
            int i = 1;
            int j = 4;

            foreach (IWebElement row in tableRow)
            {
                rowTD = row.FindElements(By.TagName("td"));

                if (rowTD[0].Text.Equals("Automation Testing"))
                {
                    IWebElement editIcon = Driver.driver.FindElement(By.XPath("(//i[contains(@class,'outline write')])[" + j + "]"));

                    editIcon.Click();
                    Thread.Sleep(1000);
                    editSkill.Clear();
                    editSkill.SendKeys("Selenium");
                    editLevel.Click();
                    IWebElement selectSkillLv = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[2]/select/option[4]"));
                    selectSkillLv.Click();
                    Thread.Sleep(1000);
                    updateBtn.Click();
                    result = true;
                    Thread.Sleep(1500);
                }
                i++;
                j++;
            }
            Thread.Sleep(1000);
            if (result == false)
            {
                Console.WriteLine("Automation Testing skill does not exist on Skills");
            }
        }
        
        [Then(@"that updated skill should be displayed on my listings")]
        public void ThenThatUpdatedSkillShouldBeDisplayedOnMyListings()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")));
            //compare with actual result and expected result
            actualName = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")).Text;
            expectedName = "Selenium has been updated to your skills";

            //if true test is success
            if (expectedName == actualName)
            {
                Console.WriteLine("Test Successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill edited");
            }
            //if false test is failed
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
