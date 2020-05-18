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
    public class DeleteSkill
    {
        public DeleteSkill()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click on language tab
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'ui top')]//a)[2]")]
        private IWebElement skillTab { get; set; }
        //actual name for comparison
        private string actualName { get; set; }
        //expected name for comparison
        private string expectedName { get; set; }
        //variable for wait
        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"the skill which I have added should be displayed on skill listings")]
        public void GivenTheSkillWhichIHaveAddedShouldBeDisplayedOnSkillListings()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//div[contains(@class,'ui top')]//a)[2]")));
            skillTab.Click();
        }

        [When(@"I click the X icon on skill listings")]
        public void WhenIClickTheXIconOnSkillListings()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//table[contains(@class,'ui fixed')]//th)[4]")));
            IWebElement tableElement = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));
            IList<IWebElement> rowTD;
            Boolean result = false;
            int j = 1;

            //get data from each row of table
            foreach (IWebElement row in tableRow)
            {
                //get td data from rows
                rowTD = row.FindElements(By.TagName("td"));
                //Searching for a specific keyword as Selenium
                if (rowTD[0].Text.Equals("Selenium"))
                {
                    IWebElement deleteIcon = Driver.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + j + "]/tr[1]/td[3]/span[2]/i[1]"));

                    //Click on delete icon
                    deleteIcon.Click();
                    result = true;
                    Thread.Sleep(1500);
                }
                j++;
            }
            Thread.Sleep(1000);
            if (result == false)
            {
                Console.WriteLine("Selenium does not exist on Skill");
            }
        }

        [Then(@"that skill should be deleted from my listings")]
        public void ThenThatSkillShouldBeDeletedFromMyListings()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")));
            //compare with actual result and expected result
            actualName = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")).Text;
            expectedName = "Selenium has been deleted";

            //if true test is success
            if (expectedName == actualName)
            {
                Console.WriteLine("Test Successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill Deleted");
            }
            //if false test is failed
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
