using NUnit.Framework;
using System.IO;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAutomationBC1.Pages;


namespace TestAutomationBC1
{
    public class LoginTest
    {

        IWebDriver Driver;

        [SetUp]
        public void Setup() {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;// obtener el path del proyecto
            Driver = new ChromeDriver(path + @"\drivers\");
        }

        [Test]
        public void LoginSucceded() {
            var LoginPage = new LoginPage(Driver);
            LoginPage.OpenPage();
            LoginPage.WriteOnUsername("tomsmith");
            LoginPage.WriteOnPassword("SuperSecretPassword!");
            LoginPage.ClickOnLoginButton();
            var SecureAreaPage = new SecureAreaPage(Driver);
            var SecureURl = SecureAreaPage.GetURL();
            Assert.True(SecureURl.Equals("https://the-internet.herokuapp.com/secure"));
            var AlertMessage = SecureAreaPage.GetAlertMessage();
            Assert.True(AlertMessage.Contains("You logged into a secure area!"));
        }


        [Test]
        public void WithOutPassword()
        {
            var LoginPage = new LoginPage(Driver);
            LoginPage.OpenPage();
            LoginPage.WriteOnUsername("tomsmith");
            LoginPage.ClickOnLoginButton();
            var ObtainedMessage = LoginPage.GetAlertMessage();
            Assert.True(ObtainedMessage.Contains("Your password is invalid!"));
        }






            [TearDown]
        public void TearDown() { 
            Driver.Dispose();
        }

    }
}
