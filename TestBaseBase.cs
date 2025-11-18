using OpenQA.Selenium;

namespace SeleniumCsharp
{
    public class TestBaseBase
    {
        //protected IWebDriver Driver;
        //protected WebDriverWait Wait;
        //protected string BaseUrl = "http://localhost:5196";

        //[SetUp]
        //public void Setup()
        //{
        //    var options = new FirefoxOptions();
        //    options.AcceptInsecureCertificates = true;
        //    Driver = new FirefoxDriver(options);
        //    Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    Driver.Quit();
        //    Driver.Dispose();
        //}

        //protected void GoToKindergartenIndex()
        //{
        //    Driver.Navigate().GoToUrl($"{BaseUrl}/Kindergarten");
        //}
        protected IWebDriver Driver;
    }
}