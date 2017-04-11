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

namespace GBox
{
    /// <summary>
    /// Interaction logic for Income.xaml
    /// </summary>
    public partial class Income : Window
    {
        public Income()
        {
            InitializeComponent();

            ConnectStoreDBDataContext obj = new ConnectStoreDBDataContext();

            //Cost for all items
            var allCst = obj.Stores.AsEnumerable().Sum(cost => cost.Real_Price_AMD * cost.Quantity_Start);
            tbCost.Text = allCst.ToString();

            //Sale summary
            var sal = obj.Sales.AsEnumerable().Sum(income => income.Price_Sum);
            tbSale.Text = sal.ToString();
            
       //     var curCst = obj.Sales.AsEnumerable().Sum(cost => cost.Price_Sum);
       //     tbcurrentCost.Text = curCst.ToString();

            //Cost for sold items
            double? currentCst = (from cst in obj.Stores
                      join sl in obj.Sales on cst.ID equals sl.ID_Product
                      select cst.Real_Price_AMD).Sum();
            tbcurrentCost.Text = currentCst.ToString();


            //Current Income
            tbCurIncome.Text = (sal - currentCst).ToString();

            //Overall Income
            tbOverallIncome.Text = (sal - allCst).ToString();

      /*      var query = obj.Stores.Join(sal,
                (cst => cst.ID),
                ()
                );
            */
            /*
              var query = from clients in db.Clients  
                 join orders in db.Orders on clients.Id equals orders.ClientId  
                 select new { Clients = clients, Orders = orders }; 

             * 
             var query = db.Clients.Join( orders,       // Target table
              ( cl => cl.Id ),   // ID of clients column
              ( or => or.ClientID), // Corresponding ID for orders to join on
              ( ( cl, or ) => new { Clients = cl, Orders = or } ));
             * 
             * 
             */

        }

        private void ok_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
