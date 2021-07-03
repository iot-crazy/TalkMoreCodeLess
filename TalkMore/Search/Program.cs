using Data;
using DataModels;
using System;
using System.IO;
using System.Linq;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Error: Please specify a search parameter.");
                DisplayUsage();
                return;
            }

            string columnName = args[0].Replace("--", ""); // not used, retained for future expansion
            string searchValue = args[1];

            Importer.FindMatches(columnName, searchValue).ForEach(x => DisplayCamera(x));
        }


        static void DisplayCamera(Camera camera)
        {
            Console.WriteLine($"{camera.ID} | {camera.Name} {camera.Lat} | {camera.Lng}");
        }

        static void DisplayUsage()
        {
            Console.WriteLine("Search Usage:");
            Console.WriteLine("search --ColumnName --Value");
            Console.WriteLine("Example  search --name Neude");
        }

    }
}
