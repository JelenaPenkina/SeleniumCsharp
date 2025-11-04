using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

internal class Program
{
    private static void Main(string[] args)
    {
        TestSpaceshipAdd();
    }
    [Test]
    public static void TestSpaceshipAdd()
    {
        IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
        driver.Url = "https://localhost:7106"; //navigeeri siia
        IWebElement idOfLinkElement = driver.FindElement(By.Id("spaceship")); //otsi element spaceship id-ga
        idOfLinkElement.Click(); //vajuta sellele elemendile
        Thread.Sleep(500);
        //Thread.Sleep(3000);
        //driver.Navigate().Back();
        IWebElement idOfCreateButton = driver.FindElement(By.Id("testIdAdd"));
        idOfCreateButton.Click();
        Thread.Sleep(500);
        InsertSpaceShipData(driver);
        IWebElement idOfCreatePostButton = driver.FindElement(By.Id("testIdCPT"));
        idOfCreatePostButton.Click();
        Thread.Sleep(500);
        ICollection<IWebElement> elementstocheck = driver.FindElements(By.Id("testIdNAM_I"));
        //foreach (var element in elementstocheck)
        //{
        //    Assert.That(element.Text, Is.EqualTo("TESTNAME_01"));
        //    Assert.
        //}

        IWebElement idOfTestData1 = driver.FindElement(By.Id("testIdNAM_I"));
        var nameinindex = idOfTestData1.Text;
        IWebElement idOfTestData2 = driver.FindElement(By.Id("testIdEPW_I"));
        var powerinindex = idOfTestData2.Text;
        Assert.That(nameinindex, Is.EqualTo("TESTNAME_01"));
        Assert.That(powerinindex, Is.EqualTo("24857"));
        Console.WriteLine("Test passed");

    }
    private static void InsertSpaceShipData(IWebDriver driver)
    {

        IWebElement idOfDescriptionInput = driver.FindElement(By.Id("testIdDSC"));
        idOfDescriptionInput.SendKeys("DescriptionAddingTest"); //sisesta väljale klahvivajutustena DescriptionAddingTest
        IWebElement idofNameInput = driver.FindElement(By.Id("testIdNAM"));
        idofNameInput.SendKeys("TESTNAME_01");
        IWebElement idofPriceInput = driver.FindElement(By.Id("testIdPRC"));
        idofPriceInput.SendKeys("330000");
        IWebElement idofTypeInput = driver.FindElement(By.Id("testIdTYP"));
        idofTypeInput.SendKeys("Riksha");
        IWebElement idofFuelTypeInput = driver.FindElement(By.Id("testIdFTP"));
        idofFuelTypeInput.SendKeys("Bananas");
        IWebElement idofFuelCapacityInput = driver.FindElement(By.Id("testIdFCY"));
        idofFuelCapacityInput.SendKeys("60");
        IWebElement idofFuelConsumptionInput = driver.FindElement(By.Id("testIdFCM"));
        idofFuelConsumptionInput.SendKeys("2");
        IWebElement idofPassengerCountInput = driver.FindElement(By.Id("testIdPCT"));
        idofPassengerCountInput.SendKeys("10");
        IWebElement idofEnginePowerInput = driver.FindElement(By.Id("testIdEPW"));
        idofEnginePowerInput.Clear();
        idofEnginePowerInput.SendKeys("24857");
        IWebElement idofAutopilotInput = driver.FindElement(By.Id("testIdDHA"));
        idofAutopilotInput.Click(); //attempt to enable the checkbox with space key
        IWebElement idofCrewCountInput = driver.FindElement(By.Id("testIdCCT"));
        idofCrewCountInput.SendKeys("6");
        IWebElement idofCargoWeightInput = driver.FindElement(By.Id("testIdCWT"));
        idofCargoWeightInput.Clear();
        idofCargoWeightInput.SendKeys("1");
        IWebElement idofLifeSupportInput = driver.FindElement(By.Id("testIdLSS"));
        idofLifeSupportInput.Click();
        IWebElement idofBuiltDateInput = driver.FindElement(By.Id("testIdMFD"));
        idofBuiltDateInput.SendKeys("111111111111");
        IWebElement idofLastMaintenanceInput = driver.FindElement(By.Id("testIdLMT"));
        idofBuiltDateInput.SendKeys("111111111111");
        IWebElement idofMaintenanceCountInput = driver.FindElement(By.Id("testIdMCT"));
        idofMaintenanceCountInput.SendKeys("1");
        IWebElement idofMaidenLaunchInput = driver.FindElement(By.Id("testIdMDL"));
        idofMaidenLaunchInput.SendKeys("111111111111");
        IWebElement idofManufacturerInput = driver.FindElement(By.Id("testIdMF2"));
        idofManufacturerInput.SendKeys("0");

    }
}
