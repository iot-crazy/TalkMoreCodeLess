using DataModels;
using System;
using System.IO;

namespace Search
{
    class Program
    {
        const string DataFile = "./cameras-defb.csv";

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Error: Please specify a search parameter.");
                DisplayUsage();
                return;
            }

            string columnName = args[0].Replace("--", "");
            string searchValue = args[1];

            var stream = new StreamReader("./Data/cameras-defb.csv");
            stream.ReadLine(); // skip header line

            while (stream.EndOfStream == false )
            {
                string line = stream.ReadLine();
                MatchLine(line, columnName, searchValue);
            }
            
        }

        static void MatchLine(string line, string columnName, string searchValue)
        {
            var fields = line.Split(';');
            if (fields.Length != 3)
            {
                return;
            }

            var camera = Camera.FromLine(fields);

            if (camera.Name.Contains(searchValue, StringComparison.InvariantCultureIgnoreCase))
            {
                DisplayCamera(camera);
            }

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
