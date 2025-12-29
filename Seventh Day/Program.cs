using System.Globalization;

class Program
{
    static void Main()
    {
        //Ways to declare an Array
        int[] numbers;
        int[] numbers1=new int[5];
        int[] number2 = { 1, 2, 3, 4, 5 };
        //Foreach loop to print values in an array
        Console.Write("Foreach Loop: ");
        foreach( int num in number2)
        {
            Console.Write(num+" ");
        }
        //For loop to print values in an array
        Console.Write("\nFor loop: ");
        for(int i = 0; i < number2.Length; i++)
        {
            Console.Write(number2[i]+" ");
        }
        //while loop to print values in an array
        int j=0;
        Console.Write("\nWhile Loop: ");
        while (j < number2.Length)
        {
            Console.Write(number2[j]+" ");j++;
        }
        int sum=0;
        foreach(int num in number2)
        {
            sum+=num;
        }
        Console.WriteLine($"\nSum of all the numbers in the Array: {sum}");
        MultidimentionalArray obj=new MultidimentionalArray();
        obj.MDA();
        JA obj1=new JA();
        obj1.JArr();
        ArrayOperation obj2= new ArrayOperation();
        obj2.Arrays();
        Array.Copy(number2,numbers1,5);
        Console.Write("\nCopied Array: ");
        foreach(int num in numbers1)
        {
            Console.Write(num+" ");
        }
        Console.WriteLine();
        int[] nums = { 1, 2 };
    int[] nums2 = { 1, 2 };
    Array.Resize(ref nums, 4);  
    Array.Resize(ref nums2, 5);
    foreach(int num in nums2)
        {
            Console.Write($"{num} ");
        }
    Console.WriteLine();
    List.Lists();
        
        
    }
}