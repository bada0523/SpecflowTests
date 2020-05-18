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
    public class SetEarnTarget
    {
        public SetEarnTarget()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click Earn Target edit icon
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'right floated')]//i)[3]")]
        private IWebElement editIcon { get; set; }
        //Click Earn Target
        [FindsBy(How = How.Name, Using = "availabiltyTarget")]
        private IWebElement earnTarget { get; set; }
        //Select Earn Target
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[4]")]
        private IWebElement setEarnTarget { get; set; }
        //expected name
        private string expectedName { get; set; }
        //actual name
        private string actualName { get; set; }
        //Wait
        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));

        #endregion

        [Given(@"I have clicked Earn Target edit icons")]
        public void GivenIHaveClickedEarnTargetEditIcons()
        {
            //wait until edit icon is visible
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//div[contains(@class,'right floated')]//i)[3]")));
            //click edit icon
            editIcon.Click();
        }
        
        [When(@"I select Earn Target as More than 1000 per month")]
        public void WhenISelectEarnTargetAsMoreThanPerMonth()
        {
            //click on dropdown
            earnTarget.Click();
            //select More than 1000 per month
            setEarnTarget.Click();
        }
        
        [Then(@"Earn Target should be set as More than 1000 per month")]
        public void ThenEarnTargetShouldBeSetAsMoreThanPerMonth()
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
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Set Earn Target successfully");
            }
            //if false test is failed
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
