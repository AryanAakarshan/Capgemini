using System;
using System.Text;

class Program
{
    public static string CleanseAndInvert(string input)
    {

        if (string.IsNullOrEmpty(input) || input.Length < 6)
            return "";


        foreach (char c in input)
        {
            if (!char.IsLetter(c))
                return "";
        }

        // Convert to lowercase
        input = input.ToLower();


        StringBuilder filtered = new StringBuilder();
        foreach (char c in input)
        {
            if (((int)c) % 2 != 0)
            {
                filtered.Append(c);
            }
        }

        char[] arr = filtered.ToString().ToCharArray();
        Array.Reverse(arr);

        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
            {
                arr[i] = char.ToUpper(arr[i]);
            }
        }

        return new string(arr);
    }

    public static void Main()
    {
        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        string result = CleanseAndInvert(input);

        if (result == "")
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("The generated key is - " + result);
        }
    }
}
