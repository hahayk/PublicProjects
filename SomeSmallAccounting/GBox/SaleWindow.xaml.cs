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
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace GBox
{
    /// <summary>
    /// Interaction logic for SaleWindow.xaml
    /// </summary>
    public partial class SaleWindow : Window
    {
        public SaleWindow()
        {
            InitializeComponent();

            FocusManager.SetFocusedElement(this, saleQuantity);
        }

        public SaleWindow(object obj)
        {
            UpperObj = obj;

            new SaleWindow();
        }

        private object _upperObj;

        public object UpperObj
        {
            get { return _upperObj; }
            set { _upperObj = value; }
        }

        public int Qnt
        {
            get;
            set;
        }

        public double? Price
        {
            set;
            get;
        }

        public string Note
        {
            set;
            get;
        }

        public double Price_Sum
        {
            set;
            get;
        }

        private void saleQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = (sender as TextBox).Text;
            if (!IsTextAllowed(str))
            {
                (sender as TextBox).Text.Remove(str.Length - 1, 1);
            }
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Qnt = int.Parse(saleQuantity.Text);

                if (Qnt == 0)
                {
                    MessageBox.Show("Please enter value greater than 0");
                    return;
                }

                ConnectStoreDBDataContext obj = new ConnectStoreDBDataContext();
                Store str = obj.Stores.Single(s => s.ID == MainView.CurrentID);

                if (str.Quantity_Now >= Qnt)
                {
                    str.Quantity_Now = str.Quantity_Now - Qnt;
                    obj.SubmitChanges();
                }
                else
                {

                    string errorString = "Available quantity is: " + str.Quantity_Now;
                    MessageBox.Show(errorString);
                    return;
                }

                Note = saleNote.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid values for Quantity and/or Price");
                return;
            }

            ConnectStoreDBDataContext db = new ConnectStoreDBDataContext();

            if (salePrice.Text == "")
            {
                Price = (from store in db.Stores
                         where store.ID == MainView.CurrentID
                         select store.Sale_Price_AMD).Sum();
            }
            else
            {
                Price = int.Parse(salePrice.Text);
            }

            Price_Sum = (double)Price * Qnt;

            Sale sl = new Sale();
            sl.ID_Product = MainView.CurrentID;
            sl.Sold_Qnt = Qnt;
            sl.Sale_Price = (double)Price;
            sl.Price_Sum = Price_Sum;
            sl.Note = Note;
            sl.Sale_Date = DateTime.Now;

            db.Sales.InsertOnSubmit(sl);
            db.SubmitChanges();

            MainView.CurrentID = 0;

            this.Close();
        }
    }
}
