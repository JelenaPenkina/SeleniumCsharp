using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Linq;

namespace SeleniumCsharp
{
    [TestFixture]
    public class KindergartenTests : TestBase
    {
        [Test]
        public void CanAddValidKindergarten()
        {
            // Arrange
            GoToKindergartenIndex();

            // Act
            Driver.FindElement(By.Id("addBtn")).Click();
            Driver.FindElement(By.Id("KindergartenName")).SendKeys("Sunny");
            Driver.FindElement(By.Id("GroupName")).SendKeys("Milka");
            Driver.FindElement(By.Id("TeacherName")).SendKeys("Teacher Tauno");
            Driver.FindElement(By.Id("ChildrenCount")).SendKeys("24");
            Driver.FindElement(By.Id("createBtn")).Click();

            // Assert
            var name = Driver.FindElement(By.Id("kgIndexName")).Text;
            var teacher = Driver.FindElement(By.Id("kgIndexTeacher")).Text;
            Assert.That(name, Is.EqualTo("Sunny"));
            Assert.That(teacher, Is.EqualTo("Teacher Tauno"));
        }

        [Test]
        public void CannotAddInvalidKindergarten()
        {
            // Arrange
            GoToKindergartenIndex();

            // Act
            Driver.FindElement(By.Id("addBtn")).Click();
            Driver.FindElement(By.Id("KindergartenName")).SendKeys("Invalid");
            Driver.FindElement(By.Id("GroupName")).SendKeys("123"); // vale tüüp
            Driver.FindElement(By.Id("TeacherName")).SendKeys("Teacher");
            Driver.FindElement(By.Id("ChildrenCount")).SendKeys("X"); // vale tüüp
            Driver.FindElement(By.Id("createBtn")).Click();

            // Assert
            var names = Driver.FindElements(By.Id("kgIndexName"));
            bool exists = names.Any(n => n.Text == "Invalid");
            Assert.That(exists, Is.False, "Vale andmetega Kindergarten");
        }

        [Test]
        public void CanViewKindergartenDetails()
        {
            // ARRANGE
            GoToKindergartenIndex();

            if (Driver.FindElements(By.Id("kgIndexName")).Count == 0)
            {
                CanAddValidKindergarten();
                GoToKindergartenIndex();
            }

            // ACT
            Driver.FindElement(By.LinkText("Details")).Click();

            // ASSERT
            var title = Driver.FindElement(By.TagName("h1")).Text;
            Assert.That(title, Does.Contain("Details"));
        }

        [Test]
        public void CanUpdateKindergarten()
        {
            // ARRANGE
            GoToKindergartenIndex();

            if (Driver.FindElements(By.Id("kgIndexName")).Count == 0)
            {
                CanAddValidKindergarten();
                GoToKindergartenIndex();
            }

            // ACT
            Driver.FindElement(By.LinkText("Edit")).Click();

            var nameInput = Driver.FindElement(By.Id("KindergartenName"));
            nameInput.Clear();
            nameInput.SendKeys("UpdatedName");

            Driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            // ASSERT
            GoToKindergartenIndex();
            var newName = Driver.FindElement(By.Id("kgIndexName")).Text;

            Assert.That(newName, Is.EqualTo("UpdatedName"));
        }

        [Test]
        public void CanDeleteKindergarten()
        {
            // ARRANGE
            GoToKindergartenIndex();
            int beforeCount = Driver.FindElements(By.CssSelector("table tbody tr")).Count;

            if (beforeCount == 0)
            {
                CanAddValidKindergarten();
                GoToKindergartenIndex();
                beforeCount = Driver.FindElements(By.CssSelector("table tbody tr")).Count;
            }

            // ACT
            Driver.FindElement(By.LinkText("Delete")).Click();
            Driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            // ASSERT
            int afterCount = Driver.FindElements(By.CssSelector("table tbody tr")).Count;
            Assert.That(afterCount, Is.LessThan(beforeCount));
        }
    }
}
