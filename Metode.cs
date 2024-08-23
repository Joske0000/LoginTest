using OpenQA.Selenium;


namespace NunitTest
{
    public static class Metode
    {
        public static void Click(this IWebElement lokator)
        {
            lokator.Click();
        }

        public static void Submit(this IWebElement lokator)
        {
            lokator.Submit();
        }

        public static void Posaljitekst(this IWebElement lokator, string text)
        {
            lokator.Clear();
            lokator.SendKeys(text);
        }
    }
}
