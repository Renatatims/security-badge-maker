using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    class Program
    {

        // Main - asynchronous
        async static Task Main(string[] args)
        {
            List<Employee> employees;
            //Initial Prompt
            Console.WriteLine("Please select an option to generate the badges:");
            //Menu options
            Console.WriteLine("\t1 - Manually input employee's data");
            Console.WriteLine("\t2 - Get data from an API - 10 random badges will be generated");

            //Switch case
            switch (Console.ReadLine() ?? "")
            {
                case "1":
                    // GetEmployees method call
                    employees = PeopleFetcher.GetEmployees();

                    // PrintEmployees method call
                    Util.PrintEmployees(employees);

                    // MakeCSV - method call
                    Util.MakeCSV(employees);

                    // Make Badges - method call - asynchronous
                    await Util.MakeBadges(employees);

                    break;

                case "2":

                    //GetFromApi method call
                    employees = await PeopleFetcher.GetFromApi();

                    // PrintEmployees method call
                    Util.PrintEmployees(employees);

                    // MakeCSV - method call
                    Util.MakeCSV(employees);

                    // Make Badges - method call - asynchronous
                    await Util.MakeBadges(employees);

                    break;

            }
        }
    }
}
