using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

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
   
        public void Test(LoginPodatci loginPodatci)
        {

            Login login = new Login(_driver);

            login.ClickLogin();

            login.LoginUsera(loginPodatci.UserName, loginPodatci.Password);
            
            Thread.Sleep(1000);
            
            login.Provjera();
        }
        public static IEnumerable<LoginPodatci> LoginUsera()
        {
            string solutionDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string putanja = Path.Combine(solutionDirectory, "useri.json");
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
            try
            {
                    _driver.Quit();
                    _driver.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}