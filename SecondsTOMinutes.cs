using System;
class stm
{
    public static void SecondsToMinutes()
    {
        Console.Write("Give input in seconds: ");
        int seconds = Convert.ToInt32(Console.ReadLine());
        double min= (seconds/60);
        Console.WriteLine($"{seconds} sec In minutes: {min}");
    }
}