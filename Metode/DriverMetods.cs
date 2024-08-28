using OpenQA.Selenium;

namespace NunitTest.Metode
{
    public static class DriverMetods
    {
        public static void SendText(this IWebElement lokator, string text)
        {
            lokator.Clear();
            lokator.SendKeys(text);
        }
    }
}
