using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{   
    static void Process()
    {
        string msg = "Processing...";

        void PrintMsg()
        {
            Console.WriteLine(msg);
        }

        PrintMsg();
    }
    static void Main()
    {
        // Wallet myWallet = new Wallet();
        // myWallet.Add_Money(500);
        // myWallet.Add_Money(200);
        // myWallet.Balance();
        //double sum=Calculator.Add(2.5,5.6);
        // ForEachLoop.ForEachMain();
        // Parmas.Sum(4,7,2);
        // Process();
        bool tryit=int.TryParse("100",out int  value);
        Console.WriteLine(tryit);
        Console.WriteLine(value);
        int a = 10;
        object obj = a;     // Boxing

        int b = (int)obj;  // Unboxing
        Console.WriteLine(b);
        
    }
}