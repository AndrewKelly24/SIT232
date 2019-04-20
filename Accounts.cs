using System;

//Creating the Account Class
public class Account
{
    private decimal _balance;
    private string _name;
    //Give _name a read only propertyrea,+d
    public string Name
    {
        get { return _name; }
    }
    //Method used to initilise an account object
    public Account(string name, decimal startingBalance)
    {
        _name = name;
        _balance = startingBalance;
    }

    //Method for adding funds into an account
    public bool Deposit(decimal amountToAdd)
    {
        if (amountToAdd > 0)
        {
            _balance += amountToAdd;
            return true;
        }
        return false;
    }

    //Method for withdrawing funds from an account
    public bool Withdraw(decimal amountToSubtract)
    {
        if (amountToSubtract > 0 && _balance >= amountToSubtract)
        {
            _balance -= amountToSubtract;
            return true;
        }
        return false;
    }
    public void PrintAccount()
    {
        Console.WriteLine("Account Name: " + _name);
        Console.WriteLine("Account Balance: $" + _balance);
    }
}