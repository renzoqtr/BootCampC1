using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;

namespace TestAutomationBC1.Pages
{
    public class LoginPage
    {
        private IWebDriver Driver;
        private const string URL = "https://the-internet.herokuapp.com/login";
        private By Username = By.Id("username");
        private By Password = By.Id("password");
        private By Login = By.CssSelector("button.radius");
        private By Alert = By.Id("flash");


        public void OpenPage() {
            Driver.Navigate().GoToUrl(URL);
        }

        public LoginPage(IWebDriver Driver) {
            this.Driver = Driver;
        }

        public void WriteOnUsername(string text) {
            Driver.FindElement(Username).SendKeys(text);
        }

        public void WriteOnPassword(string text) {
            Driver.FindElement(Password).SendKeys(text);
        }

        public void ClickOnLoginButton() {
            Driver.FindElement(Login).Click();
        }

        public string GetAlertMessage() {
            return Driver.FindElement(Alert).Text;
        }
    }
}
