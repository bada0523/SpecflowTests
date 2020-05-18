using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
//using SeleniumExtras.WaitHelpers;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static NUnit.Core.NUnitFramework;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class ChangePassword
    {

        #region Initialize Web Elements

        IWebElement visibleDropdown = Driver.driver.FindElement(By.XPath("//span[contains(@class,'item ui dropdown link')]"));
        IWebElement changePassBtn = Driver.driver.FindElement(By.XPath("//a[contains(text(),'Change Password')]"));
        
        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        Actions action = new Actions(Driver.driver);
        #endregion

        [Given(@"I clicked Hi username dropdown")]
        public void GivenIClickedHiUsernameDropdown()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(@class,'item ui dropdown link')]")));
            //Move cursor on the dropdown to be visible
            action.MoveToElement(visibleDropdown).Perform();
        }

        [Given(@"I clicked change password button")]
        public void GivenIClickedChangePasswordButton()
        {
            //Click change password button
            wait.Until(ExpectedConditions.ElementToBeClickable(changePassBtn));
            changePassBtn.Click();

        }

        [When(@"I enter new password, current password and confirm password correctly")]
        public void WhenIEnterNewPasswordCurrentPasswordAndConfirmPasswordCorrectly()
        {
            IWebElement currentPass = Driver.driver.FindElement(By.XPath("//input[contains(@name,'oldPassword')]"));
            IWebElement newPass = Driver.driver.FindElement(By.XPath("//input[contains(@name,'newPassword')]"));
            IWebElement confirmPass = Driver.driver.FindElement(By.XPath("//input[contains(@name,'confirmPassword')]"));
            IWebElement saveBtn = Driver.driver.FindElement(By.XPath("(//button[contains(.,'Save')])[2]"));

            //Enter current password, new password and confirm password
            wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[4]/div/div[2]/form/div[1]/input")));
            currentPass.SendKeys("Test@123");
            newPass.SendKeys("Test@1234");
            confirmPass.SendKeys("Test@1234");
            saveBtn.Click();
        }

        [Then(@"the password should be changed as new password I have entered")]
        public void ThenThePasswordShouldBeChangedAsNewPasswordIHaveEntered()
        {
            IWebElement validateChanged = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner'][contains(.,'Password Changed Successfully')]"));

            try
            {
                //Start the Reports
                Thread.Sleep(2000);
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Change password");

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ns-box-inner'][contains(.,'Password Changed Successfully')]")));
                string expectedMsg = "Password Changed Successfully";
                string actualMsg = validateChanged.Text;
                Thread.Sleep(1000);

                if(expectedMsg == actualMsg)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Skills Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillsAdded");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
    }
}
