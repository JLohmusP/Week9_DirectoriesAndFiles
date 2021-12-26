using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"C:\Users\...\source\repos\DirectoriesAndFiles";
            string newDirectory = @"shoppingList";
            string fileNameNew = @"myshoppingList.txt";


            if (Directory.Exists($"{rootDirectory}\\{newDirectory}") && File.Exists($"{rootDirectory}\\{newDirectory}\\{fileNameNew}"))
            {
                Console.WriteLine($"Directory and file exist at {rootDirectory}.");
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}\\{newDirectory}");
                File.Create($"{rootDirectory}\\{newDirectory}\\{fileNameNew}");
            }


            string fileLocation = @"C:\Users\...\source\repos\DirectoriesAndFiles\shoppingList";
            string fileName = @"\\myshoppingList.txt";

            string[] arrayFromFile = File.ReadAllLines($"{fileLocation}{fileName}");

            List<string> myshoppingList = arrayFromFile.ToList<string>();

            bool loopActive = true;

            while (loopActive)
            {
                Console.WriteLine("Would you like to add a something to the shopping list? Y/N:");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if (userInput == 'y')
                {
                    Console.WriteLine("Enter what you need:");
                    string userNeed = Console.ReadLine();
                    myshoppingList.Add(userNeed);
                }
                else
                {
                    loopActive = false;
                    Console.WriteLine("Good bye! Below is your list.");
                }
            }


            foreach (string need in myshoppingList)
            {
                Console.WriteLine($"You need: {need}.");
            }

            File.WriteAllLines($"{fileLocation}{fileName}", myshoppingList);
        }
    }
}
