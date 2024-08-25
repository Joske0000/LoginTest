using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;
using NunitTest.Podatci;
using NunitTest.Stranice;

namespace NunitTest
{
    public class Tests: SetupDrivera
    {
        [Test]
        [TestCaseSource(nameof(LoginUseraBrowseri))]
        public void Test(LoginPodatci loginPodatci, string browserName)
        {
            Setup(browserName);

            Login login = new Login(_driver);

            login.ClickLogin();

            login.LoginUsera(loginPodatci.UserName, loginPodatci.Password);

            Thread.Sleep(1000);

            login.Provjera();
        }

        public static IEnumerable<object[]> LoginUseraBrowseri()
        {
            var loginUsera = LoginUsera().ToList();
            var browseri = Browseri().ToList();

            foreach (var korisnik in loginUsera)
            {
                foreach (var browser in browseri)
                {
                    yield return new object[] { korisnik, browser };
                }
            }
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

        public static IEnumerable<string> Browseri()
        {
            string[] browseri = { "chrome", "firefox" };
            foreach (var B in browseri)
            {
                yield return B;
            }
        }
    }
}