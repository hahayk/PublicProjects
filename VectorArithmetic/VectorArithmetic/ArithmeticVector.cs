namespace VectorArithmetic
{
    class ArithmeticVector
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public ArithmeticVector(Point p1, Point p2)
        {
            A = p1;
            B = p2;
        }

        public override string ToString()
        {
            return "Vector is(("+A.X+","+A.Y+"), ("+B.X+", "+B.Y+"))";
        }

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
    }
}
