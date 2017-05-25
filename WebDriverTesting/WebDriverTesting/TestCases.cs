using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
            _driver.Manage().Window.Maximize();
            _driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Fact(Skip ="Bo tak")]
        public void Second_note_should_have_title_Vivamus_aliquam_feugiat()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/");

            ReadOnlyCollection<IWebElement> posts = _driver.FindElementsByClassName("post-title");
            IWebElement secondPost = posts[1];
            string firstNoteTitle = secondPost.FindElement(By.TagName("a")).Text;
            
            Assert.Equal("Vivamus aliquam feugiat", firstNoteTitle);
        }

        [Fact]
        public void When_administrator_publish_new_note_unregistered_user_can_view_that_note_on_a_blog()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/wp-admin");
            var login = _driver.FindElementById("user_login");
            login.Click();
            login.SendKeys("autotestdotnet@gmail.com");

            var pass = _driver.FindElementById("user_pass");
            pass.Click();
            pass.SendKeys("codesprinters2017");

            _driver.FindElementById("wp-submit").Click();

            _driver.FindElementByCssSelector(".wp-menu-image.dashicons-before.dashicons-admin-post").Click();
            _driver.FindElementByLinkText("Add New").Click();

            var title = _driver.FindElementById("title");
            title.Click();
            var newTitle = Guid.NewGuid().ToString();
            title.SendKeys(newTitle);

            var content = _driver.FindElementById("content");
            content.Click();
            content.SendKeys(ExampleText);

            _driver.FindElementById("publish").Click();

            WaitForElementPresent(By.Id("sample-permalink"), 20);
            var url = _driver.FindElementById("sample-permalink")
                .FindElement(By.XPath("a")).GetAttribute("href");

     
            var logout = _driver.FindElementByCssSelector(".avatar.avatar-32");
            logout.Click();

            _driver.FindElementByCssSelector(".ab-sign-out").Click();
            _driver.Navigate().GoToUrl(url);


            var singlePostTitle = _driver.FindElementByXPath("//header/h1").Text;
            Assert.Equal(singlePostTitle, newTitle);
        }

        protected void WaitForElementPresent(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver, 
                TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected void WaitForElementPresent(IWebElement by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver,
                TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        private ChromeDriver _driver;

        public string ExampleText => @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi scelerisque diam ac lacinia placerat. Nullam congue blandit dolor, a placerat urna sodales quis. Aliquam molestie quis ipsum sed tempor. Nam interdum dolor lorem, in accumsan sem dictum a. Aenean non sem sed est sodales lobortis in at risus. Aenean eget feugiat dui. Phasellus suscipit finibus purus, eu lacinia nibh facilisis eget. Vivamus a consectetur nisl. Praesent malesuada id massa quis ultrices. Quisque et dolor dictum, lacinia leo vitae, hendrerit odio.

Sed neque felis, fermentum sit amet risus vitae, scelerisque pretium dolor. Duis elementum tellus a ante efficitur gravida. Morbi posuere dolor vel nisi commodo, in mollis erat fermentum. Morbi neque lectus, rhoncus ac vulputate in, malesuada vel libero. Suspendisse facilisis tempor nisi sed varius. Fusce aliquam dui sit amet arcu vestibulum, et tincidunt lorem dapibus. Nullam non erat mollis, dictum libero a, sagittis eros. Aenean pellentesque facilisis neque accumsan vulputate. Donec imperdiet, mi eget pharetra lacinia, mauris neque sodales eros, in auctor neque nunc in risus. Donec pulvinar pharetra rhoncus. Nulla tempus nibh eget lorem viverra, quis auctor ante sagittis. Ut lobortis dapibus orci, sit amet porttitor est mattis at. Vestibulum euismod dolor odio, nec ultricies erat faucibus sed. Nulla hendrerit mauris ac nisl mattis, in tristique ipsum semper. Nam ante nibh, dignissim at lorem eu, imperdiet imperdiet velit. Praesent at efficitur libero, ut rutrum leo.";
    }
}
