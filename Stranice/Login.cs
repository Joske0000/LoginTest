using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Net;


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

        public bool UspjesanLogin()
        {
            try
            {
                return LogoutButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Neuspjesan login, pogresno korisnicko ime ili lozinka");
                return false;
            }
        }
    }
}
