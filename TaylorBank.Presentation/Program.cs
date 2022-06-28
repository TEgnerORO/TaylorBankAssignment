using System;
using TaylorBank.Presentation;
class Program
{
    static void Main()
    {
        // Display title
        System.Console.WriteLine("************** Taylor Bank **************");
        System.Console.WriteLine("::Login Page::");

        // Declarations for Username and Pass
        string userName = null, password = null;

        // Read userName from keyboard
        System.Console.Write("Username: ");
        userName = System.Console.ReadLine();

        // Read password from keyboard if userName is entered
        if (userName != "")
        {
            System.Console.Write("Password: ");
            password = System.Console.ReadLine();
        }
        else
        {
            System.Console.WriteLine("Invalid username or password");
        }

        // Validate credentials
        if (userName == "system" && password == "manager")
        {
            int mainMenuChoice = -1;
            do
            {
                System.Console.WriteLine("\n:::Main Menu:::");
                System.Console.WriteLine("1. Customers");
                System.Console.WriteLine("2. Accounts");
                System.Console.WriteLine("3. Funds Transfer");
                System.Console.WriteLine("4. Funds Transfer Statement");
                System.Console.WriteLine("5. Account Statement");
                System.Console.WriteLine("0. Exit");

                System.Console.WriteLine("Enter choice: ");
                mainMenuChoice = int.Parse(System.Console.ReadLine());

                switch (mainMenuChoice)
                {
                    case 1: CustomersMenu(); break;
                    case 2: AccountsMenu(); break;
                    case 3: // To Do
                        break;
                    case 4: // To Do
                        break;
                    case 5: // To Do
                        break;
                    case 0: // To Do
                        break;
                }
            } while (mainMenuChoice != 0);
        }

        // Exit system
        System.Console.WriteLine("Thank you, come again!");
        System.Console.ReadKey();
    }

    static void CustomersMenu()
    {
        // Declaration
        int customerMenuChoice = -1;

        // do-while menu loop
        do
        {
            System.Console.WriteLine("\n::::Customers Menu::::");
            System.Console.WriteLine("1. Add Customer");
            System.Console.WriteLine("2. Delete Customer");
            System.Console.WriteLine("3. Update Customer");
            System.Console.WriteLine("4. Search Customers");
            System.Console.WriteLine("5. View Customers");
            System.Console.WriteLine("0. Back to Main Menu");

            // User choice
            System.Console.WriteLine("Enter Choice: ");
            customerMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

            // Switch
            switch (customerMenuChoice)
            {
                case 1:
                    CustomerPresentation.AddCustomer();
                    break;
                case 2:
                    CustomerPresentation.DeleteCustomer();
                    break;
                case 3:
                    CustomerPresentation.UpdateCustomer();
                    break;
                case 4:
                    CustomerPresentation.SearchCustomers();
                    break;
                case 5:
                    CustomerPresentation.ViewCustomers();
                    break;
                case 0:
                    break;
            }
        } while (customerMenuChoice != 0);

        
    }

    static void AccountsMenu()
    {
        // Declaration
        int accountsMenuChoice = -1;

        // do-while menu loop
        do
        {
            System.Console.WriteLine("\n::::Accounts Menu::::");
            System.Console.WriteLine("1. Add Account");
            System.Console.WriteLine("2. Delete Account");
            System.Console.WriteLine("3. Update Account");
            System.Console.WriteLine("4. View Accounts");
            System.Console.WriteLine("5.View Account Statement");
            System.Console.WriteLine("0. Back to Main Menu");

            // User choice
            System.Console.WriteLine("Enter Choice: ");
            accountsMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

            // Switch
            switch (accountsMenuChoice)
            {
                case 1:
                    AccountPresentation.AddAccount();
                    break;
                case 2:
                    AccountPresentation.DeleteAccount();
                    break;
                case 3:
                    AccountPresentation.UpdateAccount();
                    break;
                case 4:
                    AccountPresentation.ViewAccounts();
                    break;
                case 5:
                    AccountPresentation.ViewAccountStatement();
                    break;
                case 0:
                    break;
            }
        } while (accountsMenuChoice != 0);


    }

    static void TransfersMenu()
    {
        // Declaration
        int transfersMenuChoice = -1;

        // do-while menu loop
        do
        {
            System.Console.WriteLine("\n::::Transfers Menu::::");
            System.Console.WriteLine("1. Create Transfer");
            System.Console.WriteLine("2. View Transfers");
            System.Console.WriteLine("0. Back to Main Menu");

            // User choice
            System.Console.WriteLine("Enter Choice: ");
            transfersMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

            // Switch
            switch (transfersMenuChoice)
            {
                case 1:
                    AccountPresentation.AddAccount();
                    break;
                case 2:
                    AccountPresentation.DeleteAccount();
                    break;
                case 0:
                    break;
            }
        } while (transfersMenuChoice != 0);
    }
}