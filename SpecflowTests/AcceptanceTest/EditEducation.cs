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
    public class EditEducation
    {
        public EditEducation()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click Availability edit icon
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'ui top')]//a)[3]")]
        private IWebElement eduTab { get; set; }
        //Edit College name
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='College/University Name']")]
        private IWebElement editCollege { get; set; }

        //Click on Country
        [FindsBy(How = How.Name, Using = "country")]
        private IWebElement editCountry { get; set; }

        //Click on Title
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement editTitle { get; set; }

        //Edit Degree name
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Degree']")]
        private IWebElement editDegree { get; set; }

        //Click on Year of Graduation
        [FindsBy(How = How.Name, Using = "yearOfGraduation")]
        private IWebElement yrOfGraduation { get; set; }
        //Click on Update Button
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        private IWebElement updateBtn { get; set; }
        //actual name for comparison
        string actualName { get; set; }
        //expected name for comparison
        string expectedName { get; set; }

        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"The education have added should be displayed on education listings")]
        public void GivenTheEducationHaveAddedShouldBeDisplayedOnEducationListings()
        {
            //wait for education tab is visible
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//div[contains(@class,'ui top')]//a)[3]")));
            //click on education tab
            eduTab.Click();
        }
        
        [When(@"I edit a education")]
        public void WhenIEditAEducation()
        {
            IWebElement tableElement = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));
            IList<IWebElement> rowTD;
            Boolean result = false;
            int j = 1;

            foreach (IWebElement row in tableRow)
            {

                rowTD = row.FindElements(By.TagName("td"));
                if (rowTD[1].Text.Equals("MVP Studio"))
                {
                    IWebElement editIcon = Driver.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[4]/div[1]/div[2]/div[1]/table[1]/tbody[" + j + "]/tr[1]/td[6]/span[1]/i[1]"));

                    editIcon.Click();
                    Thread.Sleep(1000);
                    editCollege.Clear();
                    editCollege.SendKeys("Edited College");
                    editCountry.Click();
                    IWebElement selectCountry = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + j + "]/tr/td/div[1]/div[2]/select/option[102]"));
                    selectCountry.Click();
                    editTitle.Click();
                    IWebElement selectTitle = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + j + "]/tr/td/div[2]/div[1]/select/option[3]"));
                    selectTitle.Click();
                    editDegree.Clear();
                    editDegree.SendKeys("Edited Degree");
                    yrOfGraduation.Click();
                    IWebElement selectYr = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + j + "]/tr/td/div[2]/div[3]/select/option[2]"));
                    selectYr.Click();
                    Thread.Sleep(1000);
                    updateBtn.Click();
                    result = true;
                }
                j++;
            }
            Thread.Sleep(1000);
            if (result == false)
            {
                Console.WriteLine("MVP Studio does not exist on Education");
            }
        }
        
        [Then(@"that updated education should be displayed on my listings")]
        public void ThenThatUpdatedEducationShouldBeDisplayedOnMyListings()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")));
            //compare with actual result and expected result
            actualName = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")).Text;
            expectedName = "Education as been updated";

            //if true test is success
            if (expectedName == actualName)
            {
                Console.WriteLine("Test Successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Education edited");
            }
            //if false test is failed
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
