using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Collections;
class Program
{
    static void Main()
    {
        
        Console.Write("Enter the number of products: ");
        int n=Convert.ToInt32(Console.ReadLine());
        int[] Product=new int[n];
        int Sum=0;
        Console.Write("Enter NUmber of Products: ");
        for(int i = 0; i < n; i++)
        {
            Product[i]=Convert.ToInt32(Console.ReadLine());
            Sum+=Product[i];
        }
        double Avg=Sum/n;
        Array.Sort(Product);
        for(int i = 0; i < n; i++)
        {
            if (Product[i] < Avg)
            {
                Product[i]=0;
            }
        }
        Array.Resize(ref Product, Product.Length + 5);
        for (int i = n; i < Product.Length; i++)
            Product[i] = (int)Avg;
        Console.Write("Final Products: ");
        for(int i = 0; i < n+5; i++)
        {
            Console.Write($"{Product[i]} ");
        }


        // Task 2

        Console.Write("Enter Branches: ");
        int Branches=Convert.ToInt32(Console.ReadLine());
        Console.Write("\nEnter Months: ");
        int Months=Convert.ToInt32(Console.ReadLine());
        int [ , ]branchSales = new int[Branches, Months];

        for (int i = 0; i < Branches; i++)
        {
            Console.WriteLine("\nEnter sales for Branch " + (i + 1));
            for (int j = 0; j < Months; j++)
            {
                branchSales[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        int highestSale = int.MinValue;
        for (int i = 0; i < Branches; i++)
        {
            int total = 0;
            for (int j = 0; j < Months; j++)
            {
                total += branchSales[i, j];
                if (branchSales[i, j] > highestSale)
                    highestSale = branchSales[i, j];
            }
            Console.WriteLine("Total Sales for Branch " + (i + 1) + " = " + total);
        }

        Console.WriteLine("Highest Monthly Sale Across All Branches = " + highestSale);
        
        // Task 4

        Console.Write("Enter number of Customber Transaction: ");
        int t=Convert.ToInt32(Console.ReadLine());
        List<int> customers = new List<int>();

        for (int i = 0; i < t; i++)
        {
            Console.WriteLine("Enter Customer ID:");
            customers.Add(Convert.ToInt32(Console.ReadLine()));
        }

        HashSet<int> hs = new HashSet<int>(customers);
        List<int> cleaned = new List<int>(hs);

        Console.WriteLine("\nCleaned Customer List:");
        foreach (int x in cleaned)
            Console.WriteLine(x);

        Console.WriteLine("Duplicates Removed = " + (customers.Count - cleaned.Count));

        // Task 5

        Console.WriteLine("Enter number of transactions:");
        int trans = Convert.ToInt32(Console.ReadLine());
        double avgProductPrice=0;
        Dictionary<int, double> dict = new Dictionary<int, double>();
        for(int i = 0; i < trans; i++)
        {
            Console.WriteLine("\nEnter Transaction ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            
            if (dict.ContainsKey(id))
            {
                Console.WriteLine("Duplicate ID – Enter Again");
                i--;
                continue;
            }

            Console.WriteLine("Enter Amount:");
            double amount = Convert.ToDouble(Console.ReadLine());
            avgProductPrice+=amount;
            dict.Add(id, amount);
        }
        avgProductPrice=avgProductPrice/trans;
        SortedList<int,double> Sorted=new SortedList<int, double>();
        foreach(KeyValuePair<int, double> kv in dict)
        {
            if (kv.Value >= avgProductPrice)
                Sorted.Add(kv.Key, kv.Value);
        }
        foreach(KeyValuePair<int,double> kv in Sorted)
        {
            Console.WriteLine("ID: " + kv.Key + " Amount: " + kv.Value);
        }

        // Task 6

        Console.WriteLine("Enter number of operations:");
        int ops = Convert.ToInt32(Console.ReadLine());

        Queue<string> q = new Queue<string>();
        Stack<string> s = new Stack<string>();

        for (int i = 0; i < ops; i++)
        {
            Console.Write("Enter Operation name: ");
            string opera=Console.ReadLine();
            q.Enqueue(opera);
            s.Push(opera);

        }
        Console.WriteLine("Queue Fifo processing: ");
        while (q.Count > 0)
        {
            Console.WriteLine(q.Dequeue());
        }
        Console.WriteLine("\nUndo Last Two Operations:");
        for (int i = 0; i < 2 && s.Count > 0; i++)
            Console.WriteLine("Undone: " + s.Pop());

        //Task 7
        Console.WriteLine("Enter number of users:");
        int u = Convert.ToInt32(Console.ReadLine());

        Hashtable ht = new Hashtable();
        ArrayList al = new ArrayList();
        for(int i = 0; i < u; i++)
        {
            Console.Write("Enter user: ");
            string user=Console.ReadLine();
            Console.Write("\nEnter Role: ");
            string Role=Console.ReadLine();
            ht[user]=Role;
            al.Add(user);
            al.Add(Role);
        }
        Console.Write("\nHashTable: \n");
        foreach(DictionaryEntry d in ht)
        {
            Console.WriteLine($"Key: {d.Key} -> Value: {d.Value}");
        }
        Console.WriteLine("\nArrayList (Mixed Data Risk):");
        foreach (var x in al)
            Console.WriteLine(x);


    }
}