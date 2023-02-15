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
            // GetEmployees method call
            //List<Employee> employees = PeopleFetcher.GetEmployees();
            //Testing the API
            List<Employee> employees = await PeopleFetcher.GetFromApi();

            // PrintEmployees method call
            Util.PrintEmployees(employees);

            // MakeCSV - method call
            Util.MakeCSV(employees);

            // Make Badges - method call - asynchronous
            await Util.MakeBadges(employees);

        }

    }
}
