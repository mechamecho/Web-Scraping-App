using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Web_Scraping_App
{
    public class Drivers
    { 
        public static IWebDriver Driver = new ChromeDriver(SetDriverOptions());
        public static WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        private static ChromeOptions SetDriverOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            return options;
        }
    }
}
