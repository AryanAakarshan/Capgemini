using System;
class Parmas
{
    public static void Sum(params int[] numbers)
    {
        int sum = 0;
        foreach(int num in numbers)
        {
            sum+=num;

        } 
        Console.WriteLine(sum);
    }
}