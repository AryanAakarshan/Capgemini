using System;
using System.Collections.Generic;
using System.Linq;

public class EmployeeSort
{
    public static void Sort()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Amit", Salary = 50000 },
            new Employee { Name = "Ravi", Salary = 70000 },
            new Employee { Name = "Neha", Salary = 60000 }
        };

        var sortedBySalary = employees.OrderBy(e => e.Salary);

        foreach (var emp in sortedBySalary)
        {
            Console.WriteLine(emp.Name + " - " + emp.Salary);
        }
    }
}

 class Employee
{
    public string Name { get; set; }
    public int Salary { get; set; }
}
