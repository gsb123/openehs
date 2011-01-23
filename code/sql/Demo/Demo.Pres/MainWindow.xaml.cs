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
using Demo.Domain;
using Demo.Data;
using MySql.Data.MySqlClient;

namespace Demo.Pres
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataTier dt;

        public MainWindow()
        {
            InitializeComponent();

            dt = new DataTier();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Products products = new Products();

            products.Name = tbname.Text.ToString();
            products.Unit = tbunit.Text.ToString();
            products.Catagory = tbcata.Text.ToString();
            products.ProductCost = Convert.ToDecimal(tbprodcost.Text.ToString());
            products.QuantityOnHand = Convert.ToInt32(tbquanonhand.Text.ToString());

            dt.InsertProduct(products);
        }
    }
}
