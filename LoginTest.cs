using System.Text.Json;
using NunitTest.Podatci;
using NunitTest.Stranice;

namespace NunitTest
{
    public class Tests : SetupDriver
    {
        [Test]
        [TestCaseSource(nameof(LoginUser))]
        public void TestChrome(LoginData loginData)
        {
            Setup("chrome");

            Login login = new Login(_driver);

            login.ClickLogin();

            login.UserLogin(loginData.UserName, loginData.Password);

            login.LoginCheck(); 
        }
        [Test]
        [TestCaseSource(nameof(LoginUser))]
        public void TestFirefox(LoginData loginData)
        {
            Setup("firefox");

            Login login = new Login(_driver);

            login.ClickLogin();

            login.UserLogin(loginData.UserName, loginData.Password);

            login.LoginCheck(); 
        }

        public static IEnumerable<LoginData> LoginUser()
        {
            string solutionDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string path = Path.Combine(solutionDirectory, "useri.json");
            var read = File.ReadAllText(path);
            var loginData = JsonSerializer.Deserialize<List<LoginData>>(read);

            if (loginData == null)
            {
                yield break;
            }

            foreach (var korisnik in loginData)
            {
                if (korisnik.UserName != null && korisnik.Password != null)
                {
                    yield return korisnik;
                }
            }
        }
            
        }
    }