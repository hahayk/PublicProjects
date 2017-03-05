using System;
using System.Windows;

using DownloadFromWeb;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;

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
            browseTextBox.IsEnabled = false;
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
                System.Windows.MessageBox.Show(ex.Message, "Exception occured", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (connect2Web.HtmlContent != string.Empty)
            {
                browsButton.IsEnabled = true;
            }
        }

        

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                browseTextBox.Text = folderDialog.SelectedPath;
                connect2Web.FolderPath = browseTextBox.Text;


                //OpenFileDialog openFileDialog = new OpenFileDialog();
                //if (openFileDialog.ShowDialog() == true)
                //{
                //    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                //    browseTextBox.Text = Directory.GetCurrentDirectory();
                //    //browseTextBox.Text = fileInfo.DirectoryName;
                //    connect2Web.FolderPath = browseTextBox.Text;
                //}

                EnableButtons();
            }
        }

        private void EnableButtons()
        {
            saveContentButton.IsEnabled = true;
            saveLinksButton.IsEnabled = true;
            saveFilesButton.IsEnabled = true;
            saveAllbutton.IsEnabled = true;
            browseTextBox.IsEnabled = true;
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

        private void saveLinksButton_Click(object sender, RoutedEventArgs e)
        {
            connect2Web.SaveLinkToFile();
        }

        private void saveFilesButton_Click(object sender, RoutedEventArgs e)
        {
            connect2Web.SaveToFile();
        }

        private void TextBoxChangeEvent(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(browseTextBox.Text))
            {
                connect2Web.FolderPath = browseTextBox.Text;

                EnableButtons();
            }
            else
            {
                System.Windows.MessageBox.Show("Please enter valid folder path!!!");
                //browseTextBox.Text = "";
            }
        }

    }
}
