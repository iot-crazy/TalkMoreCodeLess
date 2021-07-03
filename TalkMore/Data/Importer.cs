using DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Data
{
    public static class Importer
    {
        private const string DataFile = "C:/Users/tony/source/repos/TalkMoreCodeLess/TalkMore/Data/Data/cameras-defb.csv";

        public static IQueryable<Camera> GetQuery()
        {
            return File.ReadLines(DataFile).Skip(1)
                .Select(x => Camera.FromLine(x))
                .Where(x => x != null)
                .AsQueryable<Camera>();
        }

        public static List<Camera> FindMatches(string columnName, string searchValue)
        {
            return GetQuery()
                .Where(x => x.Name.Contains(searchValue, StringComparison.InvariantCultureIgnoreCase))
                .ToList<Camera>();
        }

        public static List<Camera> GetAll()
        {
            return GetQuery()
                .ToList<Camera>();
        }

        public static List<Camera> GetByID(int ID)
        {
            return GetQuery()
                .Where(x => x.ID == ID)
                .ToList<Camera>();
        }
    }
}
