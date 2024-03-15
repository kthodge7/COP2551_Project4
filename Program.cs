using SalesMenuUtilities;
using ChargeAccountMenuUtilities;



namespace Project4
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] salesStringArray;
            string[] chargeAccountsStringArray;

            salesStringArray = File.ReadAllLines("Sales.txt");
            double[] salesDataArray = new double[salesStringArray.Length];

            for (int i = 0; i < salesStringArray.Length; i++)
            {
                salesDataArray[i] = double.Parse(salesStringArray[i]);
            }

            chargeAccountsStringArray = File.ReadAllLines("ChargeAccounts.txt");
            int[] chargeAccountsDataArray = new int[chargeAccountsStringArray.Length];

            for (int i = 0; i < chargeAccountsStringArray.Length; i++)
            {
                chargeAccountsDataArray[i] = int.Parse(chargeAccountsStringArray[i]);
            }

            SalesMenu salesMenu = new SalesMenu(salesStringArray, salesDataArray);
            ChargeAccountMenu chargeAccountMenu = new ChargeAccountMenu(chargeAccountsStringArray, chargeAccountsDataArray);

            bool exitProgram = false;
            do
            {
                string userChoiceString;
                int userChoice;

                Console.WriteLine("\n*** Main Menu ***");
                Console.WriteLine("1. Sales Menu");
                Console.WriteLine("2. Charge Accounts Menu");
                Console.WriteLine("3. Exit the program");      

                do
                {
                    Console.Write("\nEnter your choice: ");
                    userChoiceString = Console.ReadLine();

                    if (int.TryParse(userChoiceString, out userChoice) && userChoice >= 1 && userChoice <= 3)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid menu choice. Please enter a number between 1 and 3.");
                } while (true);

                switch (userChoice)
                {
                    case 1:
                        SalesMenu.displaySalesMenu();
                        break;
                    case 2:
                        ChargeAccountMenu.displayChargeAccountsMenu();
                        break;
                    case 3:
                        exitProgram = true;
                        break;
                }
            } while (!exitProgram);
           

        }
    }
}

