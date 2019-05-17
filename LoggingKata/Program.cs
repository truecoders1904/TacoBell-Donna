using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);
            
            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            ITrackable LocationA = null;
            ITrackable LocationB = null;



            // Create a `double` variable to store the distance
            double MaxDistance = 0;


            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for (int i = 0; i < locations.Length; i++)
            {
                // Create a new corA Coordinate with your locA's lat and long
                GeoCoordinate corA = new GeoCoordinate(locations[i].Location.Latitude, locations [i].Location.Longitude);

                // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
                for (int j = 0; j < locations.Length; j++)
                {
                    // Create a new Coordinate with your locB's lat and long
                    GeoCoordinate corB = new GeoCoordinate(locations[j].Location.Latitude, locations[j].Location.Longitude);
                    // Now, compare the two using `.GetDistanceTo()`, which returns a double
                    double Distance = corA.GetDistanceTo(corB);

                    // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
                    if (Distance > MaxDistance)
                    {
                        MaxDistance = Distance;
                        LocationA = locations[i];
                        LocationB = locations[j];

                    }
                }
            }

            Console.WriteLine(LocationA.Name + LocationB.Name);

            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.

        }
    }
}