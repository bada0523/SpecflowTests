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
    public class DeleteEducation
    {
        public DeleteEducation()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click on language tab
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'ui top')]//a)[3]")]
        private IWebElement eduTab { get; set; }
        //actual name for comparison
        private string actualName { get; set; }
        //expected name for comparison
        private string expectedName { get; set; }
        //variable for wait
        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"the education have added should be displayed on education listings")]
        public void GivenTheEducationHaveAddedShouldBeDisplayedOnEducationListings()
        {
            //wait for education tab is visible
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//div[contains(@class,'ui top')]//a)[3]")));
            //click on education tab
            eduTab.Click();
        }

        [When(@"I click the X icon on education listings")]
        public void WhenIClickTheXIconOnEducationListings()
        {
            IWebElement tableElement = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));
            IList<IWebElement> rowTD;
            //distingush specific keyword is searchable or not
            Boolean result = false;
            int j = 1;

            //get data from table
            foreach (IWebElement row in tableRow)
            {
                //get td data from each row
                rowTD = row.FindElements(By.TagName("td"));
                //searching specific keyword as MVP Studio
                if (rowTD[1].Text.Equals("Edited College"))
                {
                    IWebElement deleteIcon = Driver.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[4]/div[1]/div[2]/div[1]/table[1]/tbody[" + j + "]/tr[1]/td[6]/span[2]/i[1]"));

                    //Click on delete icon
                    deleteIcon.Click();
                    result = true;
                }
                j++;
            }
            Thread.Sleep(1000);
            if (result == false)
            {
                Console.WriteLine("MVP Studio does not exist on Educations");
            }
        }

        [Then(@"that education should be deleted from my listings")]
        public void ThenThatEducationShouldBeDeletedFromMyListings()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")));
            //compare with actual result and expected result
            actualName = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")).Text;
            expectedName = "Education entry successfully removed";

            //if true test is success
            if (expectedName == actualName)
            {
                Console.WriteLine("Test Successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Education Deleted");
            }
            //if false test is failed
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
