using Elex.Instances;
using Elex.Queries;
using Elex.Windows.Categories;
using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace Elex.Windows.Clients
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        private CustomerQueries query = new CustomerQueries();
        public Clients()
        {
            InitializeComponent();
            List<Customer> customers = query.getAllCustomers();
            dataGrid.ItemsSource = customers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddClient add = new AddClient();
            add.Show();
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if (selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Customer).Id;
                EditClient edit = new EditClient(id);
                edit.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите данные для редактирования!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if (selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Customer).Id;
                query.deleteCustomer(id);
                dataGrid.ItemsSource = null;
                List<Customer> customers = query.getAllCustomers();
                dataGrid.ItemsSource = customers;
            }
            else
            {
                MessageBox.Show("Выберите данные для удаления!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow2 main = new MainWindow2();
            main.Show();
            this.Close();
        }
    }
}
