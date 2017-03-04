using System;
using System.Windows;

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
                connect2Web.FolderPath = browseTextBox.Text;
            }

            saveContentButton.IsEnabled = true;
            saveLinksButton.IsEnabled = true;
            saveFilesButton.IsEnabled = true;
            saveAllbutton.IsEnabled = true;
        }

        private void saveAllbutton_Click(object sender, RoutedEventArgs e)
        {
            connect2Web.FolderPath = browseTextBox.Text;
            connect2Web.SaveContentToFile();
            connect2Web.SaveInfo();
            connect2Web.SaveLinkToFile();
            connect2Web.SaveMailToFile();
            connect2Web.SaveToFile();
        }

        private void saveContentButton_Click(object sender, RoutedEventArgs e)
        {
            connect2Web.SaveContentToFile();
        }
    }
}
