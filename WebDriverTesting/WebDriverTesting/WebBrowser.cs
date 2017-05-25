using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace WebDriverTesting
{
    internal class WebBrowser
    {
        static WebBrowser()
        {
            Driver = new FirefoxDriver();
            //Driver = new ChromeDriver();
            Driver.Manage()
                .Window
                .Size = new System.Drawing.Size(Configuration.BrowserWidth, 
                                                Configuration.BrowserHeight);
            Driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(Configuration.ImplicitWait);
        }        

        public static IWebDriver Driver;
    }
}