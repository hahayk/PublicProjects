/// <summary>
/// Generate random password with given alphabet and lenght
/// </summary>

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
        int minLen;
        int maxLen;

        //Default constructor
        public RandomPasswordGenerator()
        {
            useFullAlphabet = true;
            useLowCaseAlphabet = false;
            useHighCaseAlphabet = false;
            useSymbolsAlphabet = false;
            useNumbersAlphabet = false;
            showInHex = false;
            minLen = 5;
            maxLen = 5;

        }

        //Constructor with params
        public RandomPasswordGenerator(bool? useFullAlphabet, bool? useLowCaseAlphabet,
                                        bool? useHighCaseAlphabet, bool? useSymbolsAlphabet,
                                        bool? useNumbersAlphabet, bool? showInHex,
                                        int minLen=5, int maxLen=5) :this()
        {
            this.useFullAlphabet = useFullAlphabet;
            this.useLowCaseAlphabet = useLowCaseAlphabet;
            this.useHighCaseAlphabet = useHighCaseAlphabet;
            this.useSymbolsAlphabet = useSymbolsAlphabet;
            this.useNumbersAlphabet = useNumbersAlphabet;
            this.showInHex = showInHex;

            //check maxLen
            maxLen = maxLen < minLen ? minLen : maxLen;

            this.minLen = minLen;
            this.maxLen = maxLen;

        }

        public string GeneratePasswordRnd()
        {
            string alph = AlphabetGenerator();

            try {
                int sz = Alphabet.Length;
                Random rnd = new Random();
                int passSize = rnd.Next(minLen, maxLen);

                string retVal = string.Empty;
                for (int i = 0; i < passSize; i++)
                {
                    retVal += Alphabet[rnd.Next(0, sz)];
                }

                if (showInHex == true)
                {
                    string hexik = string.Empty;

                    if (useFullAlphabet != null || useLowCaseAlphabet != null
                        || useHighCaseAlphabet != null || useNumbersAlphabet != null
                        || useSymbolsAlphabet != null)
                    {
                        foreach (var item in retVal)
                        {
                            var toInt = Convert.ToInt32(item);
                            hexik += string.Format("{0:X2}", toInt);
                        }

                    }
                    return hexik;
                }
                else
                {
                    return retVal;
                }
            }
            catch (Exception)
            {
                return "Invalid alphabet is selected";
            }
        }

        //Get Alphabet for password
        //private string[] AlphabetGenerator()
        private string AlphabetGenerator()
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
                Alphabet += string.Join("", LowCase) + string.Join("", HighCase) +
                            string.Join("", Symbols) + string.Join("", Numbers);

                return Alphabet;
            }

            int sz = 0;
            if (useLowCaseAlphabet == true)
            {
                Alphabet += string.Join("", LowCase);
                sz += LowCase.Length;
            }

            if (useHighCaseAlphabet == true)
            {
                Alphabet += string.Join("", HighCase);
                sz += HighCase.Length;
            }
            if (useNumbersAlphabet == true)
            {
                Alphabet += string.Join("", Numbers);
                sz += Numbers.Length;
            }
            if (useSymbolsAlphabet == true)
            {
                Alphabet += string.Join("", Symbols);

                sz += Symbols.Length;
            }

            return Alphabet;
        }

        //Alphabets can be used
        private string Alphabet;
        private char[] LowCase = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private char[] HighCase = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private char[] Numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char[] Symbols = { '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '*', '(', ')', '-', '_', '+', '=', '<', '>', '?', '/', '[', ']', '{', '}', '|', '\\' };
    }
}
