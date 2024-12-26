using Elex.Instances;
using Elex.Queries;
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
using System.Windows.Shapes;

namespace Elex.Windows.Orders
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        private OrderQueries orderQuery = new OrderQueries();
        private CustomerQueries customerQuery = new CustomerQueries();
        private ItemQueries itemQuery = new ItemQueries();
        public AddOrder()
        {
            InitializeComponent();

            List<Customer> customers = customerQuery.getAllCustomers();
            List<Item> items = itemQuery.getAllItems();

            for (int i = 0; i < customers.Count; i++)
            {
                customerCombo.Items.Add(customers[i].Lastname + " " + customers[i].Firstname);
                if(i == 0)
                {
                    customerCombo.SelectedIndex = 0;
                }
            }

            for (int i = 0; i < items.Count; i++)
            {
                itemCombo.Items.Add(items[i].Name);
                if(i == 0)
                {
                    itemCombo.SelectedIndex = 0;
                }
            }

        }

        private void back()
        {
            Orders orders = new Orders();
            orders.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            back();
        }

        private void showError(string message)
        {
            errorBox.Visibility = Visibility.Visible;
            errorBox.Text = message;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string customerValue = customerCombo.SelectedValue.ToString();
            string itemValue = itemCombo.SelectedValue.ToString();
            string priceValue = priceBox.Text.Trim();
            string quantityValue = quantityBox.Text.Trim();

            if (priceValue == "" || quantityValue == "")
            {
                showError("Заполните поля!");
                return;
            }

            try
            {
                string[] parts = customerValue.Split(' ');
                string lastName = parts[0];
                string firstName = parts[1];

                int customerId = customerQuery.getCustomerByName(firstName, lastName).Id;
                int itemId = itemQuery.getItemByName(itemValue).Id;
                DateTime currentDate = DateTime.Now;
                orderQuery.addOrder(
                    Convert.ToInt32(itemId),
                    Convert.ToInt32(customerId),
                    Convert.ToInt32(priceValue),
                    Convert.ToInt32(quantityValue),
                    currentDate,
                    1
                );
            }
            catch (Exception ex)
            {
                showError("Ошибка при сохранении!");
                return;
            }

            back();
        }
    }
}
