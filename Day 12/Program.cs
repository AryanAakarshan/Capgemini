// using System;
// using System.Text;
// class Program
// {
//     static void Main()
//     {
//         //Strings are immutable
//         string s="Hello";
//         Console.WriteLine(s.ToLower());
//         //StringBuilders are muttable
        
//         StringBuilder sb=new StringBuilder();
        
//         //chain multiple append and append line

//         sb.AppendLine("Hello").Append(" ").Append("World");
//         sb.Append(" ");
//         sb.AppendLine("World");
//         sb.Insert(0,"Start ");
//         Console.WriteLine(sb.ToString());
//         sb.Remove(0,5); //parameter(Int start point,int length)
//         Console.WriteLine(sb.ToString());
//         sb.Replace("old","new");
//         Console.WriteLine(sb.ToString());

//         //Getting memory location

//         long mem=GC.GetTotalMemory(false);
//         Console.WriteLine(mem);

//         StringBuilder sb1=new StringBuilder();
//         for(int i = 0; i < 1000; i++)
//         {
//             sb1.Append(i);
//         }
//         string result=sb1.ToString();
//         Console.WriteLine(mem);//mot changed

//         //comparing string builder refrence and value

//         StringBuilder sb2=new StringBuilder("Hello");
//         StringBuilder sb3=new StringBuilder("Hello");
//         Console.WriteLine(sb2.Equals(sb3));
//         StringBuilder sb4=sb3;
//         sb4.Append(" Whatsup");
//         Console.WriteLine(sb4.Equals(sb3));
//         Console.WriteLine(sb2==sb3);
//         Console.WriteLine(sb3==sb4);
//         Console.WriteLine(sb3);
        
//         //DateTime

//         DateTime now=DateTime.Now;
//         DateTime today=DateTime.Today;
//         DateTime future=now.AddDays(2);
//         Console.WriteLine($"{now} , {today} , {future}");

//     }
// }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06Jan2026.EcommereceAssessment
{
    public class Repository<T>
    {
        private List<T> items = new List<T>();
        public void Add(T item)
        {
            items.Add(item);
        }
        public List<T> GetAll()
        {
            return items;
        }
    }
    public class Order
    {
        public int OrderId{get; set;}
        public string CustomerName{get; set;}
        public double Amount{get; set;}
        public override string ToString()
        {
            return $"OrderId: {OrderId}, Customer: {CustomerName}, Amount: {Amount}";
        }
    }
    public delegate void OrderCallback(string message);
    public class OrderProcessor
    {
        public event Action<string> OrderProcessed;
        public void ProcessOrder(Order order,
            Func<double, double> taxCalculator,
            Func<double, double> discountCalculator,
            Predicate<Order> validator,
            OrderCallback callback)
        {
            if (!validator(order))
            {
                callback("Order Validation failed.");
                return;
            }
            double tax = taxCalculator(order.Amount);
            double discount = discountCalculator(order.Amount);
            order.Amount = order.Amount + tax - discount;
            callback($"Order {order.OrderId} processed successfully.");
            OrderProcessed?.Invoke($"Event: Order {order.OrderId} completed.");
        }
    }
}
namespace _06Jan2026.EcommereceAssessment{
    class Program
    {
        static void Main(String[] args)
        {
            Repository<Order> orderRepo = new Repository<Order>();
            orderRepo.Add(new Order {OrderId = 1, CustomerName = "Alice", Amount = 5000});
            orderRepo.Add(new Order {OrderId = 2, CustomerName = "Bob", Amount = 2000});
            orderRepo.Add(new Order {OrderId = 3, CustomerName = "Charlie", Amount = 8000});
            Func<double, double> taxCalculator = amount => amount * 0.18;
            Func<double, double> discountCalculator = amount => amount * 0.05;
            Predicate<Order> validator = order => order.Amount >= 3000;
            OrderCallback callback = message =>
            {
                Console.WriteLine($"Callback: {message}");
            };
            OrderProcessor processor = new OrderProcessor();
            Action<string> logger = msg => Console.WriteLine($"Logger: {msg}");
            Action<string> notifier = msg => Console.WriteLine($"Notifier: {msg}");
            processor.OrderProcessed += logger;
            processor.OrderProcessed += notifier;
            foreach (Order order in orderRepo.GetAll())
            {
                processor.ProcessOrder(
                    order,
                    taxCalculator,
                    discountCalculator,
                    validator,
                    callback
                );
                Console.WriteLine();
            }
            List<Order> processedOrders = orderRepo.GetAll();
            processedOrders.Sort((o1, o2) => o2.Amount.CompareTo(o1.Amount));
            Console.WriteLine("Sorted Orders (Descending Amount): ");
            foreach(Order order in processedOrders)
            {
                Console.WriteLine(order);
            }
        }
    }
}