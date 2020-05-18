using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class DeleteLanguage
    {
        public DeleteLanguage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click on language tab
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'ui top')]//a[1]")]
        private IWebElement langTab { get; set; }
        //actual name for comparison
        private string actualName { get; set; }
        //expected name for comparison
        private string expectedName { get; set; }
        //variable for wait
        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"the language have added should be displayed on my listings")]
        public void GivenTheLanguageHaveAddedShouldBeDisplayedOnMyListings()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ui top')]//a[1]")));
            langTab.Click();
        }
        
        [When(@"I click the X icon on my language listings")]
        public void WhenIClickTheXIconOnMyLanguageListings()
        {
            IWebElement tableElement = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));
            IList<IWebElement> rowTD;
            Boolean result = false;
            int j = 1;

            foreach (IWebElement row in tableRow)
            {

                rowTD = row.FindElements(By.TagName("td"));
                if (rowTD[0].Text.Equals("editLang"))
                {
                    IWebElement deleteIcon = Driver.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[" + j + "]/tr[1]/td[3]/span[2]/i[1]"));

                    deleteIcon.Click();
                    result = true;
                    Thread.Sleep(1500);
                }
                j++;
            }
            if (result == false)
            {
                Console.WriteLine("editLang does not exist on Language");
            }
        }
        
        [Then(@"that language should be deleted from my listings")]
        public void ThenThatLanguageShouldBeDeletedFromMyListings()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")));
            actualName = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")).Text;
            expectedName = "editLang has been deleted from your languages";
            if (expectedName == actualName)
            {
                Console.WriteLine("Test Successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Language deleted");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
