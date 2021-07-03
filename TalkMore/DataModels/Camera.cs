using System.Text.RegularExpressions;

namespace DataModels
{
    public class Camera
    {
        private static Regex regx = new Regex("(\\d{3})");

        public int ID { get; }
        public string Name { get; }
        public float Lat { get; }
        public float Lng { get; }

        public Camera(int id, string name, float lat, float lng)
        {
            ID = id;
            Name = name;
            Lat = lat;
            Lng = lng;
        }

        public static Camera FromLine(string line)
        {
            return Camera.FromFields(line.Split(';'));
        }

        public static Camera FromFields(string[] fields)
        {
            if (fields.Length != 3)
            {
                return null;
            }

            return new Camera(
                int.Parse(regx.Match(fields[0]).Value),
                fields[0],
                float.Parse(fields[1]),
                float.Parse(fields[2])
                );
        }
    }
}
