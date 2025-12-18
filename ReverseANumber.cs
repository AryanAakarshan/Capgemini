using System;
class ReverseANumber
{
    public static void ReverseNumber()
    {
        int a=Convert.ToInt32(Console.ReadLine());
        int num=0;
        while (a > 0)
        {
            int temp=a%10;
            num+=temp;
            num=num*10;
            a=a/10;
        }
        Console.WriteLine(num/10);
    }
}