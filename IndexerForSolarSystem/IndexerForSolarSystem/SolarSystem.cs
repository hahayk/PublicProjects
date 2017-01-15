using System.Collections;
using System.Collections.Generic;

namespace IndexerForSolarSystem
{
    class SolarSystem : IEnumerable<string>
    {
        public int SolarSystemPlanetCount { get { return 9; } }

        //Solar System Planets
        public string Sun { get; } = "Sun";
        public string Mercury { get; } = "Mercury";
        public string Venus { get; } = "Venus";
        public string Earth { get; } = "Earth";
        public string Mars { get; } = "Mars";
        public string Jupiter { get; } = "Jupiter";
        public string Saturn { get; } = "Saturn";
        public string Uranus { get; } = "Uranus";
        public string Neptune { get; } = "Neptune"; 

        public string this[int ind]
        {
            get
            {
                switch (ind)
                {
                    case 0:
                        return Sun;
                    case 1:
                        return Mercury;
                    case 2:
                        return Venus;
                    case 3:
                        return Earth;
                    case 4:
                        return Mars;
                    case 5:
                        return Jupiter;
                    case 6:
                        return Saturn;
                    case 7:
                        return Uranus;
                    case 8:
                        return Neptune;
                    default:
                        return "Unknown Solar System";
                }
            }
        }

        //Need to implement for using foreach operator.
        public IEnumerator<string> GetEnumerator()
        {
            yield return Sun;
            yield return Mercury;
            yield return Venus;
            yield return Earth;
            yield return Mars;
            yield return Jupiter;
            yield return Saturn;
            yield return Uranus;
            yield return Neptune;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public  override string ToString()
        {
            return "SolarSystem class library represents the planets in Solar System";
        }
    }
}
