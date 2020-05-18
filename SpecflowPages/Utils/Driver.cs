using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowPages
{
    public class Driver
    {
        //Initialize the browser
        public static IWebDriver driver { get; set; }

        public static void Initialize()
        {
            //Defining the browser
            driver = new ChromeDriver();
            TurnOnWait();

            //Maximise the window
            driver.Manage().Window.Maximize();
        }   

        public static string BaseUrl
        {
            get{ return ConstantUtils.Url; }
        }
           
        
        //Implicit Wait
        public static void TurnOnWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        //Close the browser
        public static void Close()
        {
            driver.Close();
        }

        //Explicit Wait
        //public static void ExcipliWait()
        //{
        //    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //}

    }
}
