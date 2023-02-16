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
            Console.WriteLine("Would you like to input the data to generate the badges?");
            string response = Console.ReadLine() ?? "";
            if (response == "y")
            {
                // GetEmployees method call
                employees = PeopleFetcher.GetEmployees();

                // PrintEmployees method call
                Util.PrintEmployees(employees);

                // MakeCSV - method call
                Util.MakeCSV(employees);

                // Make Badges - method call - asynchronous
                await Util.MakeBadges(employees);
            }
            if (response == "n")
            {
                //GetFromApi method call
                employees = await PeopleFetcher.GetFromApi();

                // PrintEmployees method call
                Util.PrintEmployees(employees);

                // MakeCSV - method call
                Util.MakeCSV(employees);

                // Make Badges - method call - asynchronous
                await Util.MakeBadges(employees);
            }
        }
    }
}
