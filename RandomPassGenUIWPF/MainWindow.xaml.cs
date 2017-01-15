using System.Windows;
using RandomPassGenerator;

namespace RandomPassGenUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rnPassButton_Click(object sender, RoutedEventArgs e)
        {
            //Can be passed 0 argument, all except "AllCheckBox" are false by default
            bool? allAlphabet= AllCheckBox.IsChecked;
            bool? lowCaseAlphabet= LowCheckBox.IsChecked;
            bool? highCaseAlphabet = HighCheckBox.IsChecked;
            bool? symbolsAlphabet= SymbolsCheckBox.IsChecked;
            bool? numbersAlphabet= NumbersCheckBox.IsChecked;
            bool? showHex = HEXBox.IsChecked;
            int passMinLenght = int.Parse(MinLenBox.Text);
            int passMaxLenght = int.Parse(MaxLenBox.Text);

            try
            {
                RandomPasswordGenerator gen =
                    new RandomPasswordGenerator(allAlphabet, lowCaseAlphabet, highCaseAlphabet, symbolsAlphabet, numbersAlphabet, showHex, passMinLenght, passMaxLenght);
                pswdTextBoxHEX.Text = gen.GeneratePasswordRnd();
            }
        catch (System.Exception ex)
            {
                throw ex.InnerException;
            }

        }
    }
}
