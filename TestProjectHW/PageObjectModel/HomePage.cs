using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectHW.PageObjectModel
{
    public class HomePageTest
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public HomePageTest(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement _taskBtn => _driver.FindElement(By.Id("viewTasksButton"));
        private IWebElement _logoutBtn => _driver.FindElement(By.XPath("//*[@class = 'log-out']"));
        private IWebElement _logoutBtnText => _driver.FindElement(By.CssSelector("mat-dialog-actions > button > span"));
        private IWebElement _confirmLogoutBtn => _driver.FindElement(By.XPath("//span[.='Log out']"));
        private IWebElement _cancelLogoutBtn => _driver.FindElement(By.XPath("//span[.='No']"));
        private IWebElement _signedAccount => _driver.FindElement(By.XPath("//div[@role = 'button']"));

        public void PressTaskBtn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_taskBtn)).Click();
        }
        public void CheckPageTitle(string title)
        {
            Assert.AreEqual(title, _driver.Title);
        }
        public void LogOut()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_logoutBtn)).Click();
        }
        public void CheckLogoutBtnPopup(string logoutBtn)
        {
            string textButton = _wait.Until(ExpectedConditions.ElementToBeClickable(_logoutBtnText)).Text;
            Assert.AreEqual(logoutBtn, textButton);
        }
        public void ConfirmLogout()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_confirmLogoutBtn)).Click();
            _wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@role = 'button']"))).Click();
        }
        public void CancelLogout()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_cancelLogoutBtn)).Click();
            string URL = _driver.Url; 
            Assert.AreEqual(URL, "https://projectplanappweb-stage.azurewebsites.net/dashboard");
        }
        public void NavigateBack(string message)
        {
            _driver.Navigate().Back();

            string expectedResult = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_workload_logo_text"))).Text;
            Assert.AreEqual(message, expectedResult);
        }
    }
}
