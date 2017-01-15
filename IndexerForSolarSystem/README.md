# Introduction of indexer overloading

*Indexers allow instances of a class or struct to be indexed just like arrays. Indexers resemble properties except that their accessors take parameters.*

For more details click to below link:
[Indexers (C# Programming Guide)](https://msdn.microsoft.com/en-us/library/6x16t2tx.aspx)

The project represents the usage of indexer. It also contains implementation of __ IEnumerator IEnumerable.GetEnumerator()__ that needs to use foreach statement.

#####Some code snipet

*Code snipet from class library*
```C#
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
```


*Code snipet from usage of class library*
```C#
Console.WriteLine("This is  to represent the use of for statement for SolarSystem object");
for (int i = 0; i < solSys.SolarSystemPlanetCount; i++)
{
    Console.WriteLine($"The {i+1} planet of Solar System is {solSys[i]}.");
}
```

The result of mentioned usage is below:

This is  to represent the use of for statement for SolarSystem object
The 1 planet of Solar System is Sun.
The 2 planet of Solar System is Mercury.
The 3 planet of Solar System is Venus.
The 4 planet of Solar System is Earth.
The 5 planet of Solar System is Mars.
The 6 planet of Solar System is Jupiter.
The 7 planet of Solar System is Saturn.
The 8 planet of Solar System is Uranus.
The 9 planet of Solar System is Neptune.


> This project written for .NET Framework 4.5.2 version, C# 6