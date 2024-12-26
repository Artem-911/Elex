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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Elex.Queries;

namespace Elex.Windows.Suppliers
{
    /// <summary>
    /// Interaction logic for AddSupplier.xaml
    /// </summary>
    public partial class AddSupplier : Window
    {
        private SuppliersQuery query = new SuppliersQuery();
        public AddSupplier()
        {
            InitializeComponent();
            errorBox.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            suppliers.Show();
            this.Close();
        }

        public void showError(string message) {
            errorBox.Text = message;
            errorBox.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = nameBox.Text.Trim();
            string phone = phoneBox.Text.Trim();
            if(name == "" || phone == "")
            {
                showError("Заполните поля!");
                return;
            }

            try
            {
                query.addSupplier(name, phone);
            }
            catch(Exception ex)
            {
                showError("Ошибка при сохранении!");
                return;
            }

            Suppliers suppliers = new Suppliers();
            suppliers.Show();
            this.Close();
        }
    }
}
