using OpenQA.Selenium;
using NunitTest.Metode;

namespace NunitTest.Stranice
{
    public class Login
    {
        private readonly IWebDriver _driver;

        public Login (IWebDriver driver)
        {
            this._driver = driver;
        }

        IWebElement LoginLink => _driver.FindElement(By.XPath("//*[@id=\"menu-item-20\"]/a"));

        IWebElement Test => _driver.FindElement(By.XPath("//*[@id=\"loop-container\"]/div/article/div[2]/div[1]/div[1]/p/a"));

        IWebElement UserName => _driver.FindElement(By.Id("username"));

        IWebElement Password => _driver.FindElement(By.Id("password"));

        IWebElement Botun => _driver.FindElement(By.Id("submit"));

        IWebElement GreskaMessage => _driver.FindElement(By.XPath("//*[@id=\"error\"]"));
        
        IWebElement LogoutButton => _driver.FindElement(By.LinkText("Log out"));

        public void ClickLogin()
        {
            LoginLink.Click();
            Test.Click();
        }
        public void LoginUsera(string username, string password)
        {
            UserName.Posaljitekst(username);
            Password.Posaljitekst(password);
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
