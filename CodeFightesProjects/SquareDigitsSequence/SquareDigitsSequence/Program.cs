using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareDigitsSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(squareDigitsSequence(16));
        }

        public static int squareDigitsSequence(int a0)
        {
            int sum = 1;
            List<int> history = new List<int>();
            int cur = a0;
            int curA0 = 0;
            while(history.BinarySearch(curA0) <= 0 || curA0 != a0)
            //while (curA0 != a0)
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
                    //if (cur != 0)
                    //{
                    //    cur = curA0 + Convert.ToInt32(Math.Pow(cur, 2));
                    //}
                    //else
                    {
                        cur = curA0;
                        history.Add(curA0);
                    }
                }
                ++sum;
            }
            return sum;
        }
    }
}
