<H1>Short review of Password Generator UI</H1> 

This project demonstrate usage of <b>RandomPassGenerator</b> class Library.

Code snipet for WPF project is below: 
```C#
RandomPasswordGenerator gen =
    new RandomPasswordGenerator(allAlphabet, lowCaseAlphabet, highCaseAlphabet, symbolsAlphabet, 
                                  numbersAlphabet, showHex, passMinLenght, passMaxLenght);
pswdTextBoxHEX.Text = gen.GeneratePasswordRnd();

//Can be passed 0 argument, all except "AllCheckBox" are false by default
pswdTextBoxHEX.Text = gen.GeneratePasswordRnd();
```														
You can see below some screeshots of WPF application

![Result](RandPassGen.gif)
