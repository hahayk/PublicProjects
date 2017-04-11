using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Controls;

namespace GBox
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            GetItemsFromStore();
        }

        private static int _currentID = 0;

        public static int CurrentID
        {
            get
            {
                return _currentID;
            }
            set
            {
                _currentID = value;
            }
        }

        private void Insert_Btn_Click(object sender, RoutedEventArgs e)
        {
            GBox.InsertToDB objIns = new InsertToDB();
            objIns.Show();
        }

        private void Sale_btn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentID == 0)
            {
                MessageBox.Show("Please select the Product", "Unknown Product");
                return;
            }
            else
            {
                GBox.SaleWindow objSale = new GBox.SaleWindow();
                objSale.Show();
            }
        }

        private void incom_Btn_Click(object sender, RoutedEventArgs e)
        {
            GBox.Income objInc = new GBox.Income();

            objInc.Show();
        }

        private void Show_Sale_Btn_Click(object sender, RoutedEventArgs e)
        {
            GBox.Sale_History objSaleHist = new GBox.Sale_History();
            objSaleHist.Show();
        }

        private void dgShowStore_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                var obj1 = (sender as DataGrid).CurrentItem;
                CurrentID = (obj1 as Store).ID;
            }
            catch (NullReferenceException)
            {
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            GetItemsFromStore();
        }

        public void GetItemsFromStore()
        {
            ConnectStoreDBDataContext obj = new ConnectStoreDBDataContext();
            dgShowStore.ItemsSource = from store in obj.Stores
                                      select store;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
