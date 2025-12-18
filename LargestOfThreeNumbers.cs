using System;
using System.Data;
class largestNumber{
    public static void largestNumbers(){
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("\nEnter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.Write("\nEnter third number: ");
        int c = Convert.ToInt32(Console.ReadLine());
        if(a>b && a>c){
            Console.WriteLine(a);
        }
        else if(b>c&&b>a){
            Console.WriteLine(b);
        }
        else {
            Console.WriteLine(c);
        }
    }
}