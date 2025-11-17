using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCsharp
{
    [TestFixture]
    public class SpaceshipsTests : TestBase
    {
        private void GoToSpaceshipIndex()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/Spaceship");
        }

        [Test]
        public void CanNavigateToSpaceshipPage()
        {
            // ACT
            GoToSpaceshipIndex();

            // ASSERT
            Assert.That(Driver.Url, Does.Contain("/Spaceship"));
        }

        [Test]
        public void CanAddValidSpaceship()
        {
            // ARRANGE
            GoToSpaceshipIndex();
            Driver.FindElement(By.Id("addBtn")).Click();

            // ACT
            Driver.FindElement(By.Id("Name")).SendKeys("Falcon");
            Driver.FindElement(By.Id("Classification")).SendKeys("Battle Cruiser");
            Driver.FindElement(By.Id("BuiltDate")).SendKeys("2023-01-10");
            Driver.FindElement(By.Id("Crew")).SendKeys("120");
            Driver.FindElement(By.Id("EnginePower")).SendKeys("9000");
            Driver.FindElement(By.Id("createBtn")).Click();

            // ASSERT
            var name = Driver.FindElement(By.Id("shipIndexName")).Text;
            Assert.That(name, Is.EqualTo("Falcon"));
        }

        [Test]
        public void CannotAddInvalidSpaceship()
        {
            // ARRANGE
            GoToSpaceshipIndex();
            Driver.FindElement(By.Id("addBtn")).Click();

            // ACT (valed andmed)
            Driver.FindElement(By.Id("Name")).SendKeys("InvalidShip");
            Driver.FindElement(By.Id("Classification")).SendKeys("123"); // vale tüüp
            Driver.FindElement(By.Id("BuiltDate")).SendKeys("NOT DATE"); // vale kuupäev
            Driver.FindElement(By.Id("Crew")).SendKeys("X"); // vale tüüp
            Driver.FindElement(By.Id("EnginePower")).SendKeys("???"); // vale tüüp
            Driver.FindElement(By.Id("createBtn")).Click();

            // ASSERT – ei tohi lisanduda
            var names = Driver.FindElements(By.Id("shipIndexName"));
            bool exists = names.Any(n => n.Text == "InvalidShip");
            Assert.That(exists, Is.False);
        }

        [Test]
        public void CanViewSpaceshipDetails()
        {
            // ARRANGE
            GoToSpaceshipIndex();

            if (Driver.FindElements(By.Id("shipIndexName")).Count == 0)
            {
                CanAddValidSpaceship();
                GoToSpaceshipIndex();
            }

            // ACT
            Driver.FindElement(By.LinkText("Details")).Click();

            // ASSERT
            var title = Driver.FindElement(By.TagName("h1")).Text;
            Assert.That(title, Does.Contain("Details"));
        }

        [Test]
        public void CanUpdateSpaceship()
        {
            // ARRANGE
            GoToSpaceshipIndex();

            if (Driver.FindElements(By.Id("shipIndexName")).Count == 0)
            {
                CanAddValidSpaceship();
                GoToSpaceshipIndex();
            }

            // ACT
            Driver.FindElement(By.LinkText("Edit")).Click();

            var nameInput = Driver.FindElement(By.Id("Name"));
            nameInput.Clear();
            nameInput.SendKeys("UpdatedShip");

            Driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            // ASSERT
            GoToSpaceshipIndex();
            var updated = Driver.FindElement(By.Id("shipIndexName")).Text;

            Assert.That(updated, Is.EqualTo("UpdatedShip"));
        }

        [Test]
        public void CanDeleteSpaceship()
        {
            // ARRANGE
            GoToSpaceshipIndex();
            int before = Driver.FindElements(By.CssSelector("table tbody tr")).Count;

            if (before == 0)
            {
                CanAddValidSpaceship();
                GoToSpaceshipIndex();
                before = Driver.FindElements(By.CssSelector("table tbody tr")).Count;
            }

            // ACT
            Driver.FindElement(By.LinkText("Delete")).Click();
            Driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            // ASSERT
            int after = Driver.FindElements(By.CssSelector("table tbody tr")).Count;
            Assert.That(after, Is.LessThan(before));
        }
    }
}
