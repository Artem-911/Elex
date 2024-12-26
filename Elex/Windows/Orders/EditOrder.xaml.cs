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
using Elex.Instances;
using Elex.Queries;

namespace Elex.Windows.Orders
{
    /// <summary>
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        private int id;
        private OrderQueries orderQuery = new OrderQueries();
        private CustomerQueries customerQuery = new CustomerQueries();
        private ItemQueries itemQuery = new ItemQueries();
        public EditOrder(int id)
        {
            this.id = id;
            InitializeComponent();
            Order oldOrder = orderQuery.getOrderById(id);
            priceBox.Text = oldOrder.Price.ToString();
            quantityBox.Text = oldOrder.Quantity.ToString();

            List<Customer> customers = customerQuery.getAllCustomers();
            List<Item> items = itemQuery.getAllItems();
            
            for(int i = 0; i < customers.Count; i++)
            {
                customerCombo.Items.Add(customers[i].Lastname + " " + customers[i].Firstname);
                if (customers[i].Id == oldOrder.CustomerId)
                {
                    customerCombo.SelectedIndex = i;
                }
            }

            for(int i = 0; i < items.Count; i++)
            {
                itemCombo.Items.Add(items[i].Name);
                if (items[i].Id == oldOrder.ItemId)
                {
                    itemCombo.SelectedIndex = i;
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

        public void showError(string message)
        {
            errorBox.Text = message;
            errorBox.Visibility = Visibility.Visible;
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
                orderQuery.updateOrder(
                    id,
                    Convert.ToInt32(itemId),
                    Convert.ToInt32(customerId),
                    Convert.ToInt32(priceValue),
                    Convert.ToInt32(quantityValue),
                    currentDate, 2
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
