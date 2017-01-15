using System;

namespace IndexerForSolarSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var solSys = new SolarSystem();

            //Console.Write("This is  to represent the use of ToString() overloading for SolarSystem");
            //Console.WriteLine(solSys.ToString());

            //Console.WriteLine();
            //Console.WriteLine("This is  to represent the use of foreach statement for SolarSystem object");
            //foreach (var planet in solSys)
            //{
            //    Console.WriteLine(planet);
            //}

            //Console.WriteLine();
            Console.WriteLine("This is  to represent the use of for statement for SolarSystem object");
            for (int i = 0; i < solSys.SolarSystemPlanetCount; i++)
            {
                Console.WriteLine($"The {i+1} planet of Solar System is {solSys[i]}.");
            }
        }
    }
}
