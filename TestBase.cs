using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumCsharp
{
    public class TestBase
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        protected string BaseUrl = "http://localhost:5196";

        [SetUp]
        public void Setup()
        {
            var options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            Driver = new FirefoxDriver(options);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        protected void GoToKindergartenIndex()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/Kindergarten");
        }
    }
}
