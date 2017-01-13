<H1>Short review of Password Generator</H1> 


 
To use class library you need at first do <b>"using RandomPassGenerator"</b> to your project, create object of <b>RandomPasswordGenerator</b> class and call <b>GeneratePasswordRnd</b> function. 


 
By default all parameters but <b>useFullAlphabet</b> are false, which allows to generate random password with lowercase/highercase alphabet, symbols and numbers. 

Code snipet of class library is below: 


```C# 
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
    }

```