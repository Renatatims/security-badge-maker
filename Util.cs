//import packages
using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using SkiaSharp;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    class Util
    {
        // PrintEmployees - static method
        public static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                //Template spacing information 
                string template = "{0,-1}\t{1,-5}\t{2}";
                //Prints in the console - Employee ID, Full name (First and Last) and Photo Url
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            }
        }

        //MakeCSV - generate CSV file with all the employees data
        public static void MakeCSV(List<Employee> employees)
        {
            // Check to see if folder exists
            if (!Directory.Exists("data"))
            {
                // If not, create data directory
                Directory.CreateDirectory("data");
                //Create a CSV file - using - once it runs the SteamWriter is removed
                using (StreamWriter file = new StreamWriter("data/employees.csv"))
                {
                    file.WriteLine("ID,Name,PhotoUrl");
                    // Loop over employees
                    for (int i = 0; i < employees.Count; i++)
                    {
                        // Write each employee's data to the file - Id, Full Name and Photo Url
                        string template = "{0},{1},{2}";
                        file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                    }
                }
            }
        }

        //MakeBadges - generate the badges template with the employee data
        async public static Task MakeBadges(List<Employee> employees)
        {
            // Layout variables - pixel values
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;

            //Employee Photo
            int PHOTO_LEFT_X = 184;
            int PHOTO_TOP_Y = 215;
            int PHOTO_RIGHT_X = 486;
            int PHOTO_BOTTOM_Y = 517;

            // using - instance of HttpClient is disposed after code in the block has run
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    //Get Photo Url for each employee - then converting the Stream into a SKImage
                    SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));

                    //SKImage background
                    SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));

                    //Badge - width and height
                    SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);

                    //SKCanvas object - wrapper around the badge bitmap - allows direct graphical modifications to the badge
                    SKCanvas canvas = new SKCanvas(badge);

                    //SKRectangular - allocates a postion and size on the badge
                    canvas.DrawImage(background, new SKRect(0, 0, BADGE_WIDTH, BADGE_HEIGHT));

                    //Insert employee photo
                    canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));

                    // Final Image
                    SKImage finalImage = SKImage.FromBitmap(badge);
                    SKData data = finalImage.Encode();
                    //Save image to data directory on a png file
                    data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
                }
            }

        }
    }
}