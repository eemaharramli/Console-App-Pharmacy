using System;
using Pharmacy.Models;
using Pharmacy.Utils;

namespace Pharmacy
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isAdmin = false;
            int drugCount;
            Extensions.Print("Please choose the language   eng / ru / aze", ConsoleColor.DarkYellow);
            string language = Console.ReadLine();
            Language lang = language.Equals("eng") ? Language.Eng : language.Equals("ru") ? Language.Rus : Language.Aze;
            
            LanguageDictionary text = new LanguageDictionary(lang);
            
                Methods.Welcome(language);
                Console.WriteLine();
                CheckCredentials:
                Extensions.Print(text.Get("inputUsrNm"), ConsoleColor.Green);
                string username = Console.ReadLine();
                Extensions.Print(text.Get("inputPswd"),ConsoleColor.Green);
                string password = Console.ReadLine();
                Extensions.Print(text.Get("checkCredentials"), ConsoleColor.Yellow);
                Methods.Loading(language);
                
                Console.WriteLine();
                if (Methods.CheckCredentials(username, password))
                {
                    Extensions.Print(text.Get("welcomeAd"), ConsoleColor.Green);
                    isAdmin = true;
                }
                else Extensions.Print(text.Get("welcomeUs"), ConsoleColor.Yellow);
                
                Models.Pharmacy pharmacy = new Models.Pharmacy("Pharmacy online");

                while (true)
                {
                    StartApp:
                    Extensions.Print(text.Get("menuTitle"), ConsoleColor.Green);
                    Extensions.Print(text.Get("menuTitle") +
                                     text.Get("add") +
                                     text.Get("show") +
                                     text.Get("searchDrug") +
                                     text.Get("buy") +
                                     text.Get("showDrugsByCategory") +
                                     text.Get("showCategories") +
                                     text.Get("logoff") +
                                     text.Get("exit"), ConsoleColor.Yellow);
                    bool checkAnswer = int.TryParse(Console.ReadLine(), out int result);
                    if (checkAnswer && (result >= 1 && result <= 8))
                    {
                        if (result == 8)
                        {
                            Extensions.Print(text.Get("bye"), ConsoleColor.Green);
                            break;
                        }
                        else
                        {
                            switch (result)
                            {
                                case 1:
                                    Console.Clear();
                                    if (!isAdmin)
                                    {
                                        Extensions.Print(text.Get("errorAdd"), ConsoleColor.Red);
                                        goto StartApp;
                                    }
                                    Extensions.Print(text.Get("inputDrugName"), ConsoleColor.Yellow);
                                    string drugName = Console.ReadLine();
                                    if (drugName.Length == 0)
                                    {
                                        Extensions.Print(text.Get("emptyName"), ConsoleColor.Red);
                                        goto case 1;
                                    }
                                    checkAnswer = int.TryParse(drugName, out int tempName);
                                    if (checkAnswer)
                                    {
                                        Extensions.Print(text.Get("drugNameError"), ConsoleColor.Red);
                                        goto case 1;
                                    }

                                    Extensions.Print(text.Get("inputDrugType"), ConsoleColor.Yellow);
                                    string drugType = Console.ReadLine();
                                    if (drugType.Length == 0)
                                    {
                                        Extensions.Print(text.Get("emptyType"), ConsoleColor.Red);
                                        goto case 1;
                                    }
                                    checkAnswer = int.TryParse(drugType, out int tempType);
                                    if (checkAnswer)
                                    {
                                        Extensions.Print(text.Get("drugTypeError"), ConsoleColor.Red);
                                        goto case 1;
                                    }

                                    Extensions.Print(text.Get("inputDrugCount"), ConsoleColor.Yellow);
                                    while (!int.TryParse(Console.ReadLine(), out drugCount))
                                    {
                                        Extensions.Print(text.Get("drugCountError"), ConsoleColor.Red);
                                    }
                                    if (pharmacy.AddDrug(new Drug(drugName, new DrugType(drugType), drugCount)))
                                    {
                                        Extensions.Print(text.Get("newDrugMsg"), ConsoleColor.Green);
                                        pharmacy.ShowDrugItems();
                                    }
                                    else
                                    {
                                        Extensions.Print(text.Get("oldDrugMsg"), ConsoleColor.Magenta);
                                        pharmacy.ShowDrugItems();
                                    }

                                    break;
                                case 2:
                                    Console.Clear();
                                    if (!pharmacy.ShowDrugItems())
                                    {
                                        Extensions.Print(text.Get("emptyPharmacy"), ConsoleColor.Red);
                                        goto case 1;
                                    }

                                    break;
                                case 3:
                                    Console.Clear();
                                    Extensions.Print(text.Get("inputDrugName"), ConsoleColor.Yellow);
                                    drugName = Console.ReadLine();
                                    pharmacy.InfoDrug(drugName);
                                    break;
                                case 4:
                                    Console.Clear();
                                    if (pharmacy.Drugs.Count == 0)
                                    {
                                        Extensions.Print(text.Get("emptyPharmacy"), ConsoleColor.Red);
                                        break;
                                    }

                                    Extensions.Print(text.Get("showDrugs"), ConsoleColor.Cyan);
                                    pharmacy.ShowDrugItems();
                                    Extensions.Print(text.Get("inputDrugName"), ConsoleColor.Yellow);
                                    drugName = Console.ReadLine();
                                    Drug drug = pharmacy.CheckDrug(drugName);
                                    if (drug != null)
                                    {
                                        Extensions.Print(string.Format(text.Get("inputDrugCountIndex"), drugName), ConsoleColor.Red);
                                        checkAnswer = int.TryParse(Console.ReadLine(), out drugCount);
                                        if (!checkAnswer)
                                        {
                                            Extensions.Print(text.Get("drugCountError"), ConsoleColor.Red);
                                        }
                                        Extensions.Print(string.Format(text.Get("drugCostMsg"), drugName, drugCount * drug.Price), ConsoleColor.Yellow);
                                        checkAnswer = int.TryParse(Console.ReadLine(), out int drugCost);
                                        if (!pharmacy.SaleDrug(drugName, drugCost, drugCount))
                                        {
                                            Extensions.Print(string.Format(text.Get("QuantityError"), drugName), ConsoleColor.Red);
                                        }
                                        else
                                        {
                                            Extensions.Print(text.Get("successfulPurchase"), ConsoleColor.Red);
                                        }
                                    }
                                    else
                                    {
                                        Extensions.Print(text.Get("warningDrug"), ConsoleColor.Red);
                                    }
                                    break;
                                case 5:
                                    if (pharmacy.Drugs.Count == 0)
                                    {
                                        Extensions.Print(text.Get("emptyPharmacy"), ConsoleColor.Red);
                                    }
                                    Extensions.Print(text.Get("inputCategory"), ConsoleColor.Yellow);
                                    string drugCategory = Console.ReadLine();
                                    if (!pharmacy.ShowByCategory(drugCategory))
                                    {
                                        if (pharmacy.Drugs.Count == 0)
                                        {
                                            Extensions.Print(text.Get("emptyPharmacy"), ConsoleColor.Red);
                                            goto case 7;
                                        }
                                        Extensions.Print(string.Format(text.Get("drugCategoryError"), drugCategory),ConsoleColor.Red);
                                    }
                                    break;
                                case 6:
                                    if (pharmacy.Drugs.Count == 0)
                                    {
                                        Extensions.Print(text.Get("emptyPharmacy"), ConsoleColor.Red);
                                    }
                                    else
                                    {
                                        Extensions.Print(text.Get("showCategories"), ConsoleColor.Yellow);
                                        pharmacy.ShowCategory();
                                    }
                                    break;
                                case 7:
                                    isAdmin = false;
                                    goto CheckCredentials;
                            }
                        }
                    }
                    else
                    {
                        Extensions.Print(text.Get("wrongInput"), ConsoleColor.Red);
                    }
                }
            Console.Clear();
        }
    }
}
