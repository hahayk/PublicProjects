using System;
using System.Windows;

namespace RandomPassGenerator
{
    public class RandomPasswordGenerator
    {
        bool? allCheckBoxB;
        bool? lowCheckBoxB;
        bool? highCheckBoxB;
        bool? symbolsCheckBoxB;
        bool? numbersCheckBoxB;
        bool? hexBox;

        //Default ctor
        public RandomPasswordGenerator()
        {
            allCheckBoxB = true;
            lowCheckBoxB = false;
            highCheckBoxB = false;
            symbolsCheckBoxB = false;
            numbersCheckBoxB = false;
            hexBox = false;         
        }

        //Ctor with params
        public RandomPasswordGenerator(bool? allCheckBoxB, bool? lowCheckBoxB, 
                                        bool? highCheckBoxB, bool? symbolsCheckBoxB, 
                                        bool? numbersCheckBoxB, bool? hexBox)
        {
            this.allCheckBoxB = allCheckBoxB;
            this.lowCheckBoxB = lowCheckBoxB;
            this.highCheckBoxB = highCheckBoxB;
            this.symbolsCheckBoxB = symbolsCheckBoxB;
            this.numbersCheckBoxB = numbersCheckBoxB;
            this.hexBox = hexBox;
        }

        public string GeneratePasswordRnd()
        {
            string[] alph = AlphabetGenerator();
            int sz = Alphabet.Length;

            Random rnd = new Random();
            int passSize = rnd.Next(5, sz);

            string retVal = string.Empty;
            for (int i = 0; i < passSize; i++)
            {
                retVal += Alphabet[rnd.Next(0, sz)];
            }


            if (hexBox == true)
            {
                string hexik = string.Empty;
                foreach (var item in retVal)
                {
                    var toInt = Convert.ToInt32(item);
                    hexik += string.Format("{0:X2}", toInt);
                }

                return hexik; 
            }
            else
            {
                return retVal;
            }
       
        }

        //Get Alphabet for password
        private string[] AlphabetGenerator()
        {
            if (allCheckBoxB == false &&
                lowCheckBoxB == false &&
                highCheckBoxB == false &&
                symbolsCheckBoxB == false &&
                numbersCheckBoxB == false)
            {
                MessageBox.Show("Select Alphabet!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (allCheckBoxB == true)
            {
                LowCase.CopyTo(Alphabet, 0);
                HighCase.CopyTo(Alphabet, LowCase.Length);
                Symbols.CopyTo(Alphabet, LowCase.Length + HighCase.Length);
                Numbers.CopyTo(Alphabet, LowCase.Length + HighCase.Length + Symbols.Length);

                return Alphabet;
            }

            int sz = 0;
            if (lowCheckBoxB == true)
            {
                LowCase.CopyTo(Alphabet, 0);
                sz += LowCase.Length;
            }

            if (highCheckBoxB == true)
            {
                HighCase.CopyTo(Alphabet, sz);
                sz += HighCase.Length;
            }
            if (numbersCheckBoxB == true)
            {
                Numbers.CopyTo(Alphabet, sz);
                sz += Numbers.Length;
            }
            if (symbolsCheckBoxB == true)
            {
                Symbols.CopyTo(Alphabet, sz);
                sz += Numbers.Length;
            }

            return Alphabet;
        }

        //Defauld Alphabet
        private string[] Alphabet = new string[88];
        private string[] LowCase = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        private string[] HighCase = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private string[] Numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private string[] Symbols = { "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "*", "(", ")", "-", "_", "+", "=", "<", ">", "?", "/", "[", "]", "{", "}", "|", "\\" };
    }
}
