using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RunningButtonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            
            InitializeComponent();
            Grid.Height = MyMainWindow.Height * 0.9; //(90%)
            Grid.Width = MyMainWindow.Width * 0.9; //(90%)

        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            button.MouseEnter += button_rndMove;
        }
        
        private void button_rndMove(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();

            var width = rnd.Next(0, (int)Grid.Width - (int)button.Width);

            var height = rnd.Next(0, (int)Grid.Height - (int)button.Height);

            button.Margin = new Thickness(width, height, 0, 0);
        }
    }
}
