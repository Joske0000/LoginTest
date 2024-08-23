using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Net;
using NUnit.Framework.Legacy;
using SeleniumExtras.WaitHelpers;


namespace NunitTest.Stranice
{
    public class Login
    {
        private readonly IWebDriver driver;

        public Login (IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement LoginLink => driver.FindElement(By.XPath("//*[@id=\"menu-item-20\"]/a"));

        IWebElement Test => driver.FindElement(By.XPath("//*[@id=\"loop-container\"]/div/article/div[2]/div[1]/div[1]/p/a"));

        IWebElement UserName => driver.FindElement(By.Id("username"));

        IWebElement Password => driver.FindElement(By.Id("password"));

        IWebElement Botun => driver.FindElement(By.Id("submit"));

        IWebElement GreskaMessage => driver.FindElement(By.XPath("//*[@id=\"error\"]"));
        
        IWebElement LogoutButton => driver.FindElement(By.LinkText("Log out"));
        

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
            bool LogBotun = false;
            bool Pogreska = false;

            try
            {
                LogBotun = LogoutButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                LogBotun = false;
            }
            try
            {
                Pogreska = GreskaMessage.Text.Contains("Your password is invalid!");
            }
            catch (NoSuchElementException)
            {
                Pogreska = false;
            }
            
            if (LogBotun)
            {
                ClassicAssert.Pass("Uspješan login");
            }
            else if (Pogreska)
            {
                ClassicAssert.Pass("Neuspješan login: Pogrešna lozinka");
            }
            else
            {
                ClassicAssert.Pass("Neuspješan login: Pogrešno korisničko ime");
            }
        }
    }
}
