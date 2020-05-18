using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddCertifications
    {

        public AddCertifications()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region  Initialize Web Elements
        //Certification Tab
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Certifications')]")]
        private IWebElement certTab { get; set; }
        //Add new Button
        [FindsBy(How = How.XPath, Using = "(//div[contains(.,'Add New')])[26]")]
        private IWebElement certAddNewBtn { get; set; }
        //Certificate or Award field
        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'certification-award capitalize')]")]
        private IWebElement addCertName { get; set; }
        //Certificated From field
        [FindsBy(How = How.XPath, Using = "//input[@name='certificationFrom']")]
        private IWebElement addCertFrom { get; set; }
        //Click Year dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='certificationYear']")]
        private IWebElement clickCertYear { get; set; }
        //Choose Year dropdown
        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'2018')]")]
        private IWebElement selectCertYear { get; set; }
        //Click Add Button
        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'ui teal button ')]")]
        private IWebElement addBtn { get; set; }


        #endregion


        [Given(@"I clicked on the Certifications tab under profile page")]
        public void GivenIClickedOnTheCertificationsTabUnderProfilePage()
        {
            //Wait 
            Thread.Sleep(1000);
            // Click on Profile tab
            certTab.Click();
        }

        [When(@"I add new certification (.*) and (.*)")]
        public void WhenIAddNewCertificationAnd(string certification, string from)
        {
            //Click on a Add new button
            certAddNewBtn.Click();
            //Add Certificate or Award
            addCertName.SendKeys(certification);
            //Add Certificated From
            addCertFrom.SendKeys(from);
            //Click on Year
            clickCertYear.Click();
            //Choose the Year
            selectCertYear.Click();
            //Click on a Add button
            addBtn.Click();
        }

        [Then(@"those certifications (.*) and (.*) should be displayed on my listings")]
        public void ThenThoseCertificationsAndShouldBeDisplayedOnMyListings(string certificaion, string from)
        {
            int rowCount = Driver.driver.FindElements(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div.row > div.twelve.wide.column.scrollTable > div > table > thead > tr")).Count;

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add certifications");

                Thread.Sleep(1000);
                for (int i = 1; i <= rowCount; i++)
                {
                    string ExpectedName = certificaion;
                    string ActualName = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(1000);
                    if (ExpectedName == ActualName)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added certifications Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "certificationsAdded");
                        break;
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
