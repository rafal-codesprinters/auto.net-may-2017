using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace GoogleTesting
{
    public class GoogleTest : IDisposable
    {
        private ChromeDriver _driver;

        public GoogleTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        [Fact]
        public void Find_Searchbox_By_Id()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");
            _driver.FindElementById("lst-ib").SendKeys("code sprinters");
            _driver.FindElementById("_fZl").Click();
            var result = _driver.FindElementByXPath(@"//div/*/a[@href='http://agileszkolenia.pl/']");

            Assert.NotNull(result);
            Assert.Equal("Code Sprinters -", result.Text);
        }

        [Fact]
        public void Find_Searchbox_By_XPath()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");
            _driver.FindElementByXPath("//input[@name='q']").SendKeys("code sprinters");
            _driver.FindElementByXPath("//button[@name='btnG']").Click();
            var result = _driver.FindElementByXPath(@"//div/*/a[@href='http://agileszkolenia.pl/']");

            Assert.NotNull(result);
            Assert.Equal("Code Sprinters -", result.Text);
        }

        [Fact]
        public void Find_Searchbox_By_ClassName()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");
            _driver.FindElementByClassName("gsfi").SendKeys("code sprinters");
            _driver.FindElementByClassName("sbico-c").Click();
            var result = _driver.FindElementByXPath(@"//div/*/a[@href='http://agileszkolenia.pl/']");

            Assert.NotNull(result);
            Assert.Equal("Code Sprinters -", result.Text);
        }

        [Fact]
        public void Find_Searchbox_By_CssSelector()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");
            _driver.FindElementByCssSelector(".gsfi").SendKeys("code sprinters");
            _driver.FindElementByCssSelector(".sbico").Click();
            var result = _driver.FindElementByXPath(@"//div/*/a[@href='http://agileszkolenia.pl/']");

            Assert.NotNull(result);
            Assert.Equal("Code Sprinters -", result.Text);
        }
    }
}
