using System;
using System.Collections.Generic;
namespace CatWorx.BadgeMaker
{
    class Program
    {

        //GetEmployees - method
        static List<string> GetEmployees()
        {
            List<string> employees = new List<string>();
            // Collect user values until the value is an empty string
            while (true)
            {
                Console.WriteLine("Please enter a name: (leave empty to exit): ");
                // Get a name from the console and assign it to a variable
                //?? - similar to a ternary operator - if input is null then an empty string will be placed"
                string input = Console.ReadLine() ?? "";
                // Break if the user hits ENTER without typing a name
                if (input == "")
                {
                    break;
                }
                // Create a new Employee instance
                Employee currentEmployee = new Employee(input, "LastName");
                employees.Add(currentEmployee.GetFullName());
            }
            // Returns Employees List
            return employees;
        }

        //PrintEmployees - method
        static void PrintEmployees(List<string> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i]);
            }
        }

        //Main
        static void Main(string[] args)
        {
            // GetEmployees and PrintEmployees method calls
            List<string> employees = GetEmployees();
            PrintEmployees(employees);


        }

    }
}
