# Operator overloadint

This shows how do + and - operators overloading. In the same way are doing other operators overloading. Here it shown in example of \'arithmetic vector\' sum and substraction.

#####Some code snipet

*Code snipet from class library*
```C#

public static ArithmeticVector operator +(ArithmeticVector p1, ArithmeticVector p2)
{
    return new ArithmeticVector(new Point(p1.A.X + p2.A.X, p1.A.Y + p2.A.Y), 
                                    new Point(p1.B.X + p2.B.X, p1.B.Y + p2.B.Y));
}

public static ArithmeticVector operator - (ArithmeticVector p1, ArithmeticVector p2)
{
    return new ArithmeticVector(new Point(p1.A.X - p2.A.X, p1.A.Y - p2.A.Y),
                                    new Point(p1.B.X - p2.B.X, p1.B.Y - p2.B.Y));
}
```

*Code snipet from class library usage*
```C#
ArithmeticVector v1 = new ArithmeticVector(new Point(1, 2), new Point(13, 5));
ArithmeticVector v2 = new ArithmeticVector(new Point(9, 2), new Point(22, 2));

Console.WriteLine($"Vector v1 is: {v1}");
Console.WriteLine($"Vector v2 is: {v2}");

Console.WriteLine($"Vector v1 + v2 is {v1 + v2}");
Console.WriteLine($"Vector v1 - v2 is {v1 - v2}");
```

The result of mentioned class library usage is below:

![#1589F0]
Vector v1 is: Vector is((1,2), (13, 5)) <br />
Vector v2 is: Vector is((9,2), (22, 2)) <br />
Vector v1 + v2 is Vector is((10,4), (35, 7)) <br />
Vector v1 - v2 is Vector is((-8,0), (-9, 3)) <br />
`#1589F0`

> This project written for .NET Framework 4.5.2 version, C# 6