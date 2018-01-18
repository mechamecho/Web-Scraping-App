using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Web_Scraping_App
{
    public class LogIn
    {
        private readonly string _username;
        private readonly string _password;

        public LogIn(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public void LogUserIn()
        {

            Drivers.Driver.Navigate()
                .GoToUrl("https://login.yahoo.com/config/login?.intl=us&.lang=en-US&.src=finance&.done=https%3A%2F%2Ffinance.yahoo.com%2F");

            #region Locate Username and Button
            var userNameField = Drivers.Driver.FindElement(By.Id("login-username"));
            var nextButton = Drivers.Driver.FindElement(By.Id("login-signin"));
            #endregion

            userNameField.SendKeys(_username);
            nextButton.Click();

            #region Locate Password field and Sign In Button
            var passwordField = Drivers.Wait.Until(d => d.FindElement(By.Id("login-passwd")));
            var signInButton = Drivers.Driver.FindElement(By.Id("login-signin"));
            #endregion

            passwordField.SendKeys(_password);
            signInButton.Click();
        }
    }
}
