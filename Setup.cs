using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NunitTest;

public class SetupDrivera    
{
public IWebDriver _driver;

public void Setup(string browserName)
    {
        if (browserName.Equals("chrome"))
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-search-engine-choice-screen");
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://practicetestautomation.com/");
        }
        else if (browserName.Equals("firefox"))
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--disable-search-engine-choice-screen");
            options.AddArgument("--headless");
            _driver = new FirefoxDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://practicetestautomation.com/");
        }
        else
        {
            throw new Exception("Unsupported browser");
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

    
