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
using Microsoft.Windows.Controls;


namespace GBox
{
    /// <summary>
    /// Interaction logic for InsertToDB.xaml
    /// </summary>
    public partial class InsertToDB : Window
    {
        public InsertToDB()
        {
            InitializeComponent();
            IdProd = 0;
            GridRow = 0;
            GridColumn = 0;
        }

        private int IdProd { set; get; }
        private int GridRow { set; get; }
        private int GridColumn { set; get; }

        private class ItemAdd
        {
            internal ItemAdd(){}

            private string _product;

            public string Product
            {
                get { return _product; }
                set { _product = value; }
            }
            private string _description;

            public string Description
            {
                get { return _description; }
                set { _description = value; }
            }
            private int _qnt;

            public int Qnt
            {
                get { return _qnt; }
                set { _qnt = value; }
            }
            private int _soldQnt;

            public int SoldQnt
            {
                get { return _soldQnt; }
                set { _soldQnt = value; }
            }
            private double _priceRealUSD;

            public double PriceRealUSD
            {
                get { return _priceRealUSD; }
                set { _priceRealUSD = value; }
            }
            private double _priceRealAMD;

            public double PriceRealAMD
            {
                get { return _priceRealAMD; }
                set { _priceRealAMD = value; }
            }
            private string _link;

            public string Link
            {
                get { return _link; }
                set { _link = value; }
            }
            private string _note;

            public string Note
            {
                get { return _note; }
                set { _note = value; }
            }


        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            /*dataGrid1.Items.Add(new ItemAdd() 
                                            {
                                                "New Prod",
                                                "Prod Desc",
                                                "Qnt",
                                                "Sold Qnt",
                                                "priceRealUSD",
                                                "priceRealAMD",
                                                "link",
                                                "Note"                                            
                                            });

            //RowDefinition clmn = new RowDefinition();
            //IdProd += 1;
            //GridColumn = 0;

            //dataGrid1.Items.Add(new my:dataItem());


            //Show_Grid.RowDefinitions.Add(clmn);

            /*
           + <Label                      Grid.Column="0" Grid.Row="1">1</Label>
           + <TextBox Name="prodName"    Grid.Column="1" Grid.Row="1">Enter Here</TextBox>
           + <TextBox Name="descName"    Grid.Column="2" Grid.Row="1">Enter Here</TextBox>
           + <TextBox Name="qnt"         Grid.Column="3" Grid.Row="1">3</TextBox>
           + <TextBox Name="soldQnt"     Grid.Column="4" Grid.Row="1">3</TextBox>
        + <TextBox Name="priceRealUSD"   Grid.Column="5" Grid.Row="1">Price</TextBox>
        + <TextBox Name="priceRealAMD"   Grid.Column="6" Grid.Row="1">Price</TextBox>
           + <TextBox Name="link"        Grid.Column="7" Grid.Row="1">link</TextBox>
           + <TextBox Name="note"        Grid.Column="8" Grid.Row="1">note</TextBox>
             */
            

/*
            //ID
            Label idProd = new Label();
            idProd.Content = IdProd;
            Grid.SetRow(idProd, GridRow);
            Grid.SetColumn(idProd, GridColumn);
            Show_Grid.Children.Add(idProd);
            GridColumn += 1;

            //Product Name
            TextBox prodName = new TextBox();
            prodName.Text = "prodName" + GridRow;
            Grid.SetColumn(prodName, GridColumn);
            GridColumn += 1;
            Grid.SetRow(prodName, GridRow);
            Show_Grid.Children.Add(prodName);

            //Description Name
            TextBox descName = new TextBox();
            descName.Text = "descName" + GridRow;
            Grid.SetColumn(descName, GridColumn);
            GridColumn += 1;
            Grid.SetRow(descName, GridRow);
            Show_Grid.Children.Add(descName);

            //Quantity
            TextBox qnt = new TextBox();
            qnt.Text = "qnt";
            Grid.SetColumn(qnt, GridColumn);
            GridColumn += 1;
            Grid.SetRow(qnt, GridRow);
            Show_Grid.Children.Add(qnt);

            //Real Price USD
            TextBox priceRealUSD = new TextBox();
            priceRealUSD.Text = "priceRealUSD";
            Grid.SetColumn(priceRealUSD, GridColumn);
            GridColumn += 1;
            Grid.SetRow(priceRealUSD, GridRow);
            Show_Grid.Children.Add(priceRealUSD);

            //Real Price AMD
            TextBox priceRealAMD = new TextBox();
            priceRealAMD.Text = "priceRealAMD";
            priceRealAMD.IsReadOnly = true;
            Grid.SetColumn(priceRealAMD, GridColumn);
            GridColumn += 1;
            Grid.SetRow(priceRealAMD, GridRow);
            Show_Grid.Children.Add(priceRealAMD);


            //Sale Price
            TextBox priceSale = new TextBox();
            priceSale.Text = "priceSale";
            Grid.SetColumn(priceSale, GridColumn);
            GridColumn += 1;
            Grid.SetRow(priceSale, GridRow);
            Show_Grid.Children.Add(priceSale);


            //Link
            TextBox link = new TextBox();
            link.Text = "Link";
            Grid.SetColumn(link, GridColumn);
            GridColumn += 1;
            Grid.SetRow(link, GridRow);
            Show_Grid.Children.Add(link);

            //Note
            TextBox note = new TextBox();
            note.Text = "Note";
            Grid.SetColumn(note, GridColumn);
            GridColumn += 1;
            Grid.SetRow(note, GridRow);
            Show_Grid.Children.Add(note);

            GridRow += 1;
*/
        }

        private void Discard_btn_Click(object sender, RoutedEventArgs e)
        {
           // dataGrid1.Items.Remove(sender);
            //dataGrid1.Items.Add(new DataGrid());
            this.Close();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
           // Show_Grid.RowDefinitions.RemoveAt(0);
        }
    }
}
