using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SetHours
    {
        public SetHours()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click Hours edit icon
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'right floated')]//i)[2]")]
        private IWebElement editIcon { get; set; }
        //Click Hours
        [FindsBy(How = How.Name, Using = "availabiltyHour")]
        private IWebElement hours { get; set; }
        //Select Hours
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[4]")]
        private IWebElement setHours { get; set; }
        //expected name
        private string expectedName { get; set; }
        //actual name
        private string actualName { get; set; }
        //Wait
        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"I have clicked Hours edit icons")]
        public void GivenIHaveClickedHoursEditIcons()
        {
            //wait until edit icon is visible
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//div[contains(@class,'right floated')]//i)[2]")));
            //click on edit icon
            editIcon.Click();
        }
        
        [When(@"I select Hours as As Needed")]
        public void WhenISelectHoursAsAsNeeded()
        {
            //click on dropdown
            hours.Click();
            //select hours
            setHours.Click();
        }
        
        [Then(@"Hours should be set as As Needed")]
        public void ThenHoursShouldBeSetAsAsNeeded()
        {
            //wait until successful message is appeared
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")));
            //compare with actual result and expected result
            actualName = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")).Text;
            expectedName = "Availability updated";

            //if true test is success
            if (expectedName == actualName)
            {
                //successful comment
                Console.WriteLine("Test Successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Set Availability successfully");
            }
            //if false test is failed
            else
            {
                //fail comment
                Console.WriteLine("Test Failed");
            }
        }
    }
}
