using System.Text.Json;
using NunitTest.Podatci;
using NunitTest.Stranice;

namespace NunitTest
{
    [Parallelizable]
    public class Tests : SetupDrivera
    {
        [Test]
        [TestCaseSource(nameof(LoginUsera))]
        [Parallelizable]
        public void TestChrome(LoginPodatci loginPodatci)
        {
            Setup("chrome");

            Login login = new Login(_driver);

            login.ClickLogin();

            login.LoginUsera(loginPodatci.UserName, loginPodatci.Password);

            login.Provjera(); 
        }
        [Test]
        [TestCaseSource(nameof(LoginUsera))]
        [Parallelizable]
        public void TestFirefox(LoginPodatci loginPodatci)
        {
            Setup("firefox");

            Login login = new Login(_driver);

            login.ClickLogin();

            login.LoginUsera(loginPodatci.UserName, loginPodatci.Password);

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
    }
}