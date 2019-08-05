//using OpenQA.Selenium;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.PageObjects;
//using SpecflowPages;
//using System;
//using System.Threading;
//using TechTalk.SpecFlow;

//namespace SpecflowTests.AcceptanceTest
//{
//    [Binding]
//    //Please add : Utils.Start behind of class name like that public class LookIntoMyInfoBySearchingSkillName : Utils.Start before running
//    public class ChangePassword : Utils.Start
//    {

//        public ChangePassword()
//        {
//            PageFactory.InitElements(Driver.driver, this);
//        }

//        #region Initialize Web Elements
//        //Move cursur on the dropdown to be visible
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
//        private IWebElement visibleDropdown { get; set; }
//        //Click Change Password Button
//        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]")]
//        private IWebElement changePassBtn { get; set; }
//        //Enter Current Password
//        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[2]/form/div[1]/input")]
//        private IWebElement currentPass { get; set; }
//        //Enter New Password
//        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[2]/form/div[2]/input")]
//        private IWebElement newPass { get; set; }
//        //Enter Confirm Password
//        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[2]/form/div[3]/input")]
//        private IWebElement confirmPass { get; set; }
//        //Click Save Button
//        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[2]/form/div[4]/button")]
//        private IWebElement saveBtn { get; set; }
//        #endregion

//        [Given(@"I clicked Hi username dropdown")]
//        public void GivenIClickedHiUsernameDropdown()
//        {
//            //Wait
//            Thread.Sleep(1000);

//            //Move cursor on the dropdown to be visible
//            visibleDropdown.Click();
//        }

//        [Given(@"I clicked change password button")]
//        public void GivenIClickedChangePasswordButton()
//        {
//            //Click change password button
//            Thread.Sleep(1000);
//            changePassBtn.Click();

//        }

//        [When(@"I enter new password, current password and confirm password correctly")]
//        public void WhenIEnterNewPasswordCurrentPasswordAndConfirmPasswordCorrectly()
//        {
//            //Enter current password, new password and confirm password
//            Thread.Sleep(1000);
//            currentPass.SendKeys("Test@123");
//            newPass.SendKeys("Test@1234");
//            confirmPass.SendKeys("Test@1234");
//            saveBtn.Click();
//        }

//        [Then(@"the password should be changed as new password I have entered")]
//        public void ThenThePasswordShouldBeChangedAsNewPasswordIHaveEntered()
//        {
//            ScenarioContext.Current.Pending();
//        }
//    }
//}
