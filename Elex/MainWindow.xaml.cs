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
using Elex.Instances;
using Elex.Windows.Categories;
using Elex.Windows.Suppliers;
using Elex.Windows.Items;
using Elex.Windows.Orders;
using Elex.Windows.Clients;
using Elex.Windows;

namespace Elex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            suppliers.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Categories categories = new Categories();
            categories.Show();
            this.Close(); 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Items items = new Items();
            items.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SignIn win = new SignIn();
            win.Show();
            this.Close();
        }
    }
}
