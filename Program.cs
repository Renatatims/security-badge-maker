using System;
using System.Collections.Generic;
namespace CatWorx.BadgeMaker
{
    class Program
    {

        //GetEmployees - method
        static List<Employee> GetEmployees()
        {
            //Handles Employee instances
            List<Employee> employees = new List<Employee>();
            // Collect user values until the value is an empty string
            while (true)
            {
                Console.WriteLine("Please enter a name: (leave empty to exit): ");
                // Get a name from the console and assign it to a variable
                //?? - similar to a ternary operator - if input is null then an empty string will be placed"
                string firstName = Console.ReadLine() ?? "";
                // Break if the user hits ENTER without typing a name
                if (firstName == "")
                {
                    break;
                }
                // Console.ReadLine() for each employee value
                // Last Name
                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine() ?? "";

                //ID - Int32 - store a string as an integer
                Console.Write("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine() ?? "");

                //Photo URL
                Console.Write("Enter Photo URL:");
                string photoUrl = Console.ReadLine() ?? "";

                // Create a new Employee instance
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }
            // Returns Employees List
            return employees;
        }

        //***REMOVE**PrintEmployees - method*** Included this method in Utils.cs
        
        /*REMOVE
        static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                //Template spacing information 
                string template = "{0,-1}\t{1,-5}\t{2}";
                //Prints in the console - Employee ID, Full name (First and Last) and Photo Url
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            }
        }
        */

        //Main
        static void Main(string[] args)
        {
            // GetEmployees and PrintEmployees method calls
            List<Employee> employees = GetEmployees();
            //**REMOVE***PrintEmployees(employees);
            Util.PrintEmployees(employees);

        }

    }
}
