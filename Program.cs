using NUnit.Framework;
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
        IWebDriver driver = new FirefoxDriver();  // uus firefox driver
        driver.Url = "https://localhost:7106";    // navigeerib siia 

        // NAVIGEERIMINE KG lehele ning ka otsing ID järgi 
        IWebElement idOfLinkElement = driver.FindElement(By.Id("kindergarten"));
        idOfLinkElement.Click();
        Thread.Sleep(500);

        // LISA UUS KINDERGARTEN
        IWebElement idOfCreateButton = driver.FindElement(By.Id("addBtn"));
        idOfCreateButton.Click();
        Thread.Sleep(500);

        InsertKindergartenData(driver);

        IWebElement idOfCreatePostButton = driver.FindElement(By.Id("createBtn"));
        idOfCreatePostButton.Click();
        Thread.Sleep(500);

        // KONTROLL INDEX VAATES
        IWebElement idOfTestData1 = driver.FindElement(By.Id("kgIndexName"));
        var nameInIndex = idOfTestData1.Text;

        IWebElement idOfTestData2 = driver.FindElement(By.Id("kgIndexTeacher"));
        var teacherInIndex = idOfTestData2.Text;

        Assert.That(nameInIndex, Is.EqualTo("Sunny"));
        Assert.That(teacherInIndex, Is.EqualTo("Teacher Tauno"));

        Console.WriteLine("KG Test passed");
    }

    private static void InsertKindergartenData(IWebDriver driver)
    {
        IWebElement name = driver.FindElement(By.Id("KindergartenName"));
        name.SendKeys("Sunny");

        IWebElement group = driver.FindElement(By.Id("GroupName"));
        group.SendKeys("Milka");

        IWebElement teacher = driver.FindElement(By.Id("TeacherName"));
        teacher.SendKeys("Teacher Tauno");

        IWebElement children = driver.FindElement(By.Id("ChildrenCount"));
        children.SendKeys("24");
    }
}
