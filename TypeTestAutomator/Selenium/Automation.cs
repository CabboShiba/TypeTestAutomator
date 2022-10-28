using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeTestAutomator
{
    internal class Automation
    {
        public static IWebDriver driver = null;
        public static void LoadBrowser(string Link)
        {
            var DeviceDriver = ChromeDriverService.CreateDefaultService();
            DeviceDriver.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-infobars");
            options.AddArgument("--window-size=1200,1200");
            Automation.driver = new ChromeDriver(DeviceDriver, options);
            Automation.driver.Navigate().GoToUrl(Link);
            Automation.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        public static void SubmitWord()
        {
            string Word = Automation.driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div[2]/div[1]/div/span/div[2]/span/div/div[2]/div[2]/span[1]")).Text;
            driver.FindElement(By.XPath("//*[@id=\"test-input\"]")).SendKeys(Word + " ");
            Program.Log($"Obtained word: {Word}");
        }
        public static int GetTime()
        {
            int Time = int.Parse(driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div[2]/div[1]/div/span/div[1]/div/div[1]/div/div[1]")).Text);
            return Time;
        }
        public static int GetWPM()
        {
            int WPM = int.Parse(driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div[2]/div[1]/div/span/div[1]/div/div[2]/div[1]/div[1]")).Text);
            return WPM;
        }
        public static int GetCharPM()
        {
            int CPM = int.Parse(driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div[2]/div[1]/div/span/div[1]/div/div[2]/div[2]/div[1]")).Text);
            return CPM;
        }
        public static int GetAccuracy()
        {
            int Accuracy = int.Parse(driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div[2]/div[1]/div/span/div[1]/div/div[2]/div[3]/div[1]")).Text);
            return Accuracy;
        }
    }
}
