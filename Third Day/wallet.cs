using System;
using System.Runtime;
class Wallet
{
    private double money;
    public void Add_Money(double amount)
    {
        money+=amount;
    }
    public double Balance()
    {
        
        Console.Write(money);
        return money;
    }
}