// using Internal;
// using System.Reflection.Metadata;
using System;
// using System.Linq.Expressions;
// using System.Xml;
// using HR;
// using System.Runtime.InteropServices.Marshalling;
// using System.Security.AccessControl;
// using System.Diagnostics;
// using System.Runtime.CompilerServices;
// using System.Data;
class Program
{
    static void Main()
    {
        Animal obj = new Dog(); 
        obj.Soundy();  
        obj.Sleep();
        IAnimal sheep=new Sheep();
        sheep.Numbers(4);
        ILogger notification=new FileLogger();
        notification.Log();
        HR.Employee.log();
        Finance.Employee emp1=new Finance.Employee();
        emp1.log();
        Company.Employee emp3=new Company.Employee();
        emp3.Show();
        emp3.Display();
        Condition con=Condition.Perfect;
        Console.WriteLine(con);
    }
}