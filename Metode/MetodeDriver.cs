using OpenQA.Selenium;

namespace NunitTest
{
    public static class MetodeDriver
    {
        public static void Posaljitekst(this IWebElement lokator, string text)
        {
            lokator.Clear();
            lokator.SendKeys(text);
        }
    }
}
