using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowTests
{
    [Binding]
    public class DeleteSharedSkill
    {

        public DeleteSharedSkill()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Initialize Web Elements
        //Click Education Tab
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Manage Listings')]")]
        private IWebElement ManageLSTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//body//tbody//tr")]
        IList<IWebElement> allRows { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div/button")]
        IList<IWebElement> allPages { get; set; }
        [FindsBy(How = How.CssSelector, Using = "body > div.ui.page.modals.dimmer.transition.visible.active > div > div.actions > button.ui.icon.positive.right.labeled.button")]
        IWebElement yesBtn { get; set; }
        string expectedCat = "Programming & Tech";
        string expectedTitle = "Edited SharedSkill";
        bool exitOuterLoop = false;
        WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
        #endregion

        [Given(@"I clicked on the Manage listings tab under Profile page")]
        public void GivenIClickedOnTheManageListingsTabUnderProfilePage()
        {
            ManageLSTab.Click();
        }

        [When(@"I delete a shared skill")]
        public void WhenIDeleteASharedSkill()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//body//tbody//tr")));
            int numofPage = allPages.Count;
            int rowCount = allRows.Count;

            for (int i = 2; i < numofPage; i++)
            {
                for (int j = 1; j < rowCount; j++)
                {
                    string actualCat = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;
                    string actualTitle = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                    string expectedMsg = expectedTitle + " has been deleted";
                    IWebElement deleteBtn = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[8]/i[3]"));

                    //wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")));

                    if (expectedCat == actualCat && expectedTitle == actualTitle)
                    {
                        deleteBtn.Click();
                        Driver.driver.SwitchTo().Window(Driver.driver.WindowHandles.Last());
                        yesBtn.Click();
                        wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'ns-box-inner')]")));
                        IWebElement successMsg = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box-inner')]"));
                        string actualMsg = successMsg.Text;
                        //Driver.driver.SwitchTo().Window(Driver.driver.WindowHandles.Last());
                        Console.WriteLine(expectedMsg + " " + actualMsg);
                        Thread.Sleep(10000);

                        if (expectedMsg == actualMsg)
                        {
                            Console.WriteLine("Deleted successfully");
                        }
                        else
                        {
                            Console.WriteLine("Deleted Failed");
                        }
                        exitOuterLoop = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                    }
                }
                if (exitOuterLoop == false)
                {
                    Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div/button[" + i + "]")).Click();
                }
                else
                {
                    break;
                }
            }
        }

        [Then(@"that shared skill should be deleted from my listings")]
        public void ThenThatSharedSkillShouldBeDeletedFromMyListings()
        {
            Console.WriteLine("pass");
        }
    }
}
