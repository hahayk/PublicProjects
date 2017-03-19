using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareDigitsSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(squareDigitsSequence(103));
        }

        public static int squareDigitsSequence(int a0)
        {
            List<int> history = new List<int> { a0 };
            int cur = a0;
            int curA0 = 0;
            bool whileReturn = true;
            do
            {
                int temp = 0;
                curA0 = 0;

                if (cur < 10)
                {
                    history.Add(cur);
                    curA0 += Convert.ToInt32(Math.Pow(cur, 2));
                    cur = curA0;
                }
                else
                {
                    int cnt = Convert.ToInt32(Math.Log10(cur) + 1);

                    for (int i = 0; i < cnt; i++)
                    {
                        temp = cur % 10;
                        cur /= 10;
                        curA0 += Convert.ToInt32(Math.Pow(temp, 2));
                    }
                    cur = curA0;
                }
                if (!history.Contains(curA0))
                {
                    history.Add(curA0);
                }
                else
                {
                    whileReturn = false;
                }
            }
            while (whileReturn);

            return history.Count();
        }
    }
}
