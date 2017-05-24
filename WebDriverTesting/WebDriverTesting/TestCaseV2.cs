using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace WebDriverTesting
{
    public class TestCaseV2 : IDisposable
    {
        private readonly string _exampleTitle ;
        private static string ExampleContent => @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi scelerisque diam ac lacinia placerat. Nullam congue blandit dolor, a placerat urna sodales quis. Aliquam molestie quis ipsum sed tempor. Nam interdum dolor lorem, in accumsan sem dictum a. Aenean non sem sed est sodales lobortis in at risus. Aenean eget feugiat dui. Phasellus suscipit finibus purus, eu lacinia nibh facilisis eget. Vivamus a consectetur nisl. Praesent malesuada id massa quis ultrices. Quisque et dolor dictum, lacinia leo vitae, hendrerit odio. Sed neque felis, fermentum sit amet risus vitae, scelerisque pretium dolor. Duis elementum tellus a ante efficitur gravida. Morbi posuere dolor vel nisi commodo, in mollis erat fermentum. Morbi neque lectus, rhoncus ac vulputate in, malesuada vel libero. Suspendisse facilisis tempor nisi sed varius. Fusce aliquam dui sit amet arcu vestibulum, et tincidunt lorem dapibus. Nullam non erat mollis, dictum libero a, sagittis eros. Aenean pellentesque facilisis neque accumsan vulputate. Donec imperdiet, mi eget pharetra lacinia, mauris neque sodales eros, in auctor neque nunc in risus. Donec pulvinar pharetra rhoncus. Nulla tempus nibh eget lorem viverra, quis auctor ante sagittis. Ut lobortis dapibus orci, sit amet porttitor est mattis at. Vestibulum euismod dolor odio, nec ultricies erat faucibus sed. Nulla hendrerit mauris ac nisl mattis, in tristique ipsum semper. Nam ante nibh, dignissim at lorem eu, imperdiet imperdiet velit. Praesent at efficitur libero, ut rutrum leo.";

        public TestCaseV2()
        {
            _exampleTitle = Guid.NewGuid().ToString();
        }

        [Fact]
        public void When_administrator_publish_new_note_unregistered_user_can_view_that_note_on_a_blog()
        {
            Administrator.GoTo();
            Administrator.Login(Credentials.Valid);
            var url = Administrator.CreateNewPost(_exampleTitle, ExampleContent);
            Administrator.Logout();

            Note.GoTo(url);
            Note.AssertPostExist(_exampleTitle);
        }

        public void Dispose()
        {
            Browser.Get().Quit();
        }
    }

    internal class Browser
    {
        static Browser()
        {
            Driver = new ChromeDriver();
            Driver.Manage()
                .Window
                .Size = new System.Drawing.Size(800,1024);
            Driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(5);
        }
        private static readonly ChromeDriver Driver;

        internal static ChromeDriver Get()
        {
            return Driver;
        }
    }

    internal class Credentials
    {
        public static WpCredentials Valid => new WpCredentials
        {
            UserName = "autotestdotnet@gmail.com",
            Password = "codesprinters2016"
        };

        public static WpCredentials InValid => new WpCredentials
        {
            UserName = "sdfhskflhauieayor",
            Password = "jcn,zmcjkshdiuyioerwurwoczh"
        };
    }

    public class WpCredentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    internal class Note
    {
        private static readonly ChromeDriver Driver = Browser.Get();

        internal static void AssertPostExist(string expectedTitle)
        {
            var singlePostTitle = Driver.FindElementByXPath("//header/h1").Text;
            Assert.Equal(singlePostTitle, expectedTitle);
        }

        internal static void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }

    internal class Administrator
    {
        private static readonly ChromeDriver Driver = Browser.Get();

        internal static string CreateNewPost(string exampleTitle, string exampleContent)
        {
            Driver.FindElementByCssSelector(".wp-menu-image.dashicons-before.dashicons-admin-post").Click();
            Driver.FindElementByLinkText("Add New").Click();

            var title = Driver.FindElementById("title");
            title.Click();
            title.SendKeys(exampleTitle);

            var content = Driver.FindElementById("content");
            content.Click();
            content.SendKeys(exampleContent);

            Driver.FindElementById("publish").Click();

            WaitForElementPresent(By.Id("sample-permalink"), 20);
            return Driver.FindElementById("sample-permalink")
                .FindElement(By.XPath("a")).GetAttribute("href");
        }

        internal static void GoTo()
        {
            Driver.Navigate()
                .GoToUrl("https://autotestdotnet.wordpress.com/wp-admin");
        }

        internal static void Login(WpCredentials credentials)
        {
            var login = Driver.FindElementById("user_login");
            login.Click();
            login.SendKeys(credentials.UserName);

            var pass = Driver.FindElementById("user_pass");
            pass.Click();
            pass.SendKeys(credentials.Password);

            Driver.FindElementById("wp-submit").Click();
            
        }

        internal static void Logout()
        {
            var logout = Driver.FindElementByCssSelector(".avatar.avatar-32");
            logout.Click();

            Driver.FindElementByCssSelector(".ab-sign-out").Click();
        }

        protected static void WaitForElementPresent(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver,
                TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected static void WaitForElementPresent(IWebElement by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver,
                TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }

}
