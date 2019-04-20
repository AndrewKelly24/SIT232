using System;
using SplashKitSDK;
using System.Collections.Generic;
public class Bank
{
    private static List<Account> _accounts = new List<Account>();
    public int size = _accounts.Count;
    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }
    public Account GetAccount(string name)
    {
        for (int i = 0; i < _accounts.Count; i++)
        {
            if (_accounts[i].Name == name)
            {
                return _accounts[i];
            }
        }
        return null;
    }
    public void ExecuteTransaction(WithdrawTransaction transaction)
    {
        transaction.Execute();
    }
    public void ExecuteTransaction(DepositTransaction transaction)
    {
        transaction.Execute();
    }
    public void ExecuteTransaction(TransferTransaction transaction)
    {
        transaction.Execute();
    }
    public void PrintAllAccounts()
    {
        for (int i = 0; i < _accounts.Count; i++)
        {
            _accounts[i].PrintAccount();
        }
        if (_accounts.Count == 0)
        {
            Console.WriteLine("There are no accounts to print");
        }
    }
}