using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using Xunit;

namespace WebDriverTesting
{
    public class TestCases : IDisposable
    {
        public TestCases()
        {
            _driver = new ChromeDriver();
            _driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Fact]
        public void Second_note_should_have_title_Vivamus_aliquam_feugiat()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/");

            ReadOnlyCollection<IWebElement> posts = _driver.FindElementsByClassName("post-title");
            IWebElement secondPost = posts[1];
            string firstNoteTitle = secondPost.FindElement(By.TagName("a")).Text;
            
            Assert.Equal("Vivamus aliquam feugiat", firstNoteTitle);
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        private ChromeDriver _driver;
    }
}
