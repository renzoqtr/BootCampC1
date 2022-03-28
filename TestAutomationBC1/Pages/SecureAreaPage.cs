using OpenQA.Selenium;

namespace TestAutomationBC1.Pages
{
    public class SecureAreaPage
    {
        private IWebDriver Driver;
        private const string URL = "https://the-internet.herokuapp.com/secure";
        private By SecurityPageAlert = By.Id("flash");

        public SecureAreaPage(IWebDriver Driver) {
            this.Driver = Driver;
        }

        public string GetAlertMessage() {
            return  Driver.FindElement(SecurityPageAlert).Text;
        }

        public string GetURL() {
            return Driver.Url;
        }

    }
}
