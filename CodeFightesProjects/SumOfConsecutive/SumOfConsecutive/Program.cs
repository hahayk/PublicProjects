using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfConsecutive
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Stopwatch();
            st.Start();
            Console.WriteLine(isSumOfConsecutive2(9));
            st.Stop();
            Console.WriteLine(st.ElapsedMilliseconds);
        }

        public static int isSumOfConsecutive2(int n)
        {
            int sum = 0;
            int curVal = 0;
            for (int j = 1; j < n / 2 + 1; j++)
            {
                curVal = 0;
                for (int i = j; i <= n / 2; i++)
                {
                    if ((curVal += i) == n)
                    {
                        ++sum;
                        break;
                    }
                    if (curVal > n)
                    {
                        break;
                    }
                }
            }
            return sum;
        }

    }
}
