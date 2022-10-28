using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Diagnostics;

namespace TypeTestAutomator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = $"[{DateTime.Now }] TypeTestAutomator by https://github.com/CabboShiba";
            Log("PRESS ENTER TO START...");
            Console.ReadLine();
            Log("Starting...");
            Thread.Sleep(500);
            Automation.LoadBrowser("https://www.livechat.com/typing-speed-test/#/");
            Thread.Sleep(1000);
            for (int i = 0; i < 507; i++)
            {
                Thread t = new Thread(new ThreadStart(Automation.SubmitWord));
                t.Start();
                Thread.Sleep(32); // best delay to never miss a word
            }
            Console.WriteLine();
            Log("-------------------------------");
            Log($"Challenge completed in: {60 - Automation.GetTime()} Seconds");
            Log("Total WPM: " + Automation.GetWPM());
            Log("Total CharPM: " + Automation.GetCharPM());
            Log($"Accuracy: {Automation.GetAccuracy()}%");
            Log("-------------------------------");
            Automation.driver.Quit();
            Log("Finished. Press enter to leave...");
            Console.ReadLine();
            Process.GetCurrentProcess().Kill();
        }

        public static void Log(string Data)
        {
            Console.WriteLine($"[{DateTime.Now}] {Data}");
        }
    }
}
