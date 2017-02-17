using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

using DownloadFromWeb;
using Microsoft.Win32;
using System.IO;


namespace DownloadFromWebWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConnectToWeb connect2Web = null;


        public MainWindow()
        {
            InitializeComponent();
            saveContentButton.IsEnabled = false;
            saveLinksButton.IsEnabled = false;
            saveFilesButton.IsEnabled = false;
            saveAllbutton.IsEnabled = false;
            browsButton.IsEnabled = false;
        }

        private void ReadContentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connect2Web = new ConnectToWeb(LinkTBox.Text);
                connect2Web.ReadPageContent();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception occured", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (connect2Web.HtmlContent != string.Empty)
            {
                saveContentButton.IsEnabled = true;
                saveLinksButton.IsEnabled = true;
                saveFilesButton.IsEnabled = true;
                saveAllbutton.IsEnabled = true;
                browsButton.IsEnabled = true;
            }
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                browseTextBox.Text = fileInfo.DirectoryName;
            }
        }
    }
}
