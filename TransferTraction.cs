using System;

public class TransferTransaction
{
    private Account _toAccount, _fromAccount;
    private decimal _amount;
    private DepositTransaction _theDeposit;
    private WithdrawTransaction _theWithdraw;
    private bool _executed, _success, _reversed;



    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
    {
        _amount = amount;
        _toAccount = toAccount;
        _fromAccount = fromAccount;

        _theDeposit = new DepositTransaction(_toAccount, _amount);
        _theWithdraw = new WithdrawTransaction(_fromAccount, _amount);

        if (_theDeposit.Success == true && _theWithdraw.Success == true)
        {
            _success = true;
        }
        else
        {
            _success = false;
        }
    }

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

    public void Print()
    {
        Console.WriteLine("Transfered $" + Convert.ToString(_amount) + " from " + _fromAccount.Name + " to " + _toAccount.Name);
        _theDeposit.Print();
        Console.WriteLine();
        _theWithdraw.Print();
    }

    public void Execute()
    {
        if (_executed)
        {
            throw new Exception("Cannot excute this transaction");
        }

        _theWithdraw.Execute();
        if (_theWithdraw.Success == true)
        {
            _theDeposit.Execute();
            if (_theDeposit.Success == false)
            {
                _theWithdraw.Rollback();
            }
            _executed = _theDeposit.Success;
        }




    }

    public void RollBack()
    {
        if (_executed == false || _reversed == true)
        {
            throw new Exception("Cannot Rollback transaction");
        }

        if (_theWithdraw.Executed == true)
        {
            _theWithdraw.Rollback();
        }
        if (_theDeposit.Executed == true)
        {
            _theDeposit.Rollback();
            _reversed = true;
        }
    }












}
