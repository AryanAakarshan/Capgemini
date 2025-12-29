using System;
class ArrayOperation
{
    public void Arrays()
    {
        int[] marks={92,56,78};
        Array.Sort(marks);
        Console.Write("Sorted Array: ");
        foreach(int mark in marks)
        {
            Console.Write($"{mark} ");
        }
        Array.Reverse(marks);
        Console.Write("\nReversed Array: ");
        foreach(int mark in marks)
        {
            Console.Write($"{mark} ");
        }
        Array.Clear(marks,0,marks.Length);
        Console.Write("\nCleared Array: ");
        foreach(int mark in marks)
        {
            Console.Write($"{mark} ");
        }


    }
}