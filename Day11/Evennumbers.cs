using System;
using System.Linq;
public class Evennumbers
{
    public static void Filter()
    {
        int[] numbers={1,2,3,4,5,6,7,8};
        var evennumber=numbers.Where(n => n%2 ==0);
        var descending=evennumber.OrderByDescending(n =>n);

        var multi=numbers.Where(n => n>3).Select(n => n*2);

        Console.WriteLine(evennumber.GetType());
        Console.WriteLine(multi.GetType());
        
        Console.WriteLine("Even Numbers are:");
        foreach (var n in descending)
        {
            Console.WriteLine(n);
        }
       
        Console.WriteLine(" Numbers after filter out are:");
              foreach (var n in multi)
        {
            Console.WriteLine(n);
        }

    }
}