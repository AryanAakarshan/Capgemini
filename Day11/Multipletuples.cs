using System;

public class MultipleTuples
{
    public static (int Sum, int Diff, int Average) Calculate(int a, int b)
    {
        int sum = a + b;
        int diff = a - b;
        int average = (a + b) / 2;

        return (sum, diff, average);
    }
}
