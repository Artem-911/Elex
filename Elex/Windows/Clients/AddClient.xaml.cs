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
using Elex.Queries;
using Elex.Instances;

namespace Elex.Windows.Clients
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        private CustomerQueries customerQuery = new CustomerQueries();
        public AddClient()
        {
            InitializeComponent();
        }

        private void back()
        {
            Clients clients = new Clients();
            clients.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            back();
        }

        private void showError(string message)
        {
            errorBox.Text = message;
            errorBox.Visibility = Visibility.Visible;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string firstname = firstnameBox.Text.Trim();
            string secondname = secondnameBox.Text.Trim();
            string lastname = lastnameBox.Text.Trim();
            string phone = phoneBox.Text.Trim();

            if (firstname == "" || secondname == "" || lastname == "" || phone == "")
            {
                showError("Заполните поля!");
                return;
            }
            try
            {
                DateTime currentDate = DateTime.Now;
                customerQuery.addCustomer(firstname, secondname, lastname, phone, currentDate);
            }
            catch (Exception ex)
            {
                showError("Ошибка при сохранении данных!");
                return;
            }

            back();
        }
    }
}
