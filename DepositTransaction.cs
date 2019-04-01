using System;

public class DepositTransaction
{
    private Account _account;
    private decimal _amount;
    private bool _executed, _success, _reversed;


    public bool Success
    {
        get{ return _success; }
    }

    public bool Executed
    {
        get{ return _executed; }
    }
    public bool Reversed
    {
        get{ return _reversed; }
    }

    public DepositTransaction(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }
    public void Print()
    {
        if ( _executed == true)
        {
            Console.WriteLine("Deposit Successful");
            Console.WriteLine("Amount deposited: $" + Convert.ToString(_amount));
        }
        if (_reversed == true)
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
        _success = _account.Deposit(_amount);
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
            _executed = false;
            _success = _account.Deposit(_amount);
        }    
    }

}