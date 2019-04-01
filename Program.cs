using System;
using SplashKitSDK;

enum MenuOption
{
    Withdraw,
    Deposit,
    Transfer,
    Print,
    Quit
}

public class Program
{
    public static void Main()
    {
        //Creats an account object
        Account andrewAccount = new Account("Andrews Account", 100);
        Account jakeAccount = new Account("Jakes Account", 500);

        MenuOption userSelection;

        do
        {
            userSelection = ReadUserOption();

            switch (userSelection)
            {
                case MenuOption.Withdraw:
                    DoWithdraw(andrewAccount);
                    break;
                case MenuOption.Deposit:
                    DoDeposit(andrewAccount);
                    break;
                case MenuOption.Transfer:
                    DoTransfer(jakeAccount, andrewAccount);
                    break;
                case MenuOption.Print:
                    DoPrint(andrewAccount, jakeAccount);
                    break;
                case MenuOption.Quit:
                    break;
            }
        } while (userSelection != MenuOption.Quit);
    }
    private static MenuOption ReadUserOption()
    {
        int option;

        Console.WriteLine("-----MENU-----");
        Console.WriteLine("1 for Withdraw");
        Console.WriteLine("2 for Deposit");
        Console.WriteLine("3 for Account transfer");
        Console.WriteLine("4 for Balance");
        Console.WriteLine("5 for Quit");
        Console.WriteLine("--------------");

        do
        {
            Console.WriteLine("Select Option 1 - 5");
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a number");
                option = -1;
            }

        } while (option < 1 || option > 5);

        return (MenuOption)(option - 1);
    }

    private static void DoTransfer(Account fromAccount, Account toAccount)
    {
        Console.WriteLine("Transfering from Jake's to Andrew's Account");
        Console.Write("Enter amount: $");

        decimal amount = Convert.ToDecimal(Console.ReadLine());

        TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, amount);
        transfer.Execute();
    }

    private static void DoDeposit(Account account)
    {

        decimal ammount;
        do
        {
            Console.Write("Enter deposit ammount: $");
            try
            {
                ammount = Convert.ToDecimal(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a number");
                ammount = -1;
            }
        } while (ammount == -1);
        DepositTransaction deposit = new DepositTransaction(account, ammount);
        deposit.Execute();

        if (deposit.Success == true)
        {
            deposit.Print();
        }
        else
        {
            Console.WriteLine("Deposit Declined");
        }

    }
    private static void DoWithdraw(Account account)
    {
        decimal ammount;
        do
        {
            Console.Write("Enter withdraw ammount: $");

            try
            {
                ammount = Convert.ToDecimal(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a number");
                ammount = -1;
            }
        } while (ammount == -1);

        WithdrawTransaction withdraw = new WithdrawTransaction(account, ammount);

        withdraw.Execute();

        if (withdraw.Success == true)
        {
            withdraw.Print();
        }
        else
        {
            Console.WriteLine("Withdraw Declined");
        }
    }
    private static void DoPrint(Account andrewAccount, Account jakeAccount)
    {
        andrewAccount.PrintAccount();
        jakeAccount.PrintAccount();
    }
}

