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
    public class DeleteCertificate
    {
        public DeleteCertificate()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region  Initialize Web Elements 
        //Click on Certifications Tab
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'ui top')]//a)[4]")]
        private IWebElement certiTab { get; set; }
        //actual name for comparison
        string actualName { get; set; }
        //expected name for comparison
        string expectedName { get; set; }

        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"the certification have added should be displayed on certificate listings")]
        public void GivenTheCertificationHaveAddedShouldBeDisplayedOnCertificateListings()
        {
            //wait for education tab is visible
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//div[contains(@class,'ui top')]//a)[3]")));
            //click on education tab
            certiTab.Click();
        }

        [When(@"I click the X icon on my listings")]
        public void WhenIClickTheXIconOnMyListings()
        {
            IWebElement tableElement = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));
            IList<IWebElement> rowTD;
            Boolean result = false;
            int j = 1;

            //get data from each row of table
            foreach (IWebElement row in tableRow)
            {
                //get td data from each row
                rowTD = row.FindElements(By.TagName("td"));
                //searching a specific keyword as Edited Award
                if (rowTD[0].Text.Equals("Edited Award"))
                {
                    IWebElement deleteIcon = Driver.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[5]/div[1]/div[2]/div[1]/table[1]/tbody[" + j + "]/tr[1]/td[4]/span[2]/i[1]"));

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
                Console.WriteLine("Edited Award does not exist on Certificates");
            }
        }

        [Then(@"that certification should be deleted from my listings")]
        public void ThenThatCertificationShouldBeDeletedFromMyListings()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")));
            //compare with actual result and expected result
            actualName = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")).Text;
            expectedName = "Edited Award has been deleted from your certification";

            //if true test is success
            if (expectedName == actualName)
            {
                Console.WriteLine("Test Successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Certificate Deleted");
            }
            //if false test is failed
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
