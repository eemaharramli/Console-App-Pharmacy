using System;
using System.Threading;

namespace Pharmacy
{
    public class Methods
    {
        
        public static void Welcome(string language)
        {
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Green;
            string eng = "Welcome to online pharmacy";
            string ru = "Добро пожаловать в онлайн аптеку";
            string aze = "Online apteka xosh gelmisiniz";
            if (language == "eng")
            {
                foreach (char letter in eng)
                {
                    Console.Write(letter);
                    Thread.Sleep(200);
                }
            }else if (language == "ru")
            {
                foreach (char letter in ru)
                {
                    Console.Write(letter);
                    Thread.Sleep(200);
                }
            }else if (language == "aze")
            {
                foreach (char letter in aze)
                {
                    Console.Write(letter);
                    Thread.Sleep(200);
                }
            }else Console.WriteLine("Wrong input");
        }
        public static bool CheckCredentials(string username, string password)
        {
            string Username = "administrator";
            string Password = "@WSX3edc23";
            int counter = 0;
            if (username == Username && password == Password)
            { 
                return true;
            }
            return false;
        }
        public static void Loading(string language)
        {
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Green;
            switch (language)
            {
                case "eng":
                    Console.Write("Loading");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(500);
                        Console.Write('.');
                    }

                    Console.ResetColor();
                    break;
                case "ru":
                    Console.Write("Загрузка");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(500);
                        Console.Write('.');
                    }

                    Console.ResetColor();
                    break;
                case "aze":
                    Console.Write("Yuklenir");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(500);
                        Console.Write('.');
                    }
                    Console.ResetColor();
                    break;
            }
        }
    }
}