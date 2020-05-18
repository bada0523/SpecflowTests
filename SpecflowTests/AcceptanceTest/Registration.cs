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
    public class Registration
    {
        public Registration()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click Log out
        [FindsBy(How = How.XPath, Using = "//button[text()='Sign Out']")]
        private IWebElement logout { get; set; }
        //Click join button
        [FindsBy(How = How.XPath, Using = "//button[text()='Join']")]
        private IWebElement joinBtn { get; set; }
        //Enter first name
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='First name']")]
        private IWebElement firstName { get; set; }
        //Enter last name
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Last name']")]
        private IWebElement lastName { get; set; }
        //Enter Email
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email address']")]
        private IWebElement email { get; set; }
        //enter new password
        [FindsBy(How = How.XPath, Using = "(//input[@type='password'])[1]")]
        private IWebElement pwd { get; set; }
        //Enter confirm password
        [FindsBy(How = How.XPath, Using = "(//input[@type='password'])[2]")]
        private IWebElement confirmPwd { get; set; }
        //Click on checkbox for terms
        [FindsBy(How = How.XPath, Using = "//div[@class='ui checkbox ']//input[1]")]
        private IWebElement ckTerm { get; set; }
        //Click on Join button to confirm registration form
        [FindsBy(How = How.XPath, Using = "(//div[@class='field']//div)[2]")]
        private IWebElement okBtn { get; set; }
        //actual name for comparison
        string actualName { get; set; }
        //expected name for comparison
        string expectedName { get; set; }

        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"I clicked join button")]
        public void GivenIClickedJoinButton()
        {
            //log out old account
            logout.Click();
            //wait for Join button is visible
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[text()='Join']")));
            //click join button
            joinBtn.Click();

        }
        
        [When(@"I enter a credential")]
        public void WhenIEnterACredential()
        {
            //enter first name
            firstName.SendKeys("Harris");
            //enter last name
            lastName.SendKeys("Jung");
            //enter email
            email.SendKeys("harristest91@gmail.com");
            //enter password
            pwd.SendKeys("Test@123");
            //enter confirm password
            confirmPwd.SendKeys("Test@123");
            //tick the checkbox
            ckTerm.Click();
            //click on join button to confirm registartion form
            okBtn.Click();

        }
        
        [Then(@"that account should be registered")]
        public void ThenThatAccountShouldBeRegistered()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")));
            //compare with actual result and expected result
            actualName = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")).Text;
            expectedName = "Registration successful";

            //if true test is success
            if (expectedName == actualName)
            {
                Console.WriteLine("Test Successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Registered");
            }
            //if false test is failed
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
