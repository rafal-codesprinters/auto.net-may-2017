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
        public void Hello_test()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");
            _driver.FindElementById("lst-ib").SendKeys("code sprinters");
            _driver.FindElementById("_fZl").Click();
            var result = _driver.FindElementByXPath(@"//div/*/a[@href='http://agileszkolenia.pl/']");

            Assert.NotNull(result);
            Assert.Equal("Code Sprinters -", result.Text);
        }


    }
}
