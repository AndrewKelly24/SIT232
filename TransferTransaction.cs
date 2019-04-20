using System;

public class TransferTransaction
{
    private Account _toAccount, _fromAccount;
    private decimal _amount;
    private DepositTransaction _theDeposit;
    private WithdrawTransaction _theWithdraw;
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

    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
    {
        _amount = amount;
        _toAccount = toAccount;
        _fromAccount = fromAccount;

        _theDeposit = new DepositTransaction(_toAccount, _amount);
        _theWithdraw = new WithdrawTransaction(_fromAccount, _amount);
    }
    public void Print()
    {
        if (_success)
        {
            Console.WriteLine("Transfered $" + Convert.ToString(_amount) + " from " + _fromAccount.Name + " to " + _toAccount.Name);
            _theDeposit.Print();
            Console.WriteLine();
            _theWithdraw.Print();
        }
        else
        {
            Console.WriteLine("Transaction not successful");
        }
        if (_reversed)
        {
            Console.WriteLine("Transaction has been reversed");
        }
    }
    public void Execute()
    {
        if (_executed)
        {
            throw new Exception("Cannot excute this transaction");
        }

        _theWithdraw.Execute();
        if (_theWithdraw.Success)
        {
            _theDeposit.Execute();
            if (!_theDeposit.Success)
            {
                _theWithdraw.Rollback();
            }
            _executed = true;
            _success = _theDeposit.Success;
        }




    }
    public void RollBack()
    {
        if (!_executed || _reversed)
        {
            throw new Exception("Cannot Rollback transaction");
        }

        if (_theWithdraw.Executed)
        {
            _theWithdraw.Rollback();
        }
        if (_theDeposit.Executed)
        {
            _theDeposit.Rollback();
            _reversed = true;
        }
    }
}