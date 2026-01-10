using System;
class Programs
{
    public static void Main()
    {
        // *** Garbage Collector ***
    //         Console.WriteLine("Creating objects...");
    //         for(int i=0;i<10;i++)
    //         {
    //             Myclass obj=new Myclass();
    //         }
    //         Console.WriteLine("Forcing Garbage Collection....");
    //         GC.Collect();
    //         GC.WaitForPendingFinalizers();
    //         Console.WriteLine("Garbage collection completed");

    //     }
    // }
    // class Myclass
    // {
    //     ~Myclass()  //Finalizer(Destructor like method)      // No parameter, no return type
    //     {
    //         Console.WriteLine("FiNALIZER CALLED,OBJECT COLLECTED");
    //     }
    // }

// ***Anonymous.cs*** //
    // Anonymous.Print();
    // Console.WriteLine();

// ***Multipletuples.cs*** //
    // var result = MultipleTuples.Calculate(10, 5);
    //         Console.WriteLine("Sum = " + result.Sum);
    //         Console.WriteLine("Difference = " + result.Diff);
    //         Console.WriteLine("Average = " + result.Average);

        Console.WriteLine();

// ***Tuples.cs*** //
    // var response=Tuples.ValidateUser("Admin");
    // Console.WriteLine(response.Message);

// ***Student.cs*** //
    // var s = new Student { Id = 1, Name = "Amit" };
    // Console.WriteLine(s.GetType());
    // var (sid, sname) = s;

    // Console.WriteLine(sid);
    // Console.WriteLine(sname);

// ***Evenumbers.cs*** //
    //  Evennumbers.Filter();

// ***Datashaping.cs*** //
    //  DataShaping.Run();

// ***Employee.cs*** //
    // EmployeeSort.Sort();

    // ***ResourceHandler.cs*** //
    using (ResourceHandler handler = new ResourceHandler())
        {
            Console.WriteLine("Using the resource...");
        }

        Console.WriteLine("End of Program");


}
}