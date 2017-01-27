using System.Windows;
using RandomPassGenerator;
using System;

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
            bool? allAlphabet = AllCheckBox.IsChecked;
            bool? lowCaseAlphabet = LowCheckBox.IsChecked;
            bool? highCaseAlphabet = HighCheckBox.IsChecked;
            bool? symbolsAlphabet = SymbolsCheckBox.IsChecked;
            bool? numbersAlphabet = NumbersCheckBox.IsChecked;
            bool? showHex = HEXBox.IsChecked;
            int passMaxLenght = int.Parse(MaxLenBox.Text);

            try
            {
                RandomPasswordGenerator gen =
                    new RandomPasswordGenerator(allAlphabet, lowCaseAlphabet, highCaseAlphabet, symbolsAlphabet, numbersAlphabet, showHex, passMaxLenght);
                pswdTextBoxHEX.Text = gen.GeneratePasswordRnd();
                
            }
            catch (System.Exception ex)
            {
                throw ex.InnerException;
            }
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var fileFullPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\password.txt";
            System.IO.File.WriteAllText(fileFullPath, pswdTextBoxHEX.Text);
            MessageBox.Show("Generated file full path is " + fileFullPath);
        }
    }
}
