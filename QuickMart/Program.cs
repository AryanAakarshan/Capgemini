using System;
using System.Security.Cryptography.X509Certificates;
class SaleTransaction
{
    public string InvoiceNo{get;set;}
    public string CustomberName{get;set;}
    public string ItemName{get;set;}
    public int Quantity{get;set;}
    public decimal PurchaseAmount{get;set;}
    public decimal SellingAmount{get;set;}
    public string ProfitOrLoss{get;set;}
    public decimal ProfitOrLossAmount{get;set;}
    public decimal ProfitMarginPercentage{get;set;}

}

class Program
{   
    static SaleTransaction? Last = null; 
    public static void Main()
    {
        bool flag=true;
        while (flag)
        {
            Console.WriteLine("1.Create New Transaction");
            Console.WriteLine("2.View Last Transaction");
            Console.WriteLine("3.Calculate Profit/Loss(Recompute & Print)");
            Console.WriteLine("4.Exit");
            Console.Write("Make a choice: ");
            int choice=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                CreateNewTransiction();
                break;
                case 2:
                ViewLastTransaction();
                break;
                case 3:
                Calculate();
                break;
                case 4:
                flag=false;
                break;
                default: 
                break;
            }
            
        }
    }
    public static void CreateNewTransiction()
    {
        SaleTransaction first=new SaleTransaction();
        Console.Write("Enter Invoice Number: ");
        string? Invoiceno = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(Invoiceno))
        {
            Console.WriteLine("Invoice Number cannot be null or empty.");
            return;
        }
        first.InvoiceNo=Invoiceno;
        Console.Write("\nEnter CustomberName: ");
        first.CustomberName= Console.ReadLine() ?? "Unknown";
        Console.Write("\nItem Name: ");
        first.ItemName=Console.ReadLine();
        Console.Write("\nEnter Quantity: ");
        first.Quantity=Convert.ToInt32(Console.ReadLine());
        Console.Write("\nEnter Purchase Amount: ");
        first.PurchaseAmount=Convert.ToDecimal(Console.ReadLine());
        Console.Write("\nEnter Selling Amount: ");
        first.SellingAmount=Convert.ToDecimal(Console.ReadLine());
        if (first.SellingAmount > first.PurchaseAmount)
        {
            first.ProfitOrLoss="PROFIT";
            first.ProfitOrLossAmount=first.SellingAmount-first.PurchaseAmount;

        }
        else if(first.SellingAmount == first.PurchaseAmount)
        {
            first.ProfitOrLoss="LOSS";
            first.ProfitOrLossAmount=first.PurchaseAmount-first.SellingAmount;
        }
        else
        {
            first.ProfitOrLoss="BREAK-EVEN";
            first.ProfitOrLossAmount=0;
        }
        first.ProfitMarginPercentage=(first.ProfitOrLossAmount/first.PurchaseAmount)*100;
        Last = first;
        Console.WriteLine("Purchase Detail Saved Successfully");

    }
    public static  void ViewLastTransaction()
    {
        if (Last == null)
        {
            Console.WriteLine("No bill available.");
            return;
        }
        Console.WriteLine("\nLast Transaction");
        Console.WriteLine($"Invoice Number: {Last.InvoiceNo}");
        Console.WriteLine($"Customber Name: {Last.CustomberName}");
        Console.WriteLine($"Item Purchased: {Last.ItemName}");
        Console.WriteLine($"Quantity: {Last.Quantity}");
        Console.WriteLine($"Purchase Amount: {Last.PurchaseAmount}");
        Console.WriteLine($"Selling Amount: {Last.SellingAmount}");
        Console.WriteLine($"Status: {Last.ProfitOrLoss}");
        Console.WriteLine($"Profit/Loss Amount: {Last.ProfitOrLossAmount}");
        Console.WriteLine($"Profit Margin: {Last.ProfitMarginPercentage:F2}%\n");
    }
    public static void Calculate()
    {
        ViewLastTransaction();
    }

}
