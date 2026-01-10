using System;
using System.Linq;

public class DataShaping
{
    public static void Run()
    {
         var students=new[]
        {
            new { Name="Amit", Marks=75 },
            new { Name="Neha", Marks=55 },
            new { Name="Rahul", Marks=65 }
        };
        // Data shaping using LINQ
        var result=students.Select(s => new
        {
            s.Name,
            Grade=s.Marks > 60 ? "Pass" : "Fail"
        }).ToList();
        Console.WriteLine(result.GetType());
      
        foreach (var r in result)
        {
            Console.WriteLine($"{r.Name} - {r.Grade}");
        }
    }
}
