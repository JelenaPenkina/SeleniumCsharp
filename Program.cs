using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

internal class Program
{
    private static void Main(string[] args)
    {
        TestKindergartenAdd();
    }
    [Test]
    public static void TestKindergartenAdd()
    {
        IWebDriver driver = new FirefoxDriver();  //uus fiorefoxi driver
        driver.Url = "https://localhost:7106";   // navigeerib siia 

        IWebElement idOfLinkElement = driver.FindElement(By.Id("kindergarten")); //otsi element spaceship id-ga
        idOfLinkElement.Click(); //vajuta sellele elemendile
        Thread.Sleep(500);

        IWebElement idOfCreateButton = driver.FindElement(By.Id("addBtn"));
        idOfCreateButton.Click();
        Thread.Sleep(500);

        InsertSpaceShipData(driver);

        IWebElement idOfCreatePostButton = driver.FindElement(By.Id("createBtn"));
        idOfCreatePostButton.Click();
        Thread.Sleep(500);

        ICollection<IWebElement> elementsToCheck = driver.FindElements(By.Id("testIdNAM_I"));
   

        IWebElement idOfTestData1 = driver.FindElement(By.Id("testIdNAM_I"));
        var nameInIndex = idOfTestData1.Text;
        IWebElement idOfTestData2 = driver.FindElement(By.Id("testIdEPW_I"));
        var powerInIndex = idOfTestData2.Text;

        Assert.That(nameInIndex, Is.EqualTo("TESTNAME_01"));
        Assert.That(powerInIndex, Is.EqualTo("24857"));
        Console.WriteLine("KG Test passed");

    }
    private static void InsertSpaceShipData(IWebDriver driver)
    {

        IWebElement name = driver.FindElement(By.Id("KindergartenName"));
        name.SendKeys("Sunny");

        IWebElement group = driver.FindElement(By.Id("GroupName"));
        group.SendKeys("Milka");

        IWebElement teacher = driver.FindElement(By.Id("Teacher"));
        teacher.SendKeys("Teacher Tauno");

        IWebElement children = driver.FindElement(By.Id("Children"));
        children.SendKeys("24");
    }
}

