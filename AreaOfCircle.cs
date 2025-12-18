using System;
class AOC
{
    public static void AreaOfCircle()
    {
        Console.Write("Enter radius: ");
        double r=Convert.ToDouble(Console.ReadLine());
        double area = Math.PI * r * r;
        Console.WriteLine($"Area of circle = {area}");
    }
}