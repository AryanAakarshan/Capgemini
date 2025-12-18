using System;
class SumOfDigits
{
    public static void SumOfDigits1()
    {
        int a=Convert.ToInt32(Console.ReadLine());
        int sum=0;
        while (a > 0)
        {
            
            sum+=a%10;
            a=a/10;
        }
        Console.WriteLine(sum);
    }
}