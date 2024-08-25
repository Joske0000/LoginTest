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

        IWebElement Botun => _driver.FindElement(By.Id("submit"));

        IWebElement GreskaMessage => _driver.FindElement(By.Id("error"));

        IWebElement LogoutButton => _driver.FindElement(By.LinkText("Log out"));
        

        public void ClickLogin()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(LoginLink)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(Test)).Click();
        }
        public void LoginUsera(string username, string password)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));
            UserName.Posaljitekst(username);
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
            Password.Posaljitekst(password);
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submit")));
            Botun.Submit();
        }
        
        public void Provjera()
        {
            bool logBotun = false;
            bool pogreska = false;

            try
            {
                logBotun = LogoutButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                logBotun = false;
            }
            try
            {
                pogreska = GreskaMessage.Text.Contains("Your password is invalid!");
            }
            catch (NoSuchElementException)
            {
                pogreska = false;
            }
            
            if (logBotun)
            {
                Assert.Pass("Uspješan login");
            }
            else if (pogreska)
            {
                Assert.Pass("Neuspješan login: Pogrešna lozinka");
            }
            else
            {
                Assert.Pass("Neuspješan login: Pogrešno korisničko ime");
            }
        }
    }
}
