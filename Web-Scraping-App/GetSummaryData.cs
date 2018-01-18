using System;
using OpenQA.Selenium;

namespace Web_Scraping_App
{

    class GetSummaryData
    {
        private static readonly IWebDriver Driver = Drivers.Driver;

        public static void GetData()
        {
            var summaryTable = GetTable();

            //Time of Scraping
            var scrapeTime = DateTime.Now;
            Console.WriteLine(scrapeTime);

            //GetTableData
            var numberOfRows = summaryTable.FindElements(By.XPath(".//tr")).Count;
            GetTableData(numberOfRows, scrapeTime);

            Driver.Close();
        }

        private static void GetTableData(int numberOfRows, DateTime scrapeTime)
        {
            using (var db = new SummaryContext())
            {
                //Scraping all the table data 
                for (var i = 1; i <= numberOfRows; i++)
                {
                    var rowXPath = $"//tr[{i}]";
                    var symbolName = Drivers.Wait.Until(d => Driver.FindElement(By.XPath(rowXPath + "/td[1]/span/a")).Text);
                    var lastPrice = Driver.FindElement(By.XPath(rowXPath + "/td[2]/span")).Text;
                    var changePrct = Driver.FindElement(By.XPath(rowXPath + "/td[4]/span")).Text;
                    var volume = Driver.FindElement(By.XPath(rowXPath + "/td[7]/span")).Text;
                    var avgVolume = Driver.FindElement(By.XPath(rowXPath + "/td[9]")).Text;

                    Console.WriteLine($"{symbolName}\t{lastPrice}\t" +
                                      $"{changePrct}\t {volume}\t" +
                                      $"\t{avgVolume}");
                    var summary = new Summary()
                    {
                        SummaryScrapeTime = scrapeTime,
                        SymbolName = symbolName,
                        LastPrice = lastPrice,
                        ChangePercentage = changePrct,
                        Volume = volume,
                        AverageVolume = avgVolume
                    };

                    db.Summaries.Add(summary);
                    db.SaveChanges();
                }
            }

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
