using System;
class License{
    public static void LicenseCheck(){
        Console.Write("What is your age: ");
        int age=Convert.ToInt32(Console.ReadLine());
        bool license= true;
        if(age>=18){
            if(license){
                Console.WriteLine("You can drive bro.");
            }
            else{
                Console.WriteLine("Bro get a license.");
            }
        }
    }
}