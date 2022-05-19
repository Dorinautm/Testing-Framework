using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestProjectHW.PageObjectModel
{
    class TaskPageTest
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public TaskPageTest(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement _taskBtn => _driver.FindElement(By.Id("viewTasksButton"));
        private IWebElement _addTaskBtn => _driver.FindElement(By.XPath("//a[@class='icon']"));
        private IWebElement _btnSave => _driver.FindElement(By.XPath("//button[span[.='Save']]"));
        private IWebElement _subjectField => _driver.FindElement(By.XPath("//input[@name = 'subject']"));
        private IWebElement _statusSelectBtn => _driver.FindElement(By.XPath("//span[.='Status']"));
        private IWebElement _statusSelection => _driver.FindElement(By.XPath("//mat-option[1]"));
        private IWebElement _prioritySelectBtn => _driver.FindElement(By.XPath("//span[.='Priority']"));
        private IWebElement _prioritySelection => _driver.FindElement(By.XPath("//mat-option[2]"));
        private IWebElement _deadline => _driver.FindElement(By.Id("deadline"));
        private IWebElement _selectedDate => _driver.FindElement(By.XPath("//td[@tabindex = '0']"));
        private IWebElement _inputDate => _driver.FindElement(By.XPath("//input[@id = 'deadline']"));
        private IWebElement _filterBtn => _driver.FindElement(By.CssSelector("i.icon-filter"));
        private IWebElement _filterBar => _driver.FindElement(By.CssSelector("div.employees-filter"));


        public void IsBtnDisplayed()
        {
            var btnAddTask = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='icon']")));
            Assert.IsTrue(btnAddTask.Displayed);
        }
        public void CheckBtnName(string btnName)
        {
            string buttonAddTaskText = _addTaskBtn.Text;
            Assert.IsTrue(buttonAddTaskText.Contains(btnName), "button {0} doesnt contain the right text", buttonAddTaskText);                
        }
        public void PressAddTaskBtn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_addTaskBtn)).Click();
        }
        public void CheckBtnSaveDisabled()
        {
            var btnSave = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[span[.='Save']]")));
            Assert.IsFalse(btnSave.Enabled);
        }
        public void AddSubject(string subject)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_subjectField)).SendKeys(subject);
        }
        public void SelectStatus()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_statusSelectBtn)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_statusSelection)).Click();
        }
        public void SelectPriority()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_prioritySelectBtn)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_prioritySelection)).Click();
        }
        public void SelectValidDeadline()
        {
            var localDate = DateTime.UtcNow.ToString("dd/MM/yyyy");
            _wait.Until(ExpectedConditions.ElementToBeClickable(_deadline)).Click();
            _selectedDate.Click();
            var selectedDeadline = _inputDate.GetAttribute("value");
            Assert.That(selectedDeadline, Is.GreaterThanOrEqualTo(localDate));
        }
        public void SaveTask()
        {
            var btnSave = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[span[.='Save']]")));
            Assert.IsTrue(btnSave.Enabled);
            btnSave.Click();
        }
        public void AssertSuccesMessage(string succesMsg)
        {
            string succesMessage = _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("simple-snack-bar > span"))).Text;
            Assert.AreEqual(succesMsg, succesMessage);
        }
        public void FilterByName(string employeeName)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_filterBtn)).Click();
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.employees-filter"))).Click();
            _wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@aria-label='dropdown search']"))).SendKeys(employeeName);
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-option[@tabindex='0']"))).Click();
            //_wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='cdk-overlay-container']"))).Click();
        }
    }
}
