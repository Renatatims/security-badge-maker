using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        // GetEmployees - method
        public static List<Employee> GetEmployees()
        {
            // Handles Employee instances
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

        //GetFromApi() method
        public static List<Employee> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();
            return employees;
        }
    }
}