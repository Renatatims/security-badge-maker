using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;

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
        async public static Task<List<Employee>> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();

            //
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                //Testing the app:
                //Console.Write(response);
                JObject json = JObject.Parse(response);
                //Testing the app:
                Console.WriteLine(json.SelectToken("results[0].name.first"));
                Console.WriteLine(json.SelectToken("results[1].name.first"));
                Console.WriteLine(json.SelectToken("results[2].name.first"));
            }
            return employees;
            
        }
    }
}