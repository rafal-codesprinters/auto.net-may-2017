using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace WebDriverTesting
{
    public class TestCases : IDisposable
    {
        private ChromeDriver _driver;

        public TestCases()
        {
            _driver = new ChromeDriver();
            _driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Fact]
        public void FixMe()
        {
            Assert.Equal(true, false);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
