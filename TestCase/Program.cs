using System;

public class Program
{
    public decimal Balance { get; private set; }

    public Program(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
            throw new Exception("Deposit amount cannot be negative");

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
            throw new Exception("Insufficient funds.");

        Balance -= amount;
    }

    public static void Main(string[] args)
    {
        Program account = new Program(100);

        Console.WriteLine("Initial Balance: " + account.Balance);

        try
        {
            Console.WriteLine("Depositing 50");
            account.Deposit(50);
            Console.WriteLine("Balance after deposit: " + account.Balance);

            Console.WriteLine("Depositing -20");
            account.Deposit(-20);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        try
        {
            Console.WriteLine("Withdrawing 30");
            account.Withdraw(30);
            Console.WriteLine("Balance after withdrawal: " + account.Balance);

            Console.WriteLine("Withdrawing 500");
            account.Withdraw(500);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        Console.WriteLine("\nFinal Balance: " + account.Balance);
    }
}
