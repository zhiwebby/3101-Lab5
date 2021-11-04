using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace UnitTest.Selenium_Tests
{
    [TestFixture]
    [Parallelizable]
    class Selenium_Firefox
    {
        private string _testURL = "https://www.google.com";
        private IWebDriver _driver;

        /*[SetUp]
        public void Start_Browser()
        {
            _driver = new FirefoxDriver(@"D:\geckodriver-v0.30.0-win64");

        }*/

        [SetUp]
        public void Start_Browser()
        {
            FirefoxOptions option = new FirefoxOptions();
            option.AddArgument("--headless");
            _driver = new FirefoxDriver(@"D:\geckodriver-v0.30.0-win64", option);

        }
        // The WebDriver instance is looking out for the WebElement even before the element is present/visibile within the HTML DOM.
        [Test]
        public void GoogleSubtract_WhenSubtracting2from6_ResultEquals4()
        {
            //Setup
            _driver.Url = _testURL;
            System.Threading.Thread.Sleep(1000);
            //Act
            IWebElement searchBox = _driver.FindElement(By.CssSelector("[name = 'q']"));
            searchBox.SendKeys("6 - 2" + Keys.Return);
            System.Threading.Thread.Sleep(1000);
            //Assert
            IWebElement calcAnswer = _driver.FindElement(By.Id("cwos"));
            Assert.That(calcAnswer.Text, Is.EqualTo("4"));
        }

        [TearDown]
        public void Close_Browser()
        {
            _driver.Quit();
        }
    }
}
