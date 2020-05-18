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
    public class SetAvailability
    {
        public SetAvailability()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click Availability edit icon
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'right floated')]//i)[1]")]
        private IWebElement editIcon { get; set; }
        //Click Availability
        [FindsBy(How = How.Name, Using = "availabiltyType")]
        private IWebElement availability { get; set; }
        //Select Availability
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[3]")]
        private IWebElement setAvailability { get; set; }
        //expected name
        private string expectedName { get; set; }
        //actual name
        private string actualName { get; set; }
        //Wait
        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"I have clicked Availability edit icons")]
        public void GivenIHaveClickedAvailabilityEditIcons()
        {
            //wait until edit icon is visible
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//div[contains(@class,'right floated')]//i)[1]")));
            //click edit icon
            editIcon.Click();
        }
        
        [When(@"I select Availability as Full Time")]
        public void WhenISelectAvailabilityAsFullTime()
        {
            //click on dropdown
            availability.Click();
            //select More than 1000 per month
            setAvailability.Click();
        }
        
        [Then(@"Availability should be set as Full Time")]
        public void ThenAvailabilityShouldBeSetAsFullTime()
        {
            //wait until successful message is appeared
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")));
            //compare with actual result and expected result
            actualName = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")).Text;
            expectedName = "Availability updated";

            //if true test is success
            if (expectedName == actualName)
            {
                Console.WriteLine("Test Successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Set Availability successfully");
            }
            //if false test is failed
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
