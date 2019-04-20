using System;

public abstract class Transaction
{
    protected decimal _amount;

    private DateTime _dateStamp;

    private bool _executed = false;
    private bool _reversed = false;


    public Transaction(decimal amount)
    {
        _amount = amount;
    }

    public abstract bool Executed
    {
        get;
    }
    public abstract bool Success
    {
        get;
    }
    public abstract bool Reversed
    {
        get;
    }
    public abstract DateTime DateStamp
    {
        get;
    }


    public abstract void Print();

    public virtual void Execute()
    {
        if(_executed)
            throw new System.InvalidOperationException("Transaction already executed");

        _executed = true;
        _dateStamp = DateTime.Now;
    }
     public virtual void Reverse()
    {
        if(_reversed)
            throw new System.InvalidOperationException("Transaction already executed");

        _reversed = true;
        _dateStamp = DateTime.Now;
    }


}