using System.Windows;
using System.Windows.Controls;
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
            RandomPasswordGenerator gen = new RandomPasswordGenerator(
                                                        AllCheckBox.IsChecked, LowCheckBox.IsChecked, 
                                                        HighCheckBox.IsChecked, SymbolsCheckBox.IsChecked, 
                                                        NumbersCheckBox.IsChecked, HEXBox.IsChecked
                                                        );

            //Can be passed 0 argument, all except "AllCheckBox" are false by default
            pswdTextBoxHEX.Text = gen.GeneratePasswordRnd();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
