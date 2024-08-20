using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NunitTest.Stranice;
using System.Text.Json;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Legacy;


namespace NunitTest
{
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();

            options.AddArgument("--disable-search-engine-choice-screen");

            _driver = new ChromeDriver(options);

            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://practicetestautomation.com/");
        }


        [Test]
        [TestCaseSource(nameof(LoginUsera))]
   
        public void Test2(LoginPodatci loginPodatci)
        {

            Login login = new Login(_driver);

            login.ClickLogin();

            login.LoginUsera(loginPodatci.UserName, loginPodatci.Password);

            var Logiran = login.UspjesanLogin();

            ClassicAssert.IsTrue(Logiran);

            Thread.Sleep(2000);        
        }

        public static IEnumerable<LoginPodatci> LoginUsera()
        {
            string putanja = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "useri.json");
            var citaj = File.ReadAllText(putanja);

            var loginPodatci = JsonSerializer.Deserialize<List<LoginPodatci>>(citaj);

            foreach (var korisnik in loginPodatci)
            {
                yield return korisnik;
            }
                
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}