
using System.Runtime.InteropServices;
using System;
struct StockPrice
{
    public string StockSymbol;
    public int Price;
    
}
public class Trade
    {
        public int TradeID;
        public string StockSymbol;
        public int Quantity;
    }
class Program
{
    static void Main()
    {
        StockPrice stock1=new StockPrice()
        {
            StockSymbol="AAPL",
            Price=150
        };
        StockPrice copiedPrice=stock1;
        copiedPrice.Price=155;
        Console.WriteLine(stock1.Price);
        Trade Trade1=new Trade
        {
            TradeID=101,
            StockSymbol="AAPL",
            Quantity=100
        };
        Trade Trade2=Trade1;
        Trade2.Quantity=200;
        Console.WriteLine($"{Trade1.Quantity}");
        Portfolio p1=new Portfolio{Name="Growth"};
        Portfolio p2=new Portfolio{Name="Growth1"};
        Console.WriteLine(p1.Equals(p2));
        Console.WriteLine(p1==p2);
        int a=p1.GetHashCode();
        Console.WriteLine(a);
        int b=p2.GetHashCode();
        Console.WriteLine(b);
        Tradeing t = new EquityTrade();
        Console.WriteLine(t.GetType());
        
        Repository<Customber> TradeRepo= new Repository<Customber>();
        TradeRepo.Data=new Customber{Name="Aryan"};
        Console.WriteLine(TradeRepo.Data.Name); 
        Calculator calc=new Calculator();
        int Result=calc.Calculate(4,5);
        Console.WriteLine(calc.Calculate(4,5.4)); 
        Console.WriteLine(calc.Calculate(5.6,4));

        List<int> Trade= new List<int>();
        Printer.Print("wwe");
        int? price=1222;
        int shopPrice=price??100;
        double amount =10000;
        double tax = amount.Tax();
        Console.WriteLine(tax);


        

    }
}