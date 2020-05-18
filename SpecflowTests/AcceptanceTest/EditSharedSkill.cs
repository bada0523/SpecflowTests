using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class EditSharedSkill
    {
        public EditSharedSkill()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click Education Tab
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Manage Listings')]")]
        private IWebElement ManageLSTab { get; set; }
        //Click Add New Button
        //Add Title
        [FindsBy(How = How.XPath, Using = "(//input[contains(@type,'text')])[2]")]
        private IWebElement addTitle { get; set; }
        //Add Description
        [FindsBy(How = How.XPath, Using = "//textarea[contains(@name,'description')]")]
        private IWebElement addDescription { get; set; }
        //Select Category
        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'Programming & Tech')]")]
        private IWebElement clickCategory { get; set; }
        //Select Sub Category
        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'QA')]")]
        private IWebElement clickCategory2 { get; set; }
        //Add Tag
        [FindsBy(How = How.XPath, Using = "(//input[contains(@class,'tagInputField')])[1]")]
        private IWebElement addTag { get; set; }
        //Press Enter key on Add Tag field
        [FindsBy(How = How.XPath, Using = "(//input[contains(@class,'tagInputField')])[1]")]
        private IWebElement enterKeyTag { get; set; }
        //Select Service Type
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'serviceType')])[2]")]
        private IWebElement serviceType { get; set; }
        //Select Location Type
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'locationType')])[1]")]
        private IWebElement locationType { get; set; }
        //Select Available Days - Start Date
        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(1) > div:nth-child(2) > input[type='date']")]
        private IWebElement startDate { get; set; }
        //Select Available Days - End Date
        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(1) > div:nth-child(4) > input[type='date']")]
        private IWebElement endDate { get; set; }
        //Click Credit Button on Skill Trade
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'skillTrades')])[1]")]
        private IWebElement skillTrade { get; set; }
        //Add Skill-Exchange
        [FindsBy(How = How.XPath, Using = "(//input[contains(@class,'tagInputField')])[2]")]
        private IWebElement skillExchange { get; set; }
        //Press Enter Key on Skill-Exchange field
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        private IWebElement enterKeySK { get; set; }
        //Click work Sample Button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement workSampleBtn { get; set; }
        //Select Active
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'isActive')])[1]")]
        private IWebElement activeBtn { get; set; }
        //Click Save Button
        [FindsBy(How = How.XPath, Using = "(//input[@type='button'])[1]")]
        private IWebElement saveBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr")]
        IList<IWebElement> Count { get; set; }
        //Explicit Wait
        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"I clicked on the Manage Listings tab under Profile page")]
        public void GivenIClickedOnTheManageListingsTabUnderProfilePage()
        {
            Thread.Sleep(1500);
            ManageLSTab.Click();
        }

        [When(@"I clicked the pencil icon on my listings")]
        public void WhenIClickedThePencilIconOnMyListings()
        {
            int rowCount = Count.Count;
            Console.WriteLine(rowCount);
            for (int i = 1; i <= rowCount; i++)
            {
                string expectedName = "Test Analyst";
                string actualName = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + i + "]/td[3]")).Text;
                IWebElement editBtn = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + i + "]/td[8]/i[2]"));
                if (expectedName == actualName)
                {
                    editBtn.Click();
                    break;
                }
                else
                {

                }
            }
        }

        [When(@"I edit a shared skill")]
        public void WhenIEditASharedSkill()
        {
            Console.WriteLine("pass");
            //Wait
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input")));
            //Add Title
            addTitle.SendKeys("Edited SharedSkill");
            //Enter Description
            addDescription.SendKeys("I want to skill trade");
            //Click on Category
            clickCategory.Click();
            clickCategory2.Click();
            //Add Tag
            addTag.SendKeys("#Selenium");
            enterKeyTag.SendKeys(Keys.Enter);

            //Choose Service Type
            serviceType.Click();
            //Choose Location Type
            locationType.Click();
            //Choose Available Days - Start date
            startDate.SendKeys("30-10-2019");
            //Choose Available Days - End date
            endDate.SendKeys("13-12-2019");

            //Choose Available Time - 10:00am to 16:00pm on Mon - Thu
            for (int i = 3; i < 7; i++)
            {
                Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + i + "]/div[1]/div/input")).Click();
                Driver.driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(" + i + ") > div:nth-child(2) > input[type='time']")).SendKeys("1000");
                Driver.driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(" + i + ") > div:nth-child(3) > input[type='time']")).SendKeys("1600");
            }
            //Click on Skill trade
            skillTrade.Click();
            //Add Skill-Exchange
            skillExchange.SendKeys("#JIRA");
            enterKeySK.SendKeys(Keys.Enter);
            //*****It suddenly does not support from website*****
            //Upload Work Samples
            //workSampleBtn.Click();
            //Thread.Sleep(1000);
            ////Please, make a txt file and change the path for you 
            //System.Windows.Forms.SendKeys.SendWait(@"C:\Users\HarrisVicky\Desktop\fortesting.txt");
            //System.Windows.Forms.SendKeys.SendWait("{Enter}");
            //---------------------------------------------------------------------
            //Choose Active
            activeBtn.Click();
            //Click the button Save
            saveBtn.Click();
        }

        [Then(@"that updated shared skill should be displayed  on my listings")]
        public void ThenThatUpdatedSharedSkillShouldBeDisplayedOnMyListings()
        {
            Console.WriteLine("Test");
        }
    }
}
