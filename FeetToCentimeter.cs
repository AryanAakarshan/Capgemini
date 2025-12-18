using System;
class FTC
{
    public static void FeetToCentimeter()
    {
        Console.Write("Give value in Feet: ");
        double feet=Convert.ToDouble(Console.ReadLine());
        double centimeter = 30.48 * feet ;
        Console.WriteLine($"In Centimeters: {centimeter}\n");
    }
}