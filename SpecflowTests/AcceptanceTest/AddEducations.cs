using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddEducations
    {
        public AddEducations()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click Education Tab
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'ui top')]//a)[3]")]
        private IWebElement eduTab { get; set; }
        //Click Add New Button
        [FindsBy(How = How.XPath, Using = "(//div[contains(.,'Add New')])[21]")]
        private IWebElement addNewBtn { get; set; }
        //CollegeName
        [FindsBy(How = How.XPath, Using = "(//input[@type='text'])[4]")]
        private IWebElement collegeName { get; set; }
        //Click Country
        [FindsBy(How = How.XPath, Using = "//select[@name='country']")]
        private IWebElement clickCountry { get; set; }
        //Select Country
        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'New Zealand')]")]
        private IWebElement selectCountry { get; set; }
        //Click Title
        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'title')]")]
        private IWebElement clickTitle { get; set; }
        //Select Title
        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'Associate')]")]
        private IWebElement selectTitle { get; set; }
        //Degree
        [FindsBy(How = How.XPath, Using = "//input[@name='degree']")]
        private IWebElement addDegree { get; set; }
        //Click Year
        [FindsBy(How = How.XPath, Using = "//select[@name='yearOfGraduation']")]
        private IWebElement clickYear { get; set; }
        //Select Year
        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'2019')]")]
        private IWebElement selectYear { get; set; }
        //Click Add Button
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement clickAddBtn { get; set; }

        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"I clicked on the Educations tab under profile page")]
        public void GivenIClickedOnTheEducationsTabUnderProfilePage()
        {
            //wait for education tab is visible
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//div[contains(@class,'ui top')]//a)[3]")));
            //click on education tab
            eduTab.Click();
        }

        [When(@"I add new educations (.*) and (.*)")]
        public void WhenIAddNewEducationsAnd(string education, string degree)
        {
            //Click on a Add new button
            addNewBtn.Click();
            //Add College/University name
            collegeName.SendKeys(education);
            //Click on Country of College/University
            clickCountry.Click();
            //Choose the Country
            selectCountry.Click();
            //Click on Title
            clickTitle.Click();
            //Choose the Title
            selectTitle.Click();

            //Add Degree
            addDegree.SendKeys(degree);
            //Choose Year of graduation
            clickYear.Click();
            selectYear.Click();
            //Click on a Add button
            clickAddBtn.Click();
        }

        [Then(@"those educations (.*) and (.*) should be displayed on my listings")]
        public void ThenThoseEducationsAndShouldBeDisplayedOnMyListings(string education, string degree)
        {
            int rowCount = Driver.driver.FindElements(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div > div.twelve.wide.column.scrollTable > div > table > thead > tr")).Count;

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add educations");

                Thread.Sleep(1000);
                for (int i = 1; i <= rowCount; i++)
                {
                    string ExpectedName = education;
                    string ActualName = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]")).Text;
                    Thread.Sleep(1000);
                    if (ExpectedName == ActualName)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a educations Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationsAdded");
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
