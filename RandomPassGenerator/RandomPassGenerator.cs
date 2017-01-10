using System;

namespace RandomPassGenerator
{
    public class RandomPasswordGenerator
    {
        bool? useFullAlphabet;
        bool? useLowCaseAlphabet;
        bool? useHighCaseAlphabet;
        bool? useSymbolsAlphabet;
        bool? useNumbersAlphabet;
        bool? showInHex;

        //Default ctor
        public RandomPasswordGenerator()
        {
            useFullAlphabet = true;
            useLowCaseAlphabet = false;
            useHighCaseAlphabet = false;
            useSymbolsAlphabet = false;
            useNumbersAlphabet = false;
            showInHex = false;         
        }

        //Ctor with params
        public RandomPasswordGenerator(bool? useFullAlphabet, bool? useLowCaseAlphabet, 
                                        bool? useHighCaseAlphabet, bool? useSymbolsAlphabet, 
                                        bool? useNumbersAlphabet, bool? showInHex)
        {
            this.useFullAlphabet = useFullAlphabet;
            this.useLowCaseAlphabet = useLowCaseAlphabet;
            this.useHighCaseAlphabet = useHighCaseAlphabet;
            this.useSymbolsAlphabet = useSymbolsAlphabet;
            this.useNumbersAlphabet = useNumbersAlphabet;
            this.showInHex = showInHex;
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


            if (showInHex == true)
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
            if (useFullAlphabet == false &&
                useLowCaseAlphabet == false &&
                useHighCaseAlphabet == false &&
                useSymbolsAlphabet == false &&
                useNumbersAlphabet == false)
            {
                //returns Alphabet with no value.
                return Alphabet;
                //MessageBox.Show("Select Alphabet!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (useFullAlphabet == true)
            {
                LowCase.CopyTo(Alphabet, 0);
                HighCase.CopyTo(Alphabet, LowCase.Length);
                Symbols.CopyTo(Alphabet, LowCase.Length + HighCase.Length);
                Numbers.CopyTo(Alphabet, LowCase.Length + HighCase.Length + Symbols.Length);

                return Alphabet;
            }

            int sz = 0;
            if (useLowCaseAlphabet == true)
            {
                LowCase.CopyTo(Alphabet, 0);
                sz += LowCase.Length;
            }

            if (useHighCaseAlphabet == true)
            {
                HighCase.CopyTo(Alphabet, sz);
                sz += HighCase.Length;
            }
            if (useNumbersAlphabet == true)
            {
                Numbers.CopyTo(Alphabet, sz);
                sz += Numbers.Length;
            }
            if (useSymbolsAlphabet == true)
            {
                Symbols.CopyTo(Alphabet, sz);
                sz += Numbers.Length;
            }

            return Alphabet;
        }

        //Alphabets can be used
        private string[] Alphabet = new string[88];
        private string[] LowCase = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        private string[] HighCase = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private string[] Numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private string[] Symbols = { "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "*", "(", ")", "-", "_", "+", "=", "<", ">", "?", "/", "[", "]", "{", "}", "|", "\\" };
    }
}
