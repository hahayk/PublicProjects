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

            try
            {
                RandomPasswordGenerator gen = new RandomPasswordGenerator(
                                                                AllCheckBox.IsChecked, LowCheckBox.IsChecked,
                                                                HighCheckBox.IsChecked, SymbolsCheckBox.IsChecked,
                                                                NumbersCheckBox.IsChecked, HEXBox.IsChecked,
                                                                int.Parse(MinLenBox.Text), int.Parse(MaxLenBox.Text)
                                                                );
                pswdTextBoxHEX.Text = gen.GeneratePasswordRnd();
            }
            catch (System.Exception)
            {
                throw;// System.ArgumentNullException;
            }

        }
    }
}
