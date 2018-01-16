using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Web_Scraping_App
{
    class GetSummaryData
    {
        public static void FirstTrial()
        {
            var login= new LogIn("nimiko_chan", "DRZ!2#k");
            login.LogUserIn();
            var summaryTable = GetTable();

            var wait = new WebDriverWait(Drivers.Driver, TimeSpan.FromSeconds(10));
            var row = summaryTable.FindElement(By.XPath(".//tr[1]"));

            var numberOfRows = summaryTable.FindElements(By.XPath(".//tr")).Count;

            //Time of Scraping
            var scrapeTime = DateTime.Now;
            Console.WriteLine(scrapeTime);

            //Scraping all the table data 
            for (var i = 1; i <= numberOfRows; i++)
            {
                var rowXPath = $"//tr[{i}]";
                var symbolName = wait.Until(d => row.FindElement(By.XPath(rowXPath + "/td[1]/span/a")).Text);
                var lastPrice = summaryTable.FindElement(By.XPath(rowXPath + "/td[2]/span")).Text;
                var changePrct = row.FindElement(By.XPath(rowXPath + "/td[4]/span")).Text;
                var volume = row.FindElement(By.XPath(rowXPath + "/td[7]/span")).Text;
                var avgVolume = row.FindElement(By.XPath(rowXPath + "/td[9]")).Text;

                Console.WriteLine($"{symbolName}\t{lastPrice}\t" +
                                  $"{changePrct}\t {volume}\t" +
                                  $"\t{avgVolume}");
            }

            Drivers.Driver.Close();
        }

        private static IWebElement GetTable()
        {
            Drivers.Driver.Navigate()
                .GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");

            Drivers.Wait= new WebDriverWait(Drivers.Driver, TimeSpan.FromSeconds(10));
            var table = Drivers.Wait.Until(d => d.FindElement(By.XPath("//table[@data-test='contentTable']/tbody")));
            return table;
        }
    }
}
