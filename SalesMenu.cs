using System.Security.Cryptography.X509Certificates;
using FileManagerUtilities;

namespace SalesMenuUtilities
{
    public class SalesMenu
    {
        public static string[] salesDataString { get; set; }
        public static double[] salesDataArray { get; set; }
        public SalesMenu(string[] salesDataString, double[] salesDataArray)
        {
            SalesMenu.salesDataString = salesDataString;
            SalesMenu.salesDataArray = salesDataArray;
        }

        public static void displaySalesMenu()
        {
            string userChoiceString;
            int userChoice;
            Console.WriteLine("\n*** Sales Menu ***");
            Console.WriteLine("1. Add New Sales Entry");
            Console.WriteLine("2. Display Average");
            Console.WriteLine("3. Display Largest Value");
            Console.WriteLine("4. Display Smallest Value");
            Console.WriteLine("5. Return to Main Menu");

            do
            {
                Console.Write("\nEnter your choice: ");
                userChoiceString = Console.ReadLine();
                if (int.TryParse(userChoiceString, out userChoice) && userChoice >= 1 && userChoice <= 5)
                {
                    break;
                }
                Console.WriteLine("Invalid menu choice. Please enter a number between 1 and 5.");
            } while (true);

            switch (userChoice)
            {
                case 1:
                    addNewSalesEntryToArray();                   
                    break;
                case 2:
                    getAverage();
                    displaySalesMenu(); 
                    break;
                case 3:
                    getLargestValue();
                    displaySalesMenu();
                    break;
                case 4:
                    getSmallestValue();
                    displaySalesMenu();
                    break;
                case 5:                   
                    break;
            }
        }

        public static void addNewSalesEntryToArray()
        {
            double newSalesEntry;
            bool isValid = false;
            do
            {
                Console.Write("\nEnter a new sales entry: ");
                string newSalesEntryString = Console.ReadLine();

                if (double.TryParse(newSalesEntryString, out newSalesEntry))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid sales entry. Please enter a valid sales entry value.");
                }
            } while (!isValid);

            double[] newArray = new double[SalesMenu.salesDataArray.Length + 1];
            Array.Copy(SalesMenu.salesDataArray, newArray, SalesMenu.salesDataArray.Length);
            newArray[newArray.Length - 1] = newSalesEntry;
            SalesMenu.salesDataArray = newArray;
            FileManagerUtilities.FileManager.writeSalesDataToFile("Sales.txt", SalesMenu.salesDataArray);        

            Console.WriteLine("\nNew sales entry added successfully.");
            string userChoiceString;
            int userChoice;

            do
            {
                Console.WriteLine("\n1.Add another sales entry");
                Console.WriteLine("2.Return to Main Menu");

                Console.Write("Enter your choice: ");
                userChoiceString = Console.ReadLine();

                if (int.TryParse(userChoiceString, out userChoice) && userChoice >= 1 && userChoice <= 2)
                {
                    break;
                }
                Console.WriteLine("Invalid menu choice. Please enter 1 or 2.");

            } while (true);

            switch (userChoice)
            {
                case 1:
                    addNewSalesEntryToArray();
                    break;
                case 2:                  
                    break;
            }
        }

        public static void getAverage()
        {
            double average = 0;
            int salesCount = 0;
            double totalSales = 0;

            for (int i = 0; i < salesDataString.Length; i++)
            {
                salesDataArray[i] = double.Parse(salesDataString[i]);
            }

            for (salesCount = 0; salesCount < salesDataArray.Length; salesCount++)
            {
                totalSales += salesDataArray[salesCount];
            }
            average = totalSales / salesCount;
            Console.WriteLine($"\nThe average sales value is {average}");
        }

        public static void getLargestValue()
        {
            double largest = salesDataArray.Max();
            Console.WriteLine($"\nThe largest sales value is {largest}");
        }

        public static void getSmallestValue()
        {
            double smallest = salesDataArray.Min();
            Console.WriteLine($"\nThe smallest sales value is {smallest}");
        }       
    }
}
