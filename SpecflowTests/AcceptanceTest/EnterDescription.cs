using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class EnterDescription
    {
        public EnterDescription()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Description Edit Pencil Icon
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/h3[1]/span[1]/i[1]")]
        private IWebElement addDescription { get; set; }

        //Description textarea
        [FindsBy(How = How.XPath, Using = "//div[@class='field  ']//textarea[1]")]
        private IWebElement typeDescription { get; set; }

        //Save Button
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'ui twelve')]//button[1]")]
        private IWebElement saveDesc { get; set; }
        //Expected name
        private string expectedName { get; set; }
        //Actual name
        private string actualName { get; set; }
        //Wait
        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));

        #endregion


        [Given(@"I clicked the pencil icon next to description under profile page")]
        public void GivenIClickedThePencilIconNextToDescriptionUnderProfilePage()
        {
            //wait until pencil icon is visible
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/h3[1]/span[1]/i[1]")));
            //click on edit icon
            addDescription.Click();
        }
        
        [When(@"I write about my information")]
        public void WhenIWriteAboutMyInformation()
        {
            //wait until open textbox
            Thread.Sleep(1000);
            //remove all on textbox before enter the description
            typeDescription.Clear();
            Thread.Sleep(1000);
            //enter the description
            typeDescription.SendKeys("Typing a description successfully");
            //click on save button
            saveDesc.Click();
        }
        
        [Then(@"that information should be displayed on description section")]
        public void ThenThatInformationShouldBeDisplayedOnDescriptionSection()
        {
            //wait until successful message is appeared
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")));
            //compare with actual result and expected result
            actualName = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")).Text;
            expectedName = "Description has been saved successfully";

            //if true test is success
            if (expectedName == actualName)
            {
                Console.WriteLine("Test Successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Enter the description successfully");
            }
            //if false test is failed
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
