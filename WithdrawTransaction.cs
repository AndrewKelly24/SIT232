using System;

public class WithdrawTransaction
{
    private Account _account;
    private decimal _amount;
    private bool _executed = false;
    private bool _success = false;
    private bool _reversed = false;


    public bool Success
    {
        get { return _success; }
    }
    public bool Executed
    {
        get { return _executed; }
    }
    public bool Reversed
    {
        get { return _reversed; }
    }

    public WithdrawTransaction(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }
    public void Print()
    {
        if (_success)
        {
            Console.WriteLine("Withdrawn Successful");
            Console.WriteLine("Amount withdrawn: $" + Convert.ToString(_amount));
        }
        if (_reversed)
        {
            Console.WriteLine("This transaction has been reversed");
        }

    }
    public void Execute()
    {
        if (_executed)
        {
            throw new Exception("Cannot excute this transaction");
        }
        _executed = true;
        _success = _account.Withdraw(_amount);
    }
    public void Rollback()
    {
        if (_executed == false || _reversed == true)
        {
            Console.WriteLine("Error: Cannot reverse this transaction");
        }
        else
        {
            _reversed = true;
            _success = _account.Deposit(_amount);
        }
    }

}