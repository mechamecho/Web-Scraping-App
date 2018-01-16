using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Web_Scraping_App
{
    class GetSummaryData
    {
        public static void GetData()
        {

            var summaryTable = GetTable();

            var driver = Drivers.Driver;

            var numberOfRows = summaryTable.FindElements(By.XPath(".//tr")).Count;

            //Time of Scraping
            var scrapeTime = DateTime.Now;
            Console.WriteLine(scrapeTime);

            //Scraping all the table data 
            for (var i = 1; i <= numberOfRows; i++)
            {
                
                var rowXPath = $"//tr[{i}]";
                var symbolName = Drivers.Wait.Until(d => driver.FindElement(By.XPath(rowXPath + "/td[1]/span/a")).Text);
                var lastPrice = driver.FindElement(By.XPath(rowXPath + "/td[2]/span")).Text;
                var changePrct = driver.FindElement(By.XPath(rowXPath + "/td[4]/span")).Text;
                var volume = driver.FindElement(By.XPath(rowXPath + "/td[7]/span")).Text;
                var avgVolume = driver.FindElement(By.XPath(rowXPath + "/td[9]")).Text;

                Console.WriteLine($"{symbolName}\t{lastPrice}\t" +
                                  $"{changePrct}\t {volume}\t" +
                                  $"\t{avgVolume}");
            }

            driver.Close();
        }

        private static void GetTableData()
        {
            
        }

        private static IWebElement GetTable()
        {
            var login = new LogIn("nimiko_chan", "DRZ!2#k");
            login.LogUserIn();

            Drivers.Driver.Navigate()
                .GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");

            var table = Drivers.Wait.Until(d => d.FindElement(By.XPath("//table[@data-test='contentTable']/tbody")));
            return table;
        }
    }
}
