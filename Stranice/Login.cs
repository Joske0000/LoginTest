using OpenQA.Selenium;
using NunitTest.Metode;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NunitTest.Stranice
{
    public class Login
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Login (IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        IWebElement LoginLink => _driver.FindElement(By.XPath("//*[@id=\"menu-item-20\"]/a"));

        IWebElement Test => _driver.FindElement(By.XPath("//*[@id=\"loop-container\"]/div/article/div[2]/div[1]/div[1]/p/a"));

        IWebElement UserName => _driver.FindElement(By.Id("username"));

        IWebElement Password => _driver.FindElement(By.Id("password"));

        IWebElement Button => _driver.FindElement(By.Id("submit"));

        IWebElement ErrorMessage => _driver.FindElement(By.Id("error"));

        IWebElement LogoutButton => _driver.FindElement(By.LinkText("Log out"));
        

        public void ClickLogin()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(LoginLink)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(Test)).Click();
        }
        public void UserLogin(string username, string password)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));
            UserName.SendText(username);
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
            Password.SendText(password);
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submit")));
            Button.Submit();
        }
        
        public void LoginCheck()
        {
            bool logButton = false;
            bool Error = false;

            try
            {
                logButton = LogoutButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                logButton = false;
            }
            try
            {
                Error = ErrorMessage.Text.Contains("Your password is invalid!");
            }
            catch (NoSuchElementException)
            {
                Error = false;
            }
            
            if (logButton)
            {
                Assert.Pass("Successful login");
            }
            else if (Error)
            {
                Assert.Pass("Unsuccessful login: wrong password");
            }
            else
            {
                Assert.Pass("Unsuccessful login: wrong user name");
            }
        }
    }
}
