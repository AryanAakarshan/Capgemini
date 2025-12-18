using System;
class OE{
    public static void OddEven(){
        
        Console.Write("Give a number: ");
        int a=Convert.ToInt32(Console.ReadLine());
        if(a%2==0){
            Console.WriteLine("Number is even");
        }
        else{
            Console.WriteLine("Number is odd");
        }
    }
}