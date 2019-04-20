using System;
using SplashKitSDK;

enum MenuOption
{
    Withdraw,
    Deposit,
    Transfer,
    Print,
    NewAccount,
    Quit
}

public class Program
{
    public static void Main()
    {
        Bank bankOfAndrew = new Bank();

        MenuOption userSelection;
        do
        {
            userSelection = ReadUserOption();

            switch (userSelection)
            {
                case MenuOption.Withdraw:
                    DoWithdraw(bankOfAndrew);
                    break;
                case MenuOption.Deposit:
                    DoDeposit(bankOfAndrew);
                    break;
                case MenuOption.Transfer:
                    DoTransfer(bankOfAndrew);
                    break;
                case MenuOption.Print:
                    DoPrint(bankOfAndrew);
                    break;
                case MenuOption.NewAccount:
                    NewAccount(bankOfAndrew);
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
        Console.WriteLine("5 for New Account");
        Console.WriteLine("6 for Quit");
        Console.WriteLine("--------------");

        do
        {
            Console.WriteLine("Select Option 1 - 6");
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a number");
                option = -1;
            }

        } while (option < 1 || option > 6);

        return (MenuOption)(option - 1);
    }

    private static void NewAccount(Bank bank)
    {
        Console.WriteLine("New account name");
        string accountName = Console.ReadLine();

        Console.WriteLine("New account balance: ");
        decimal accountBalance = Convert.ToDecimal(Console.ReadLine());

        Account accountToAdd = new Account(accountName, accountBalance);
        bank.AddAccount(accountToAdd);
    }

    private static Account FindAccount(Bank fromBank)
    {
        Console.WriteLine("Enter account name: ");
        string name = Console.ReadLine();
        Account result = fromBank.GetAccount(name);

        if (result == null)
        {
            Console.WriteLine($"No account found with name: {name}");
        }

        return result;

    }
    //Function for reading a double with validation and prompt
    private static decimal ReadDouble(string prompt)
    {
        decimal amount;
        do
        {
            Console.Write(prompt);
            try
            {
                amount = Convert.ToDecimal(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a number");
                amount = -1;
            }
        } while (amount == -1);
        return amount;
    }

    private static void DoTransfer(Bank bankOfAndrew)
    {
        Account toAccount;
        Account fromAccount;
        Console.WriteLine("Account to recieve a deposit ");
        toAccount = FindAccount(bankOfAndrew);
        if (toAccount != null)
        {
            Console.WriteLine("Account to be withdrawn from ");
            fromAccount = FindAccount(bankOfAndrew);
            if (fromAccount != null)
            {
                decimal amount = ReadDouble("Amount to be transfered $");
                TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, amount);
                bankOfAndrew.ExecuteTransaction(transfer);
            }
            else
            {
                Console.WriteLine("Please enter a valid account");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid account");
        }
    }

    private static void DoDeposit(Bank toBank)
    {
        Account toAccount = FindAccount(toBank);
        if (toAccount == null) return;

        decimal amount = ReadDouble("Enter deposit amount: $");

        DepositTransaction deposit = new DepositTransaction(toAccount, amount);

        toBank.ExecuteTransaction(deposit);

        if (deposit.Success == true)
        {
            deposit.Print();
        }
        else
        {
            Console.WriteLine("Deposit Declined");
        }

    }
    
    private static void DoWithdraw(Bank fromBank)
    {
        Account fromAccount = FindAccount(fromBank);
        if (fromAccount == null) return;

        decimal amount = ReadDouble("Enter withdraw amount: $");

        WithdrawTransaction withdraw = new WithdrawTransaction(fromAccount, amount);

        fromBank.ExecuteTransaction(withdraw);

        if (withdraw.Success == true)
        {
            withdraw.Print();
        }
        else
        {
            Console.WriteLine("Withdraw Declined");
        }
    }
    private static void DoPrint(Bank bankOfAndrew)
    {
        bankOfAndrew.PrintAllAccounts();
    }
}

