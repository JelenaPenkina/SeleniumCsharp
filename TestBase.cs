using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumCsharp
{
    public class TestBase : TestBaseBase
    {
        [SetUp]
        public void Setup()
        {
            var service = FirefoxDriverService.CreateDefaultService(
                        @"C:\Users\opilane\Source\Repos\SeleniumCsharp\Drivers",
                        "geckodriver.exe");

            //service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe"; 

            var options = new FirefoxOptions();
            options.AddArgument("--no-sandbox");

            Driver = new FirefoxDriver(service, options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
        }

        protected void GoToKindergartenIndex()
        {
            Driver.Navigate().GoToUrl("https://localhost:5196/Kindergarten");
        }
    }
}
