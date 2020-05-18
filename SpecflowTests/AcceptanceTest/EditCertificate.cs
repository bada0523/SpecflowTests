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
    public class EditCertificate
    {
        public EditCertificate()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region  Initialize Web Elements 
        //Click on Certifications Tab
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'ui top')]//a)[4]")]
        private IWebElement certiTab { get; set; }
        //Edit Certificate Name
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Certificate or Award']")]
        private IWebElement editCertName { get; set; }

        //Edit From
        [FindsBy(How = How.XPath, Using = "//input[@class='received-from capitalize']")]
        private IWebElement editFrom { get; set; }

        //Click on Year of Certification
        [FindsBy(How = How.Name, Using = "certificationYear")]
        private IWebElement certYr { get; set; }
        //Click on Update Button
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        private IWebElement updateBtn { get; set; }
        //actual name for comparison
        string actualName { get; set; }
        //expected name for comparison
        string expectedName { get; set; }

        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"The certificate have added on certificate listings")]
        public void GivenTheCertificateHaveAddedOnCertificateListings()
        {
            //wait for education tab is visible
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//div[contains(@class,'ui top')]//a)[3]")));
            //click on education tab
            certiTab.Click();
        }

        [When(@"I edit a certificate")]
        public void WhenIEditACertificate()
        {
            IWebElement tableElement = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));
            IList<IWebElement> rowTD;
            Boolean result = false;
            int j = 1;

            foreach (IWebElement row in tableRow)
            {

                rowTD = row.FindElements(By.TagName("td"));
                if (rowTD[0].Text.Equals("Foundation Certificate in Software Testing"))
                {
                    IWebElement editIcon = Driver.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[5]/div[1]/div[2]/div[1]/table[1]/tbody[" + j + "]/tr[1]/td[4]/span[1]/i[1]"));

                    editIcon.Click();
                    Thread.Sleep(1000);
                    editCertName.Clear();
                    editCertName.SendKeys("Edited Award");
                    editFrom.Clear();
                    editFrom.SendKeys("MVP Studio");
                    certYr.Click();
                    IWebElement selectCertYr = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + j + "]/tr/td/div/div/div[3]/select/option[2]"));
                    selectCertYr.Click();
                    updateBtn.Click();
                    result = true;
                    Thread.Sleep(1500);
                }
                j++;
            }
            Thread.Sleep(1000);
            if (result == false)
            {
                Console.WriteLine("Add Award does not exist on Certificates");
            }
        }

        [Then(@"that updated certification should be displayed on my listings")]
        public void ThenThatUpdatedCertificationShouldBeDisplayedOnMyListings()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")));
            //compare with actual result and expected result
            actualName = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box ns-growl')]//div[1]")).Text;
            expectedName = "Edited Award has been updated to your certification";

            //if true test is success
            if (expectedName == actualName)
            {
                Console.WriteLine("Test Successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Certificate Edited");
            }
            //if false test is failed
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
