using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class EditLanguage
    {
        public EditLanguage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click Availability edit icon
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'ui top')]//a[1]")]
        private IWebElement langTab { get; set; }
        //Click Hours edit icon
        string actualName { get; set; }
        string expectedName { get; set; }

        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"The language should be visible on language list which I want to edit under Profile page")]
        public void TheLanguageShouldBeVisibleOnLanguageListWhichIWantToEditUnderProfilePage()
        {
            //move to language tab for seeing language list
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ui top')]//a[1]")));
            langTab.Click();
        }
        
        [When(@"I edit a language")]
        public void WhenIEditALanguage()
        {
            //count table rows
            int rowCount = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody")).Count;

            for (int i = 1; i <= rowCount; i++)
            {
                //looking for a specific name as Chinese
                expectedName = "Chinese";
                actualName = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                if (expectedName == actualName)
                {
                    //Click on Pencil Icon
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();
                    //Clear on Language Name Field
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input")).Clear();
                    //Enter on Language Name Field
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input")).SendKeys("editLang");
                    Thread.Sleep(1000);
                    //Click on Language Level Dropdown
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody["+ i +"]/tr/td/div/div[2]/select")).Click();
                    Thread.Sleep(1000);
                    //Select on Language Level Option
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[2]/select/option[5]")).Click();
                    Thread.Sleep(1000);
                    //Click on Update Button
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody["+ i +"]/tr/td/div/span/input[1]")).Click();
                    break;
                }
                else
                {

                }

            }

        }
        
        [Then(@"that updated language should be displayed on my listings")]
        public void ThenThatUpdatedLanguageShouldBeDisplayedOnMyListings()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")));
            //compare with actual result and expected result
            actualName = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")).Text;
            expectedName = "editLang has been updated to your languages";
            
            //if true test is success
            if (expectedName == actualName)
            {
                Console.WriteLine("Test Successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Language edited");
            }
            //if false test is failed
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
