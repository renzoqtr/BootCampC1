using NUnit.Framework;
using System.IO;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TestAutomationBC1
{
    public class Tests
    {

        private IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;// obtener el path del proyecto
            Driver = new ChromeDriver(path + @"\drivers\"); // crear nuestro chrome driver 
            var URL = "https://the-internet.herokuapp.com/login";
            Driver.Navigate().GoToUrl(URL);
        }

        [Test]
        public void Test1()
        {
            var Username = Driver.FindElement(By.Id("username")); //text field username
            var Password = Driver.FindElement(By.Id("password"));
            var Login = Driver.FindElement(By.CssSelector("button.radius"));
            Username.SendKeys("tomsmith");
            Password.SendKeys("SuperSecretPassword!");
            Login.Click();
            var SecurityPageAlert = Driver.FindElement(By.Id("flash"));
            var AlertText = SecurityPageAlert.Text;
            Assert.IsTrue(AlertText.Contains("You logged into a secure area"));
            //Assert.IsTrue(AlertText.Contains("You have been logged into a secure area"));
           
        }

        [TearDown]
        public void TearDown() {
            Driver.Quit();
        }

    }
}