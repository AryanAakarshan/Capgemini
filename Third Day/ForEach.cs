using System;
class ForEachLoop
{
    public static void ForEachMain()
    {
        string name="Aryan";
        foreach (char i in name)
        {
            if (i == 'a')
            {
                Console.Write($"{i}");
            }
        }
        
    }
}