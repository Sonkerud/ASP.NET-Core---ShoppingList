using ShoppingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        public static string priceOfVara;
        public static string nameOfVara;
        public static string userInput = "Y";
        public static string userInputToAddMore = "Y";

        static void Main(string[] args)
        {
            Console.WriteLine("Din inköpslista. Lägg till vara nedan. Namnge varan 'exit' när du är färdig.");

            while (userInputToAddMore == "Y")
            {
                while (userInput != "exit")
                {
                    userInput = CreateVara();
                }
                DataOutput();
                Console.WriteLine("\nÖnskar du lägga till fler varor? (Y)es / (N)o");
                userInputToAddMore = Console.ReadLine();
                if (userInputToAddMore == "Y")
                {
                    Console.Clear();
                    OutputList();
                    userInput = "Y";
                }
            }
        }

        public static string CreateVara()
        {
            Console.WriteLine("\nNamn på vara (exit för att avsluta):  ");
            nameOfVara = Console.ReadLine();
            if (nameOfVara != "exit")
            {
                bool outcomeOfParse = false;
                while (!outcomeOfParse)
                {
                    Console.WriteLine("Ange Pris: ");
                    priceOfVara = Console.ReadLine();
                    outcomeOfParse = decimal.TryParse(priceOfVara, out decimal tryPrice);
                }
                VarorProcessor.AddVara(VarorModel.listOfVaror, nameOfVara, priceOfVara);
            }
            return nameOfVara;
        }

        public static void DataOutput()
        {
            Console.Clear();
            OutputList();
            OutputSumCheapestExpensive();
        }

        public static void OutputList()
        {
            Console.WriteLine("Dina varor:");
            foreach (var item in VarorModel.listOfVaror)
            {
                Console.WriteLine($"{item.Name} Pris: {item.Price}");
            }
        }

        public static void OutputSumCheapestExpensive()
        {
            Console.WriteLine($"\nSumma i korgen: {VarorProcessor.Sum(VarorModel.listOfVaror)} kr");

            Console.WriteLine($"\nBilligaste vara/varor:");
            foreach (var item in VarorProcessor.Cheapest(VarorModel.listOfVaror))
            {
                Console.WriteLine($"{item.Name} - Pris: {item.Price}");
            }

            Console.WriteLine($"\nDyraste vara/varor:");
            foreach (var item in VarorProcessor.MostExpensive(VarorModel.listOfVaror))
            {
                Console.WriteLine($"{item.Name} - Pris: {item.Price}");
            }

        }
    }
}