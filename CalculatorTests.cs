using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Text.RegularExpressions;

namespace AppiumCalculator
{
    public class CalculatorTests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;


        [OneTimeSetUp]
        public void OpenApp()
        {

            this.appiumOptions = new AppiumOptions() { PlatformName = "Windows"};
            appiumOptions.AddAdditionalCapability("app", appLocation);
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);

        }

        [OneTimeTearDown]

        public void CloseApp()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AddTwoPositiveNumbers()
        {
            var buttonSeven = driver.FindElementByAccessibilityId("num7Button");
            buttonSeven.Click();

            var buttonPlus = driver.FindElementByAccessibilityId("plusButton");
            buttonPlus.Click();

            var buttonThree = driver.FindElementByAccessibilityId("num3Button");
            buttonThree.Click();

            var buttonEqual = driver.FindElementByAccessibilityId("equalButton");
            buttonEqual.Click();

            var resultField = driver.FindElementByAccessibilityId("CalculatorResults");

            var result = resultField.Text;

            var resultValue = Regex.Match(result, @"\d+").Value;

            Assert.That(resultValue, Is.EqualTo("10"));
        }

        [Test]
        public void Test_MultiplyTwoPositiveNumbers()
        {
            var buttonSeven = driver.FindElementByAccessibilityId("num7Button");
            buttonSeven.Click();

            var multiplyButton = driver.FindElementByAccessibilityId("multiplyButton");
            multiplyButton.Click();

            var buttonThree = driver.FindElementByAccessibilityId("num3Button");
            buttonThree.Click();

            var buttonEqual = driver.FindElementByAccessibilityId("equalButton");
            buttonEqual.Click();

            var resultField = driver.FindElementByAccessibilityId("CalculatorResults");

            var result = resultField.Text;

            var resultValue = Regex.Match(result, @"\d+").Value;

            Assert.That(resultValue, Is.EqualTo("21"));
        }

        [Test]
        public void Test_DeleteTwoPositiveNumbers()
        {
            var buttonEight = driver.FindElementByAccessibilityId("num8Button");
            buttonEight.Click();

            var divideButton = driver.FindElementByAccessibilityId("divideButton");
            divideButton.Click();

            var buttonFour = driver.FindElementByAccessibilityId("num4Button");
            buttonFour.Click();

            var buttonEqual = driver.FindElementByAccessibilityId("equalButton");
            buttonEqual.Click();

            var resultField = driver.FindElementByAccessibilityId("CalculatorResults");

            var result = resultField.Text;

            var resultValue = Regex.Match(result, @"\d+").Value;

            Assert.That(resultValue, Is.EqualTo("2"));
        }


        [Test]
        public void Test_SubstractTwoPositiveNumbers()
        {
            var buttonEight = driver.FindElementByAccessibilityId("num8Button");
            buttonEight.Click();

            var substractButton = driver.FindElementByAccessibilityId("minusButton");
            substractButton.Click();

            var buttonFour = driver.FindElementByAccessibilityId("num4Button");
            buttonFour.Click();

            var buttonEqual = driver.FindElementByAccessibilityId("equalButton");
            buttonEqual.Click();

            var resultField = driver.FindElementByAccessibilityId("CalculatorResults");

            var result = resultField.Text;

            var resultValue = Regex.Match(result, @"\d+").Value;

            Assert.That(resultValue, Is.EqualTo("4"));
        }


    }
}