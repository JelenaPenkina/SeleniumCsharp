using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System;

namespace SeleniumCsharp
{
    class NUnitTest
    {
        IWebDriver driver;

        // Start the browser
        public void Initialize()
        {
            driver = new FirefoxDriver();
        }
        // To open the application
        public void OpenAppTest()
        {
            driver.Url = "https://www.demoqa.com";
        }
        // To close the browser
        public void EndTest()
        {
            driver.Close();

        }

        //Seda saab ka teha niimoodi:
        //public void TestApp()
        //{
        //    IWebDriver driver = new FirefoxDriver();
        //    driver.Url = "https://www.demoqa.com";
        //    driver.Close();
        //}
    }
}
