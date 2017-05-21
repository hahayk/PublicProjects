using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagesNumberingWithInk
{
    class Program
    {
        static void Main(string[] args)
        {
            pagesNumberingWithInk(21, 5);
        }

        public static int pagesNumberingWithInk(int current, int numberOfDigits)
        {
            int currentLastDigit  = current;
            
            int curNumberInks = Convert.ToInt32(Math.Floor(Math.Log10(current))) + 1;
            numberOfDigits -= curNumberInks;
            
            while (numberOfDigits > 0)
            {
                curNumberInks = Convert.ToInt32(Math.Floor(Math.Log10(current++))) + 1;
                numberOfDigits -= curNumberInks;
                if (numberOfDigits >= 0)
                {
                    currentLastDigit = current;
                }
                else
                {
                    break;
                }

            }
            
            return currentLastDigit;
        }
    }
}
