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
using System.Windows.Navigation;


namespace GBox
{
    /// <summary>
    /// Interaction logic for Sale_History.xaml
    /// </summary>
    public partial class Sale_History : Window
    {
        public Sale_History()
        {
            InitializeComponent();

            //Show Sales
            ConnectStoreDBDataContext obj1 = new ConnectStoreDBDataContext();
            dgShowSale.ItemsSource = from store in obj1.Stores
                                     join sale in obj1.Sales
                                         on store.ID equals sale.ID_Product
                                     select new
                                     {
                                         sale.ID,
                                         Name = store.Product,
                                         Store_ID = store.ID,
                                         sale.Sale_Price,
                                         sale.Sold_Qnt,
                                         sale.Price_Sum,
                                         sale.Sale_Date,
                                         sale.Note
                                     };

            //////////////////////////////////////////////////////////////////////////
            // in tab 2 show [Overall_Sale, Sold_Qnt, Overall_Qnt]
            /*
            ConnectStoreDBDataContext db = new ConnectStoreDBDataContext();

            var query = from sale in db.Sales
                        str in db.Stores
                        select new
                        {
                            ID = dbom.Key.ID_Product,
                            SalePrice,
                            SaleQnt = dbom.Sum(q => q.Sold_Qnt)

                        };


            var query1 = from gpS in query
                        join store in db.Stores
                        on gpS.ID equals store.ID
                        select new
                        {
                            ID = gpS.ID,
                            Name = store.Product,
                            Sale_Price_Sum = gpS.SalePrice,
                            Sale_Quantity = gpS.SaleQnt,
                            Quantity = store.Quantity_Start - gpS.SaleQnt
                        };



            //////////////////////////////////////////////////////////////////////////
            */

            
        }

        //Show sale Summary
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Sale_Sum smObj = new Sale_Sum();
            smObj.Show();

            ConnectStoreDBDataContext db = new ConnectStoreDBDataContext();

            var query = from sale in db.Sales
                        group sale by new { sale.ID_Product } into dbom
                        let SalePrice = dbom.Sum(s => s.Price_Sum)
                        select new
                        {
                            ID = dbom.Key.ID_Product,
                            SalePrice,
                            SaleQnt = dbom.Sum(q => q.Sold_Qnt)
                            
                        };

            
            smObj.dgSaleSum.ItemsSource = from gpS in query
                                          join store in db.Stores
                                          on gpS.ID equals store.ID
                                          select new
                                          {
                                              ID = gpS.ID,
                                              Name = store.Product,
                                              Sale_Price_Sum = gpS.SalePrice,
                                              Sale_Quantity = gpS.SaleQnt,
                                              Quantity = store.Quantity_Start - gpS.SaleQnt
                                          };
        }
    }
}
